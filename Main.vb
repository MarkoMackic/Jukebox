Imports System.Runtime.InteropServices
Imports JukeBox.Controllers
Imports JukeBox.Controllers.Controller
Imports System.IO
Imports System.Data.SqlServerCe
Imports System.Drawing.Drawing2D

Public Class Form1

    'Money related
    Dim credit As Integer = 0

    Public store As Storage

    Private allSongsIdx = 0

    Private dbConn As SqlCeConnection = Nothing

    Private currentListPanel As ListPanel

    Private queuedSongs As New Queue(Of String)

    Private currentOrder As New List(Of String)

    Private t As New Timer


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

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Form settings 
        Me.BackgroundImage = Image.FromFile(Settings.getInst().getVal("background_image"))

        wmp.Visible = False


        ' Db connection

        dbConn = New SqlCeConnection(String.Format("Data Source = {0}", Path.GetFullPath(Settings.getInst().getVal("db_file"))))

        dbConn.Open()


        ' LoadSongs 

        store = Storage.getFromDirectory(Path.GetFullPath(Settings.getInst().getVal("music_library_location")))

        ' Top List

        ' Song Selected handler

        AddHandler store.songSelected, AddressOf songSelected

        store.initialize(True)

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


        AddHandler wmp.MediaError, AddressOf WmpMediaError
        AddHandler wmp.PlayStateChange, AddressOf WmpPlayStateChanged
        AddHandler wmp.MediaChange, AddressOf WmpMediaChanged

    End Sub

    Private Sub creditChange(ByVal i As Integer)
        credit += i
        lblCredit.Text = "Kredit : " + credit.ToString()
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
        Me.Close()
    End Sub


    Private Sub changeMedia()
        If (queuedSongs.Count > 0) Then
            wmp.URL = queuedSongs.Dequeue()
        End If

        wmp.URL = store.getRandomSong()
    End Sub



    Private Sub WmpPlayStateChanged(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent)
        If e.newState = WMPLib.WMPPlayState.wmppsMediaEnded Or e.newState = WMPLib.WMPPlayState.wmppsStopped Then
            changeMedia()
        End If
    End Sub

    Private Sub WmpMediaError(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_MediaErrorEvent)

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
        If (currentOrder.Contains(path)) Then

        End If


    End Sub

End Class
