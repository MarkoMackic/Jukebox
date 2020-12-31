Imports System.Configuration
Imports System.IO

Public NotInheritable Class Settings

    Private Shared ReadOnly _instance As New Lazy(Of Settings)(Function() New Settings(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication)

    Shared sMap As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Public Function getVal(ByVal key As String) As String
        If Not sMap.Keys.Contains(key.ToUpper()) Then
            MsgBox("Application reqested setting that doesn't exist " + key.ToUpper())
            Environment.Exit(1)
        End If

        Return sMap.Item(key.ToUpper())
    End Function

    Public Shared ReadOnly Property getInst() As Settings
        Get
            Return _instance.Value
        End Get
    End Property

    Private Sub New()

        For Each prop As SettingsPropertyValue In My.Settings.PropertyValues
            sMap.Add(prop.Name.ToString().ToUpper(), prop.PropertyValue.ToString())
        Next


        If System.IO.File.Exists("resources/cfg.xml") Then
            Dim xmlDoc As XDocument
            Dim fs As New FileStream("resources/cfg.xml", FileMode.Open, FileAccess.Read)
            xmlDoc = XDocument.Load(fs)
            For Each n As XElement In xmlDoc.Elements().First().Elements()

                Dim k As String = n.Name.ToString().ToUpper()
                Dim v As String = n.Value.ToString()

                If sMap.Keys.Contains(k) Then
                    sMap.Item(k) = v
                Else
                    sMap.Add(k, v)
                End If


            Next

        End If

    End Sub

End Class
