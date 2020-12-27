Imports System.Runtime.InteropServices
Imports JukeBox.Controllers
Imports JukeBox.Controllers.Controller

Public Class Form1

    Dim credit As Integer = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer _
                      Or ControlStyles.ResizeRedraw _
                      Or ControlStyles.Selectable _
                      Or ControlStyles.AllPaintingInWmPaint _
                      Or ControlStyles.UserPaint _
                      Or ControlStyles.SupportsTransparentBackColor, True)

        'Form init procedures
        Me.BackgroundImage = Image.FromFile("resources/images/background.jpg")
        lblCredit.BackColor = Color.FromArgb(150, Color.DarkBlue)

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

    End Sub

    Private Sub creditChange(ByVal i As Integer)
        kredit += i
        lblCredit.Text = "Kredit : " + kredit.ToString()
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Label1.Text = LPTSettings.DATA_REG_ADDR.ToString() + " " + Convert.ToString(Inp32(LPTSettings.DATA_REG_ADDR), 2)
    End Sub



    Private Sub CtrlEvt(ByVal ctrlEvt As ControllerEvt)

        If ctrlEvt = ControllerEvt.A_EXIT Then
            appShutdown()
            Return
        ElseIf ctrlEvt = ControllerEvt.COIN_ACCEPTED Then
            creditChange(1)
            Return
        End If

        If kredit = 

            Select Case ctrlEvt
                Case ControllerEvt.COIN_ACCEPTED
                    creditChange(1)
                Case ControllerEvt.A_EXIT
                    appShutdown()
            Case 
            End Select
    End Sub

    Private Sub appShutdown()

    End Sub

    Private Sub upClick()

    End Sub

    Private Sub downClick()

    End Sub



End Class
