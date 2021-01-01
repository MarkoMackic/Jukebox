Imports System.Runtime.InteropServices
Imports JukeBox.Controllers
Imports JukeBox.Controllers.Controller
Imports System.IO
Imports System.Data.SqlServerCe
Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient

Public Class Form1

    'Money related
    Dim credit As Integer = 0

    Public store As Storage

    Private allSongsIdx = 0

    Private dbConn As SqlCeConnection = Nothing

    Private currentListPanel As ListPanel

    Private queuedSongs As New Queue(Of String)

    Private currentOrder As New List(Of String)

    Private failedSongs As HashSet(Of String)

    Private songTimeTracker As New Timer

    Private Delegate Sub nextSong()

    Private nxtSong As nextSong = AddressOf changeMedia

    Sub New()
        InitializeComponent()

        MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer _
                      Or ControlStyles.ResizeRedraw _
                      Or ControlStyles.Selectable _
                      Or ControlStyles.AllPaintingInWmPaint _
                      Or ControlStyles.UserPaint _
                      Or ControlStyles.SupportsTransparentBackColor, True)

        lblCredit.BackColor = Color.FromArgb(150, Color.DarkBlue)
        lblCurrentAction.BackColor = Color.FromArgb(150, Color.DarkBlue)
        lblSongTime.BackColor = Color.FromArgb(150, Color.DarkBlue)
        gbOrder.BackColor = Color.FromArgb(150, Color.DarkBlue)
        gbOrdered.BackColor = Color.FromArgb(150, Color.DarkBlue)

        wmp.Visible = False
        wmp.uiMode = "invisible"
        wmp.windowlessVideo = True
        wmp.settings.autoStart = True
        wmp.settings.enableErrorDialogs = False


        AddHandler wmp.MediaError, AddressOf WmpMediaError
        AddHandler wmp.PlayStateChange, AddressOf WmpPlayStateChanged
        AddHandler wmp.MediaChange, AddressOf WmpMediaChanged
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Form settings 
        Me.BackgroundImage = Image.FromFile(Settings.getInst().getVal("background_image"))

        If Settings.getInst().getVal("fullscreen") = "true" Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        End If

        ' Db connection

        dbConn = New SqlCeConnection(String.Format("Data Source = {0}", Path.GetFullPath(Settings.getInst().getVal("db_file"))))

        dbConn.Open()

        ' Load failed songs

        failedSongs = getFailedSongs(dbConn)

        ' LoadSongs 

        store = Storage.getFromDirectory(Path.GetFullPath(Settings.getInst().getVal("music_library_location")), Function(p As String) Not failedSongs.Contains(p))


        ' Top List
        loadTopList(store)

        store.initialize(True)
        ' Song Selected handler

        AddHandler store.songSelected, AddressOf songSelected


        changeMedia()

        'Initilizing app state
        creditChange(0)

        'Controller related stuff
        Dim ctrlr As Controller

        Select Case Settings.getInst().getVal("control_dev").ToUpper()
            Case "KEYBOARD"
                ctrlr = New KeyboardController(Me)
            Case "LPT"
                ctrlr = New ParallelPortController()
            Case Else
                MsgBox("Not valid controller")
                Environment.Exit(1)
        End Select

        AddHandler ctrlr.ControllerEvent, AddressOf CtrlEvt

        songTimeTracker.Interval = 500
        AddHandler songTimeTracker.Tick, AddressOf songTimeTrack
        songTimeTracker.Start()


    End Sub

    Private Function getFailedSongs(ByVal dbC As SqlCeConnection) As HashSet(Of String)
        Dim fSongs As New HashSet(Of String)

        Dim query As New SqlCeCommand("SELECT * FROM failed_songs", dbC)

        Using reader As SqlCeDataReader = query.ExecuteReader()
            While (reader.Read())
                fSongs.Add(reader.Item("path"))
            End While
        End Using

        Return fSongs
    End Function


    Private Sub creditChange(ByVal i As Integer)
        credit += i
        lblCredit.Text = "Kredit : " + credit.ToString()
    End Sub

    Private Sub songTimeTrack()
        If (wmp.playState = WMPLib.WMPPlayState.wmppsPlaying) Then
            lblSongTime.Text = wmp.Ctlcontrols.currentPositionString + "/" + wmp.currentMedia.durationString

        Else
            lblSongTime.Text = ""
        End If

    End Sub

    Private Sub loadTopList(ByVal store As Storage)
        Dim topList As SecondLevelItem = New SecondLevelItem(store, "Top lista", "", SecondLevelItem.IType.GROUP)

        Dim sqlComm1 As New SqlCeCommand("SELECT * FROM stats ORDER BY repetitions DESC", dbConn)

        Using res As SqlCeDataReader = sqlComm1.ExecuteReader()

            While (res.Read())
                Dim p As String = res.Item("path")
                Dim fName As String = Path.GetFileNameWithoutExtension(p)
                topList.items.Add(fName, New SecondLevelItem(topList, fName, p, SecondLevelItem.IType.SONG))
            End While


        End Using

        store.items.Add("Top lista", topList)
    End Sub

    Private Sub addFailedSong(ByVal path As String)
        Dim failedSongs As New SqlCeCommand("SELECT * FROM failed_songs WHERE path =  @path", dbConn)
        failedSongs.Parameters.Add("@path", path)

        Using results As SqlCeDataReader = failedSongs.ExecuteReader()
            While (results.Read())
                Return
            End While

            Dim addToFailedSongs As New SqlCeCommand("INSERT INTO failed_songs (path) VALUES (@path)", dbConn)
            addToFailedSongs.Parameters.Add("@path", path)
            addToFailedSongs.ExecuteNonQuery()
        End Using

    End Sub

    Private Sub CtrlEvt(ByVal ctrlEvt As ControllerEvt)
        If ctrlEvt = ControllerEvt.A_EXIT Then
            appShutdown()
            Return
        ElseIf ctrlEvt = ControllerEvt.COIN_ACCEPTED Then
            creditChange(1)
            'Return
        End If

        If credit = 0 Then
            Return
        End If

        ' This need to be modularized ( i.e maybe some idea of controller contexts )
        If (ctrlEvt = ControllerEvt.UP Or ctrlEvt = ControllerEvt.DOWN) Then
            If TypeOf Me.ActiveControl Is ListPanel Then
                If (ctrlEvt = ControllerEvt.UP) Then
                    CType(Me.ActiveControl, ListPanel).prevItem()
                Else
                    CType(Me.ActiveControl, ListPanel).nextItem()
                End If
            End If

            Return
        End If

        If (ctrlEvt = ControllerEvt.OK) Then
            store.currentCtx.switchToChildView()
        Else
            store.currentCtx.switchToParentView()
        End If

    End Sub

    Private Sub appShutdown()
        dbConn.Close()
        songTimeTracker.Stop()
        Me.Close()
    End Sub


    Private Sub changeMedia(Optional ByVal url As String = Nothing)
        If Not url Is Nothing Then
            wmp.URL = url
            Return
        End If

        If (queuedSongs.Count > 0) Then
            wmp.URL = queuedSongs.Dequeue()
            Return
        End If

        Dim a As String = store.getRandomSong()

        wmp.URL = a
    End Sub



    Private Sub WmpPlayStateChanged(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent)
        If e.newState = WMPLib.WMPPlayState.wmppsMediaEnded Or e.newState = WMPLib.WMPPlayState.wmppsStopped Then
            Me.BeginInvoke(nxtSong)
        End If
    End Sub

    Public Sub WmpMediaError(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_MediaErrorEvent)
        addFailedSong(wmp.URL)
        Me.BeginInvoke(nxtSong)
    End Sub

    Private Sub WmpMediaChanged(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_MediaChangeEvent)
        lblCurrentAction.Text = "Trenutna pjesma: " + Path.GetFileName(wmp.URL)
    End Sub

    Private Sub ItemChanged(ByVal idx As Integer, ByVal val As String) Handles catList.ItemSelected, groupsAndSongsList.ItemSelected
        If Not store Is Nothing Then
            store.currentCtx.setSelected(idx, val)
        End If
    End Sub

    Private Sub songSelected(ByVal path As String)
        MsgBox(path)
        changeMedia(path)
    End Sub

End Class
