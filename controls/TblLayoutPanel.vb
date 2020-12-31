Public Class TblLayoutPanel
    Inherits TableLayoutPanel

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()


        MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer _
                      Or ControlStyles.ResizeRedraw _
                      Or ControlStyles.AllPaintingInWmPaint _
                      Or ControlStyles.SupportsTransparentBackColor, True)
    End Sub

End Class
