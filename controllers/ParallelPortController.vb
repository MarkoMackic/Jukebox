Imports System.Timers

Namespace Controllers

    Public Class ParallelPortController
        Inherits Controller

        Dim t1 As Timer = New Timer()
        Dim currentData, initialData As Byte
        Dim swStart, swEnd As DateTime


        Dim OK_PRESS As Byte = Convert.ToInt16(Settings.getInst().getVal("lpt_ok"), 16)
        Dim CANCEL_PRESS As Byte = Convert.ToInt16(Settings.getInst().getVal("lpt_cancel"), 16)
        Dim UP_PRESS As Byte = Convert.ToInt16(Settings.getInst().getVal("lpt_up"), 16)
        Dim DOWN_PRESS As Byte = Convert.ToInt16(Settings.getInst().getVal("lpt_down"), 16)
        Dim COIN_ACCEPT As Byte = Convert.ToInt16(Settings.getInst().getVal("lpt_coin_accept"), 16)

        Public Sub New()
            Dim data As Short = Inp32(LPTSettings.CONTROL_REG_ADDR)
            'make bit 5 to '1' to set data direction to in 
            data = CShort(data Or &H20)
            Out32(LPTSettings.CONTROL_REG_ADDR, data)

            initialData = Inp32(LPTSettings.DATA_REG_ADDR)
            currentData = initialData

            t1.Interval = 1
            t1.AutoReset = True
            AddHandler t1.Elapsed, AddressOf PullLPTIn
            t1.Start()
        End Sub

        Private Sub PullLPTIn(ByVal sender As Object, ByVal e As EventArgs)

            Dim newData As Byte = Inp32(LPTSettings.DATA_REG_ADDR)

            If newData <> currentData Then
                Dim cd As Byte = currentData
                ' Maybe some processing will stick, we need to change this immediatelly
                currentData = newData

                If (currentData <> initialData) Then
                    swStart = DateTime.Now
                Else
                    swEnd = DateTime.Now

                    If (swEnd.Subtract(swStart).TotalMilliseconds < 2000) Then
                        Select Case cd Xor newData
                            Case OK_PRESS
                                eventRecieved(ControllerEvt.OK)
                            Case CANCEL_PRESS
                                eventRecieved(ControllerEvt.CANCEL)
                            Case COIN_ACCEPT
                                eventRecieved(ControllerEvt.COIN_ACCEPTED)
                            Case UP_PRESS
                                eventRecieved(ControllerEvt.UP)
                            Case DOWN_PRESS
                                eventRecieved(ControllerEvt.DOWN)
                        End Select
                    Else
                        If (cd Xor newData) = (UP_PRESS Or CANCEL_PRESS) Then
                            eventRecieved(ControllerEvt.A_EXIT)
                        End If
                    End If

                End If
            End If

        End Sub



    End Class

End Namespace