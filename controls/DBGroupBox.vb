Public Class DBGroupBox
    Inherits GroupBox

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer _
                      Or ControlStyles.ResizeRedraw _
                      Or ControlStyles.AllPaintingInWmPaint _
                      Or ControlStyles.SupportsTransparentBackColor, True)
    End Sub
End Class
