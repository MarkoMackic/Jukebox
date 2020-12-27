Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Xml

Module LPTDll

    Public Class LPTSettings
        Public Shared CONTROL_REG_ADDR As Short = Convert.ToInt16(Settings.getInst().getVal("LPT_CONTROL_ADDR"), 16)
        Public Shared DATA_REG_ADDR As Short = Convert.ToInt16(Settings.getInst().getVal("LPT_DATA_ADDR"), 16)
    End Class

    <DllImport("resources/inpout32.dll", CharSet:=CharSet.Auto, EntryPoint:="Inp32")> _
    Public Function Inp32(ByVal PortAddress As Short) As Short
    End Function

    <DllImport("resources/inpout32.dll", CharSet:=CharSet.Auto, EntryPoint:="Out32")> _
    Public Sub Out32(ByVal PortAddress As Short, ByVal Data As Short)
    End Sub

End Module
