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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCredit = New System.Windows.Forms.Label()
        Me.wmp = New AxWMPLib.AxWindowsMediaPlayer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCurrentAction = New System.Windows.Forms.Label()
        Me.lblSongTime = New System.Windows.Forms.Label()
        Me.DbPanel1 = New JukeBox.DBPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.wmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.96317!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.03683!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblCredit, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.wmp, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DbPanel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(733, 450)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblCredit
        '
        Me.lblCredit.AutoEllipsis = True
        Me.lblCredit.BackColor = System.Drawing.Color.Transparent
        Me.lblCredit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredit.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblCredit.Location = New System.Drawing.Point(3, 391)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.Size = New System.Drawing.Size(133, 59)
        Me.lblCredit.TabIndex = 0
        Me.lblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'wmp
        '
        Me.wmp.Enabled = True
        Me.wmp.Location = New System.Drawing.Point(142, 3)
        Me.wmp.Name = "wmp"
        Me.wmp.OcxState = CType(resources.GetObject("wmp.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmp.Size = New System.Drawing.Size(41, 31)
        Me.wmp.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblCurrentAction, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSongTime, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(142, 391)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(588, 59)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'lblCurrentAction
        '
        Me.lblCurrentAction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCurrentAction.Font = New System.Drawing.Font("Broadway", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentAction.ForeColor = System.Drawing.Color.Orange
        Me.lblCurrentAction.Location = New System.Drawing.Point(3, 0)
        Me.lblCurrentAction.Name = "lblCurrentAction"
        Me.lblCurrentAction.Size = New System.Drawing.Size(482, 59)
        Me.lblCurrentAction.TabIndex = 1
        Me.lblCurrentAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSongTime
        '
        Me.lblSongTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSongTime.Font = New System.Drawing.Font("Broadway", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSongTime.ForeColor = System.Drawing.Color.Moccasin
        Me.lblSongTime.Location = New System.Drawing.Point(491, 0)
        Me.lblSongTime.Name = "lblSongTime"
        Me.lblSongTime.Size = New System.Drawing.Size(94, 59)
        Me.lblSongTime.TabIndex = 0
        Me.lblSongTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DbPanel1
        '
        Me.DbPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DbPanel1.Location = New System.Drawing.Point(3, 3)
        Me.DbPanel1.Name = "DbPanel1"
        Me.DbPanel1.Size = New System.Drawing.Size(133, 385)
        Me.DbPanel1.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(733, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Name = "Form1"
        Me.Text = "Main"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.wmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents wmp As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCurrentAction As System.Windows.Forms.Label
    Friend WithEvents lblSongTime As System.Windows.Forms.Label
    Friend WithEvents DbPanel1 As JukeBox.DBPanel

End Class
