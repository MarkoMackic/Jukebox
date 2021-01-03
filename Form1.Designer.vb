<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TableLayoutPanel1 = New JukeBox.TblLayoutPanel()
        Me.lblCredit = New System.Windows.Forms.Label()
        Me.catList = New JukeBox.ListPanel()
        Me.wmp = New AxWMPLib.AxWindowsMediaPlayer()
        Me.lblSongTime = New System.Windows.Forms.Label()
        Me.lblCurrentAction = New System.Windows.Forms.Label()
        Me.groupsAndSongsList = New JukeBox.ListPanel()
        Me.gbOrder = New JukeBox.DBGroupBox()
        Me.orderedList = New JukeBox.ListPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.catList.SuspendLayout()
        CType(Me.wmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.gbOrder, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCredit, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.catList, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSongTime, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCurrentAction, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.groupsAndSongsList, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(920, 578)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblCredit
        '
        Me.lblCredit.BackColor = System.Drawing.Color.Transparent
        Me.lblCredit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredit.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblCredit.Location = New System.Drawing.Point(4, 518)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.Size = New System.Drawing.Size(131, 59)
        Me.lblCredit.TabIndex = 0
        Me.lblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'catList
        '
        Me.catList.BackColor = System.Drawing.Color.Transparent
        Me.catList.Controls.Add(Me.wmp)
        Me.catList.DisplayItemRectangular = False
        Me.catList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.catList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.catList.ItemBackgroundColor = System.Drawing.Color.SaddleBrown
        Me.catList.ItemBorderColor = System.Drawing.Color.White
        Me.catList.ItemBorderWidth = 3
        Me.catList.ItemForegroundColor = System.Drawing.Color.White
        Me.catList.Items = CType(resources.GetObject("catList.Items"), System.Collections.Generic.List(Of String))
        Me.catList.Location = New System.Drawing.Point(4, 4)
        Me.catList.MaxItemHeight = 90
        Me.catList.Name = "catList"
        Me.catList.SelectedIdx = 0
        Me.catList.ShowItemsFromCenter = True
        Me.catList.ShownItemsCount = 8
        Me.catList.Size = New System.Drawing.Size(131, 510)
        Me.catList.TabIndex = 3
        '
        'wmp
        '
        Me.wmp.Enabled = True
        Me.wmp.Location = New System.Drawing.Point(53, 30)
        Me.wmp.Name = "wmp"
        Me.wmp.OcxState = CType(resources.GetObject("wmp.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmp.Size = New System.Drawing.Size(75, 23)
        Me.wmp.TabIndex = 0
        '
        'lblSongTime
        '
        Me.lblSongTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSongTime.Font = New System.Drawing.Font("Broadway", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSongTime.ForeColor = System.Drawing.Color.Moccasin
        Me.lblSongTime.Location = New System.Drawing.Point(601, 518)
        Me.lblSongTime.Name = "lblSongTime"
        Me.lblSongTime.Size = New System.Drawing.Size(315, 59)
        Me.lblSongTime.TabIndex = 4
        Me.lblSongTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentAction
        '
        Me.lblCurrentAction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCurrentAction.Font = New System.Drawing.Font("Broadway", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentAction.ForeColor = System.Drawing.Color.Moccasin
        Me.lblCurrentAction.Location = New System.Drawing.Point(142, 518)
        Me.lblCurrentAction.Name = "lblCurrentAction"
        Me.lblCurrentAction.Size = New System.Drawing.Size(452, 59)
        Me.lblCurrentAction.TabIndex = 5
        Me.lblCurrentAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'groupsAndSongsList
        '
        Me.groupsAndSongsList.DisplayItemRectangular = True
        Me.groupsAndSongsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupsAndSongsList.ItemBackgroundColor = System.Drawing.Color.DarkBlue
        Me.groupsAndSongsList.ItemBorderColor = System.Drawing.Color.Lime
        Me.groupsAndSongsList.ItemBorderWidth = 3
        Me.groupsAndSongsList.ItemForegroundColor = System.Drawing.Color.White
        Me.groupsAndSongsList.Items = CType(resources.GetObject("groupsAndSongsList.Items"), System.Collections.Generic.List(Of String))
        Me.groupsAndSongsList.Location = New System.Drawing.Point(149, 11)
        Me.groupsAndSongsList.Margin = New System.Windows.Forms.Padding(10)
        Me.groupsAndSongsList.MaxItemHeight = 90
        Me.groupsAndSongsList.Name = "groupsAndSongsList"
        Me.groupsAndSongsList.SelectedIdx = 0
        Me.groupsAndSongsList.ShowItemsFromCenter = True
        Me.groupsAndSongsList.ShownItemsCount = 20
        Me.groupsAndSongsList.Size = New System.Drawing.Size(438, 496)
        Me.groupsAndSongsList.TabIndex = 6
        '
        'gbOrder
        '
        Me.gbOrder.Controls.Add(Me.orderedList)
        Me.gbOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrder.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.gbOrder.Location = New System.Drawing.Point(601, 4)
        Me.gbOrder.Name = "gbOrder"
        Me.gbOrder.Size = New System.Drawing.Size(315, 510)
        Me.gbOrder.TabIndex = 7
        Me.gbOrder.TabStop = False
        Me.gbOrder.Text = "Naručene"
        '
        'orderedList
        '
        Me.orderedList.DisplayItemRectangular = True
        Me.orderedList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.orderedList.ItemBackgroundColor = System.Drawing.Color.Teal
        Me.orderedList.ItemBorderColor = System.Drawing.Color.Lime
        Me.orderedList.ItemBorderWidth = 3
        Me.orderedList.ItemForegroundColor = System.Drawing.Color.WhiteSmoke
        Me.orderedList.Items = CType(resources.GetObject("orderedList.Items"), System.Collections.Generic.List(Of String))
        Me.orderedList.Location = New System.Drawing.Point(3, 27)
        Me.orderedList.Margin = New System.Windows.Forms.Padding(10)
        Me.orderedList.MaxItemHeight = 90
        Me.orderedList.Name = "orderedList"
        Me.orderedList.SelectedIdx = 0
        Me.orderedList.ShowItemsFromCenter = False
        Me.orderedList.ShownItemsCount = 20
        Me.orderedList.Size = New System.Drawing.Size(309, 480)
        Me.orderedList.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(920, 578)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Name = "Form1"
        Me.Text = "Main"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.catList.ResumeLayout(False)
        CType(Me.wmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrder.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents catList As JukeBox.ListPanel
    Friend WithEvents lblSongTime As System.Windows.Forms.Label
    Friend WithEvents lblCurrentAction As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As JukeBox.TblLayoutPanel
    Friend WithEvents groupsAndSongsList As JukeBox.ListPanel
    Friend WithEvents wmp As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents gbOrder As JukeBox.DBGroupBox
    Friend WithEvents orderedList As JukeBox.ListPanel

End Class
