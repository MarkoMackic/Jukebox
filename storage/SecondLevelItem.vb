Imports System.IO

Public Class SecondLevelItem
    Implements ILevelItem

    Private name As String
    Private fPath As String
    Private parent As ILevelItem
    Private root As Storage

    Private type As IType

    Private items As New Dictionary(Of String, SecondLevelItem), selectedIdx As Integer

    Private audioVideoExt() As String = {"*.asf", "*.wma", "*.wmv", "*.wm", "*.asx", "*.wax", "*.wvx", "*.wmx", "*.wpl", "*.dvr-ms", "*.wdm", _
                                         "*.avi", "*.mpg", "*.mpeg", "*.m1v", "*.mp2", "*.mp3", "*.mpa", "*.mpe", "*.m3u", "*.mid", "*.midi", _
                                         "*.rmi", "*.aif", "*.aifc", "*.aiff", "*.au", "*.snd", "*.wav", "*.cda", "*.ivf", "*.wmz", "*.wms", _
                                         "*.mov", "*.m4a", "*.mp4", "*.m4v", "*.mp4v", "*.3g2", "*.3gp2", "*.3gp", "*.3gpp", "*.aac", "*.adt", _
                                         "*.adts", "*.m2ts", "*.flac"}

    Enum IType
        CATEGORY
        GROUP
        SONG
    End Enum

    Public Sub New(ByVal parent As ILevelItem, ByVal name As String, ByVal fPath As String, ByVal type As IType)
        Me.parent = parent
        Me.name = name
        Me.type = type
        Me.fPath = fpath


        Dim tmpParent As ILevelItem = parent

        While (Not TypeOf tmpParent Is Storage)
            tmpParent = tmpParent.getParent()
        End While

        root = CType(tmpParent, Storage)
    End Sub

    Public Sub updateWithDirData(ByVal dir As String)

        If File.Exists(dir) = False And Directory.Exists(dir) = False Then
            Throw New Exception("Path doesn't exist")
        End If

        If (Me.type = IType.CATEGORY) Then
            For Each d As String In My.Computer.FileSystem.GetDirectories(dir)
                Dim fName As String = Path.GetFileName(d)

                If (items.ContainsKey(fName) = False) Then
                    items(fName) = New SecondLevelItem(Me, fName, d, IType.GROUP)
                End If

                items(fName).updateWithDirData(d)
            Next
        ElseIf Me.type = IType.GROUP Then
            For Each d As String In My.Computer.FileSystem.GetFiles(dir, FileIO.SearchOption.SearchAllSubDirectories, audioVideoExt)
                Dim fName As String = Path.GetFileName(d)

                If (items.ContainsKey(fName) = False) Then
                    items(fName) = New SecondLevelItem(Me, fName, d, IType.SONG)
                End If

                items(fName).updateWithDirData(d)
            Next
        ElseIf Me.type = IType.SONG Then
            root.allSongs.Add(fPath)
        End If

    End Sub

    Public Function getName() As String
        Return name
    End Function

    Public Function getComponent() As ListPanel Implements ILevelItem.getComponent
        Return Form1.groupsAndSongsList
    End Function

    Public Sub setSelected(ByVal i As Integer, ByVal val As String) Implements ILevelItem.setSelected
        Me.selectedIdx = i
    End Sub

    Public Function getItems() As System.Collections.Generic.List(Of String) Implements ILevelItem.getItems
        Return New List(Of String)(Me.items.Keys)
    End Function

    Public Sub switchToChildView() Implements ILevelItem.switchToChildView

        If (getItems().Count = 0) Then
            Return
        End If

        Dim child As SecondLevelItem = Me.items(getItems().Item(selectedIdx))

        If (child.type = IType.SONG) Then
            root.SongOrdered(child.fPath)
        Else
            child.initialize(True)
        End If
    End Sub

    Public Sub switchToParentView() Implements ILevelItem.switchToParentView
        parent.initialize(False)
    End Sub

    Public Sub initialize(ByVal dir As Boolean) Implements ILevelItem.initialize
        If dir Then
            Me.selectedIdx = 0
        End If

        getComponent().setItems(getItems(), selectedIdx)
        root.currentCtx = Me
        Form1.ActiveControl = getComponent()
    End Sub

    Public Function getParent() As ILevelItem Implements ILevelItem.getParent
        Return Me.parent
    End Function
End Class
