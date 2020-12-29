Imports System.Runtime.InteropServices
Imports JukeBox.Controllers
Imports JukeBox.Controllers.Controller
Imports System.IO
Imports System.Data.SqlServerCe
Imports System.Drawing.Drawing2D

Public Class Form1

    Dim credit As Integer = 0

    Shared allSongs As List(Of String) = New List(Of String)
    Shared queuedSongs As Queue(Of String) = New Queue(Of String)

    Shared tree As Dictionary(Of String, Dictionary(Of String, List(Of String))) = New Dictionary(Of String, Dictionary(Of String, List(Of String)))



    Private dbConn As SqlCeConnection = Nothing

    Private cats() As String
    Dim catIdx = 3

    Private performers() As String
    Dim performerIdx = 0


    Dim songsIdx = 0

    Private Function Shuffle(Of T)(ByVal collection As IEnumerable(Of T)) As List(Of T)
        Dim r As Random = New Random()
        Shuffle = collection.OrderBy(Function(a) r.Next()).ToList()
    End Function

    Sub New()
        InitializeComponent()

        MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer _
                      Or ControlStyles.ResizeRedraw _
                      Or ControlStyles.Selectable _
                      Or ControlStyles.AllPaintingInWmPaint _
                      Or ControlStyles.UserPaint _
                      Or ControlStyles.SupportsTransparentBackColor, True)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.BackgroundImage = Image.FromFile(Settings.getInst().getVal("background_image"))

        wmp.Visible = False

        lblCredit.BackColor = Color.FromArgb(150, Color.DarkBlue)
        lblCurrentAction.BackColor = Color.FromArgb(150, Color.DarkBlue)
        lblSongTime.BackColor = Color.FromArgb(150, Color.DarkBlue)


        ' LoadSongs 

        loadSongs()
        ReDim cats(tree.Count)
        tree.Keys.CopyTo(cats, 0)

        ' Db connection

        dbConn = New SqlCeConnection(String.Format("Data Source = {0}", Path.GetFullPath(Settings.getInst().getVal("db_file"))))

        dbConn.Open()

        ' 




        'Initilizing app state
        creditChange(0)

        allSongs = Shuffle(allSongs)

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


    Private Sub loadSongs()
        tree.Add("Narodna", Nothing)
        tree.Add("Zabavna", Nothing)
        tree.Add("DOmaca", Nothing)
        tree.Add("d", Nothing)
        tree.Add("e", Nothing)
        tree.Add("f", Nothing)
        tree.Add("g", Nothing)
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
            Return
        End If

        If credit = 0 Then
            Return
        End If

        If ctrlEvt = ControllerEvt.UP Then
            catIdx = If(catIdx - 1 < 0, 0, catIdx - 1)
        ElseIf ctrlEvt = ControllerEvt.DOWN Then
            catIdx = If(catIdx + 1 > cats.Length - 1, cats.Length - 1, catIdx + 1)
        End If

        DbPanel1.Invalidate()

    End Sub

    Private Sub appShutdown()
        Me.Close()
    End Sub

    Private Sub upClick()

    End Sub

    Private Sub downClick()

    End Sub

    Private Sub changeMedia(ByVal dir As TriState)
        If (queuedSongs.Count > 0) Then
            wmp.URL = queuedSongs.Dequeue()
        End If

        songsIdx = If(dir, If(songsIdx = allSongs.Count - 1, 0, songsIdx + 1), If(songsIdx = 0, allSongs.Count - 1, songsIdx - 1))

        wmp.URL = allSongs.Item(songsIdx)
    End Sub



    Private Sub WmpPlayStateChanged(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent)
        If e.newState = WMPLib.WMPPlayState.wmppsMediaEnded Or e.newState = WMPLib.WMPPlayState.wmppsStopped Then
            changeMedia(True)
        End If
    End Sub

    Private Sub WmpMediaError(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_MediaErrorEvent)

    End Sub

    Private Sub WmpMediaChanged(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_MediaChangeEvent)
        lblCurrentAction.Text = "Trenutna pjesma: " + Path.GetFileName(wmp.URL)
    End Sub


    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DbPanel1.Paint


        Dim sf As StringFormat = New StringFormat()
        sf.LineAlignment = StringAlignment.Center
        sf.Alignment = StringAlignment.Center
        sf.Trimming = StringTrimming.Word

        Dim bkgColor As Color = Color.Firebrick
        Dim frgColor As Color = Color.White
        Dim rectSize As Size = New Size(DbPanel1.DisplayRectangle.Width, DbPanel1.DisplayRectangle.Height / cats.Length)
        e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear

        e.Graphics.TranslateTransform(DbPanel1.DisplayRectangle.Width / 2, DbPanel1.DisplayRectangle.Height / 2)

        Dim centerLoc As Point = New Point(CInt(-DbPanel1.DisplayRectangle.Width / 2), CInt(-rectSize.Height / 2))


        Dim clCp As Point = centerLoc

        For i As Integer = catIdx To 0 Step -1
            Dim rct As Rectangle = New Rectangle(clCp, rectSize)
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(If(255 - (catIdx - i) * 100 > 0, 255 - (catIdx - i) * 100, 0), bkgColor)), rct)
            If i = catIdx Then
                e.Graphics.DrawRectangle(New Pen(Color.White, 3), rct)
            End If
            e.Graphics.DrawString(cats(i), FindFont(e.Graphics, cats(i), rct.Size, DefaultFont), New SolidBrush(Color.FromArgb(If(255 - (catIdx - i) * 100 > 0, 255 - (catIdx - i) * 50, 0), frgColor)), rct, sf)
            clCp.Offset(0, CInt(-rectSize.Height - 5))
        Next

        clCp = centerLoc

        For i As Integer = catIdx + 1 To cats.Length - 1
            clCp.Offset(0, CInt(rectSize.Height + 5))
            Dim rct As Rectangle = New Rectangle(clCp, rectSize)
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(If(255 - (i - catIdx) * 100 > 0, 255 - (i - catIdx) * 100, 0), bkgColor)), rct)
            e.Graphics.DrawString(cats(i), FindFont(e.Graphics, cats(i), rct.Size, DefaultFont), New SolidBrush(Color.FromArgb(If(255 - (i - catIdx) * 100 > 0, 255 - (i - catIdx) * 100, 0), frgColor)), rct, sf)

            'fillTextRect(cats(i), rct, sf, e.Graphics)
        Next


    End Sub
    Function FindFont(ByVal g As System.Drawing.Graphics, ByVal longString As String, ByVal Room As Size, ByVal PreferedFont As Font)

        If longString = Nothing Then
            Return PreferedFont
        End If
        Dim RealSize As SizeF = g.MeasureString(longString, PreferedFont)
        Dim HeightScaleRatio As Single = Room.Height / RealSize.Height
        Dim WidthScaleRatio As Single = Room.Width / RealSize.Width

        If (HeightScaleRatio < WidthScaleRatio) Then
            Return New Font(PreferedFont.Name, PreferedFont.Size * HeightScaleRatio, GraphicsUnit.Pixel)
        Else
            Return New Font(PreferedFont.Name, PreferedFont.Size * WidthScaleRatio, GraphicsUnit.Pixel)
        End If
    End Function

End Class
