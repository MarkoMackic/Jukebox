Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Xml

Module LPTDll

    Public Class LPTSettings
        Public Shared CONTROL_REG_ADDR As Short = Convert.ToInt16(My.Settings.LPT_CONTROL_ADDR, 16)
        Public Shared DATA_REG_ADDR As Short = Convert.ToInt16(My.Settings.LPT_DATA_ADDR, 16)

        Shared Sub New()
            If System.IO.File.Exists("resources/lpt_cfg.xml") Then
                Dim xmlDoc As XDocument
                Dim fs As New FileStream("resources/lpt_cfg.xml", FileMode.Open, FileAccess.Read)
                xmlDoc = XDocument.Load(fs)

                If xmlDoc.Descendants("lpt_data_addr").Count = 1 Then
                    DATA_REG_ADDR = Convert.ToInt16(xmlDoc.Descendants("lpt_data_addr").Single().Value, 16)
                End If


                If xmlDoc.Descendants("lpt_control_addr").Count = 1 Then
                    DATA_REG_ADDR = Convert.ToInt16(xmlDoc.Descendants("lpt_control_addr").Single().Value, 16)
                End If

                MsgBox(My.Settings.Properties.Count)
            End If
        End Sub
    End Class

    <DllImport("resources/inpout32.dll", CharSet:=CharSet.Auto, EntryPoint:="Inp32")> _
    Public Function Inp32(ByVal PortAddress As Short) As Short
    End Function

    <DllImport("resources/inpout32.dll", CharSet:=CharSet.Auto, EntryPoint:="Out32")> _
    Public Sub Out32(ByVal PortAddress As Short, ByVal Data As Short)
    End Sub

End Module
