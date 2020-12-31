Imports JukeBox.Controllers.Controller
Imports System.ComponentModel
Imports System.Drawing.Design

Public Class ListPanel
    Inherits Panel


    Private _items As New List(Of String)
    Private _selectedIdx As Integer = 0
    Private _bkgColor As Color = Color.Blue
    Private _frgColor As Color = Color.White
    Private _shownItemsCount As Integer = 10
    Private _maxItemHeight As Integer = 90
    Private _rectDisplay As Boolean = True
    Private _startFromCenter As Boolean = False
    Private _itemBorderColor As Color = Color.White
    Private _itemBorderWidth As Integer = 3


    Public Event ItemSelected(ByVal idx As Integer, ByVal val As String)
    Public Event ItemsEmptied()

    Sub New()
        InitializeComponent()
        MyBase.SetStyle(ControlStyles.ContainerControl Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)
        AddHandler Me.LostFocus, AddressOf Invalidate
    End Sub

    Public Property ItemBackgroundColor As Color
        Get
            Return Me._bkgColor
        End Get
        Set(ByVal value As Color)
            Me._bkgColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ItemForegroundColor As Color
        Get
            Return Me._frgColor
        End Get
        Set(ByVal value As Color)
            Me._frgColor = value
            Me.Invalidate()
        End Set
    End Property

    <Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(UITypeEditor))> _
    Public Property Items As List(Of String)
        Get
            Return Me._items
        End Get
        Set(ByVal value As List(Of String))



            Me._items = value
            Me._selectedIdx = 0
            If Not value Is Nothing And value.Count > 0 Then
                RaiseEvent ItemSelected(Me._selectedIdx, Me._items(Me._selectedIdx))
            Else
                RaiseEvent ItemsEmptied()
            End If

            Me.Invalidate()
        End Set
    End Property

    Public Property ShownItemsCount As Integer
        Get
            Return Me._shownItemsCount
        End Get
        Set(ByVal value As Integer)
            Me._shownItemsCount = value
            Me.Invalidate()
        End Set
    End Property

    Public Property SelectedIdx As Integer
        Get
            Return Me._selectedIdx
        End Get
        Set(ByVal value As Integer)
            Me._selectedIdx = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ItemBorderWidth As Integer
        Get
            Return Me._itemBorderWidth
        End Get
        Set(ByVal value As Integer)
            Me._itemBorderWidth = value
            Me.Invalidate()
        End Set
    End Property


    Public Property ItemBorderColor As Color
        Get
            Return Me._itemBorderColor
        End Get
        Set(ByVal value As Color)
            Me._itemBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property MaxItemHeight As Integer
        Get
            Return Me._maxItemHeight
        End Get
        Set(ByVal value As Integer)
            Me._maxItemHeight = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ShowItemsFromCenter As Boolean
        Get
            Return Me._startFromCenter
        End Get
        Set(ByVal value As Boolean)
            Me._startFromCenter = value
            Me.Invalidate()
        End Set
    End Property

    Public Property DisplayItemRectangular As Boolean
        Get
            Return Me._rectDisplay
        End Get
        Set(ByVal value As Boolean)
            Me._rectDisplay = value
            Me.Invalidate()
        End Set
    End Property


    Public Sub nextItem()
        If (Me.Items.Count = 0) Then
            Return
        End If
        _selectedIdx = If(_selectedIdx + 1 > _items.Count - 1, 0, _selectedIdx + 1)
        Me.Invalidate()
        RaiseEvent ItemSelected(Me._selectedIdx, Me._items(Me._selectedIdx))
    End Sub

    Public Sub prevItem()
        If (Me.Items.Count = 0) Then
            Return
        End If
        _selectedIdx = If(_selectedIdx - 1 < 0, _items.Count - 1, _selectedIdx - 1)
        Me.Invalidate()
        RaiseEvent ItemSelected(Me._selectedIdx, Me._items(Me._selectedIdx))
    End Sub

    Public Sub setItems(ByVal vals As List(Of String), Optional ByVal idx As Integer = 0, Optional ByVal rEvent As Boolean = False)
        Me._items = vals

        If idx > -1 And idx < Me.Items.Count Then
            Me._selectedIdx = idx
        End If

        Me.Invalidate()

        If (rEvent) Then
            RaiseEvent ItemSelected(Me._selectedIdx, Me._items(Me._selectedIdx))
        End If

    End Sub

    Public Function getCurrentItem() As String
        Return _items(_selectedIdx)
    End Function

    Public Function getCurrentItemIdx() As Integer
        Return _selectedIdx
    End Function

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If (_items Is Nothing Or _items.Count = 0) Then
            MyBase.OnPaint(e)
            Return
        End If

        Dim sf As StringFormat = New StringFormat()
        sf.LineAlignment = StringAlignment.Center
        sf.Alignment = StringAlignment.Center
        sf.Trimming = StringTrimming.Word


        Dim rectSize As Size = New Size(Me.DisplayRectangle.Width, Math.Min(_maxItemHeight, (Me.DisplayRectangle.Height / _shownItemsCount)))
        Dim opacityDecrease As Integer = Math.Ceiling(255.0 / (_shownItemsCount - 1))

        e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        e.Graphics.TranslateTransform(Me.DisplayRectangle.Width / 2, If(Me._startFromCenter, Me.DisplayRectangle.Height / 2, 0))

        Dim centerLoc As Point = New Point(CInt(-Me.DisplayRectangle.Width / 2), If(Me._startFromCenter, CInt(-rectSize.Height / 2), 0))

        Dim clCp As Point = centerLoc

        For i As Integer = _selectedIdx To 0 Step -1
            Dim rct As Rectangle = New Rectangle(clCp, rectSize)
            If (_rectDisplay = False) Then
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(If(255 - (_selectedIdx - i) * opacityDecrease > 0, 255 - (_selectedIdx - i) * opacityDecrease, 0), _bkgColor)), rct)
            Else
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(If(255 - (_selectedIdx - i) * opacityDecrease > 0, 255 - (_selectedIdx - i) * opacityDecrease, 0), _bkgColor)), rct)
            End If

            If i = _selectedIdx And (Me.Focused Or Me.DesignMode) Then
                If (_rectDisplay = False) Then
                    e.Graphics.DrawEllipse(New Pen(_itemBorderColor, _itemBorderWidth), rct)
                Else
                    e.Graphics.DrawRectangle(New Pen(_itemBorderColor, _itemBorderWidth), rct)
                End If
            End If

            e.Graphics.DrawString(_items(i), FindFont(e.Graphics, _items(i), rct.Size), New SolidBrush(Color.FromArgb(If(255 - (_selectedIdx - i) * opacityDecrease > 0, 255 - (_selectedIdx - i) * opacityDecrease, 0), _frgColor)), rct, sf)
            clCp.Offset(0, CInt(-rectSize.Height - 5))
        Next

        clCp = centerLoc

        For i As Integer = _selectedIdx + 1 To _items.Count - 1
            clCp.Offset(0, CInt(rectSize.Height + 5))
            Dim rct As Rectangle = New Rectangle(clCp, rectSize)
            If _rectDisplay = False Then
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(If(255 - (i - _selectedIdx) * opacityDecrease > 0, 255 - (i - _selectedIdx) * opacityDecrease, 0), _bkgColor)), rct)
            Else
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(If(255 - (i - _selectedIdx) * opacityDecrease > 0, 255 - (i - _selectedIdx) * opacityDecrease, 0), _bkgColor)), rct)
            End If

            e.Graphics.DrawString(_items(i), FindFont(e.Graphics, _items(i), rct.Size), New SolidBrush(Color.FromArgb(If(255 - (i - _selectedIdx) * opacityDecrease > 0, 255 - (i - _selectedIdx) * opacityDecrease, 0), _frgColor)), rct, sf)
        Next
    End Sub


    Private Function FindFont(ByVal g As System.Drawing.Graphics, ByVal longString As String, ByVal Room As Size)
        If longString = Nothing Then
            Return Me.Font
        End If
        Dim RealSize As SizeF = g.MeasureString(longString, Me.Font)
        Dim HeightScaleRatio As Single = Room.Height / RealSize.Height
        Dim WidthScaleRatio As Single = Room.Width / RealSize.Width

        If (HeightScaleRatio < WidthScaleRatio) Then
            Return New Font(Me.Font.Name, Me.Font.Size * HeightScaleRatio, GraphicsUnit.Pixel)
        Else
            Return New Font(Me.Font.Name, Me.Font.Size * WidthScaleRatio, GraphicsUnit.Pixel)
        End If
    End Function

    Protected Shadows Sub [Select](ByVal directed As Boolean, ByVal forward As Boolean)
        MyBase.[Select](directed, forward)
        Me.Invalidate()
    End Sub

    Public Shadows Sub [Select]()
        MyBase.[Select]()
        Me.Invalidate()
    End Sub

End Class
