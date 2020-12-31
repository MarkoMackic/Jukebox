Imports System.IO


Public Class Storage
    Implements ILevelItem


    Public items As New Dictionary(Of String, SecondLevelItem), selectedIdx As Integer = 0

    Public allSongs As New List(Of String), allSongsIdx As Integer = 0

    Public currentCtx As ILevelItem

    Public Event songSelected(ByVal path As String)

    Private Sub New(ByVal f As String)
        For Each d As String In My.Computer.FileSystem.GetDirectories(f)
            Dim fName As String = Path.GetFileName(d)

            If (items.ContainsKey(fName) = False) Then
                items(fName) = New SecondLevelItem(Me, fName, d, SecondLevelItem.IType.CATEGORY)
            End If

            items(fName).updateWithDirData(d)
        Next

        currentCtx = Me
    End Sub

    Public Shared Function getFromDirectory(ByVal f As String) As Storage
        Return New Storage(f)
    End Function

    Public Function getRandomSong() As String
        If (allSongs.Count = 0) Then
            MsgBox("Nema pjesama")
            Environment.Exit(1)
        End If

        Return allSongs.Item(allSongsIdx)

        allSongsIdx = If(allSongsIdx + 1 > allSongs.Count, 0, allSongsIdx + 1)
    End Function


    Public Sub setSelected(ByVal i As Integer, ByVal val As String) Implements ILevelItem.setSelected
        Me.selectedIdx = i
        Me.items(getItems().Item(selectedIdx)).getComponent().setItems(Me.items(getItems().Item(selectedIdx)).getItems())
    End Sub

    Public Function getComponent() As ListPanel Implements ILevelItem.getComponent
        Return Form1.catList
    End Function

    Public Sub switchToChildView() Implements ILevelItem.switchToChildView
        Me.items(getItems().Item(selectedIdx)).initialize(True)
    End Sub

    Public Sub switchToParentView() Implements ILevelItem.switchToParentView
    End Sub

    Public Function getItems() As System.Collections.Generic.List(Of String) Implements ILevelItem.getItems
        Return New List(Of String)(Me.items.Keys)
    End Function

    Public Sub initialize(ByVal dir As Boolean) Implements ILevelItem.initialize
        If dir Then
            selectedIdx = 0
        End If
        getComponent().setItems(getItems(), selectedIdx)
        Form1.ActiveControl = getComponent()
        setSelected(selectedIdx, getItems().Item(selectedIdx))
        Me.currentCtx = Me
    End Sub

    Public Sub SongOrdered(ByVal path As String)
        RaiseEvent songSelected(path)
    End Sub

    Public Function getParent() As ILevelItem Implements ILevelItem.getParent
        Return Me
    End Function
End Class
