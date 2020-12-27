Namespace Controllers

    Public Class KeyboardController
        Inherits Controller

        Public Sub New(form As Form)
            AddHandler form.KeyUp, AddressOf KeyUp
        End Sub

        Private Sub KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
            Select Case e.KeyCode
                Case Keys.Up
                    eventRecieved(ControllerEvt.UP)
                Case Keys.Down
                    eventRecieved(ControllerEvt.DOWN)
                Case Keys.Escape
                    eventRecieved(ControllerEvt.CANCEL)
                Case Keys.Enter
                    eventRecieved(ControllerEvt.OK)
                Case Keys.R
                    eventRecieved(ControllerEvt.COIN_ACCEPTED)
            End Select

            e.Handled = True
        End Sub

    End Class


End Namespace