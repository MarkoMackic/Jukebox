Public Class ScreenSaver

    Private t As Timer

    Private images As New List(Of String), curIdx As Integer = 0

    Private Sub ScreenSaver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.BackgroundImageLayout = ImageLayout.Stretch

        images.Clear()

        For Each p As String In My.Computer.FileSystem.GetFiles(Settings.getInst().getVal("screen_saver_images_location"), FileIO.SearchOption.SearchTopLevelOnly, New String() {"*.jpg", "*.jpeg", "*.png"})
            images.Add(p)
        Next

        If (images.Count = 0) Then
            Form1.closeScreenSaver()
        End If

        images = ListUtils.Shuffle(images)


        Me.BackgroundImage = Image.FromFile(images.Item(curIdx))

        t = New Timer()
        t.Interval = 5000
        AddHandler t.Tick, AddressOf changeBackground
        t.Start()

    End Sub

    Private Sub exiting(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.FormClosing
        t.Stop()
    End Sub

    Private Sub changeBackground()
        curIdx = If(curIdx + 1 < images.Count - 1, curIdx + 1, 0)
        Me.BackgroundImage = Image.FromFile(images.Item(curIdx))
    End Sub

    Private Sub doubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.MouseDoubleClick
        Form1.closeScreenSaver()
    End Sub
End Class