Public Class ListUtils

    Public Shared Function Shuffle(Of T)(ByVal collection As IEnumerable(Of T)) As List(Of T)
        Dim r As Random = New Random()
        Shuffle = collection.OrderBy(Function(a) r.Next()).ToList()
    End Function

End Class
