Imports System.Runtime.InteropServices


Public Class Form1


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer _
                      Or ControlStyles.ResizeRedraw _
                      Or ControlStyles.Selectable _
                      Or ControlStyles.AllPaintingInWmPaint _
                      Or ControlStyles.UserPaint _
                      Or ControlStyles.SupportsTransparentBackColor, True)

        If (Environment.Is64BitProcess = False) Then
            'default LPT1 control register address

            Dim data As Short = Inp32(LPTSettings.CONTROL_REG_ADDR)
            'make bit 5 to '1' to set data direction to in 
            data = CShort(data Or &H20)
            Out32(LPTSettings.CONTROL_REG_ADDR, data)

        End If

    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Label1.Text = LPTSettings.DATA_REG_ADDR.ToString() + " " + Convert.ToString(Inp32(LPTSettings.DATA_REG_ADDR), 2)
    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class
