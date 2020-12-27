Namespace Controllers

    Partial Public Class Controller

        Public Event ControllerEvent(ByVal ctrlEvt As ControllerEvt)

        Enum ControllerEvt
            OK
            CANCEL
            UP
            DOWN
            COIN_ACCEPTED
        End Enum


        Protected Sub eventRecieved(ByVal ctrlEvt As ControllerEvt)
            RaiseEvent ControllerEvent(ctrlEvt)
        End Sub

    End Class

End Namespace
