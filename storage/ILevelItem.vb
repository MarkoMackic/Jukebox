Public Interface ILevelItem

    Sub switchToChildView()
    Sub switchToParentView()
    Sub initialize(ByVal dir As Boolean)

    Sub setSelected(ByVal i As Integer, ByVal val As String)

    Function getComponent() As ListPanel

    Function getItems() As List(Of String)

    Function getParent() As ILevelItem


End Interface
