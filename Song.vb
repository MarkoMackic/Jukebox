Public Class Song

    Private p, dsplName As String

    Public Sub New(ByVal path As String)
        Me.p = path
        Me.dsplName = System.IO.Path.GetFileNameWithoutExtension(path)
    End Sub

    Public Sub New(ByVal path As String, ByVal dsplName As String)
        Me.New(path)
        Me.dsplName = dsplName
    End Sub

    Public Function getDisplay() As String
        Return Me.dsplName
    End Function

    Public Function getPath() As String
        Return Me.p
    End Function

End Class
