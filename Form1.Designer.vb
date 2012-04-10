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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Message = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UploadImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearFields = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MediaTitle = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Segment = New System.Windows.Forms.TextBox()
        Me.CompleteCheckbox = New System.Windows.Forms.CheckBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AboutMelScrobbleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShowHideScrobbleWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.EnableScrobblingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitMelScrobbleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Scrobble = New System.Windows.Forms.Timer(Me.components)
        Me.SendtoTwitter = New System.Windows.Forms.CheckBox()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.DetectBut = New System.Windows.Forms.ToolStripButton()
        Me.UploadImageBut = New System.Windows.Forms.ToolStripButton()
        Me.MediaType = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UpdateBut = New System.Windows.Forms.ToolStripButton()
        Me.SendBut = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Message:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Message
        '
        Me.Message.ContextMenuStrip = Me.ContextMenuStrip2
        Me.Message.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Message.Location = New System.Drawing.Point(74, 106)
        Me.Message.Multiline = True
        Me.Message.Name = "Message"
        Me.Message.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.Message.Size = New System.Drawing.Size(304, 44)
        Me.Message.TabIndex = 3
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadImageToolStripMenuItem, Me.ToolStripSeparator2, Me.ClearFields})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(149, 54)
        '
        'UploadImageToolStripMenuItem
        '
        Me.UploadImageToolStripMenuItem.Name = "UploadImageToolStripMenuItem"
        Me.UploadImageToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.UploadImageToolStripMenuItem.Text = "Upload Image"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(145, 6)
        '
        'ClearFields
        '
        Me.ClearFields.Name = "ClearFields"
        Me.ClearFields.Size = New System.Drawing.Size(148, 22)
        Me.ClearFields.Text = "Clear all Fields"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Media:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MediaTitle
        '
        Me.MediaTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MediaTitle.Location = New System.Drawing.Point(74, 51)
        Me.MediaTitle.Name = "MediaTitle"
        Me.MediaTitle.Size = New System.Drawing.Size(304, 22)
        Me.MediaTitle.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Segment:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Segment
        '
        Me.Segment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Segment.Location = New System.Drawing.Point(74, 78)
        Me.Segment.Name = "Segment"
        Me.Segment.Size = New System.Drawing.Size(304, 22)
        Me.Segment.TabIndex = 8
        '
        'CompleteCheckbox
        '
        Me.CompleteCheckbox.AutoSize = True
        Me.CompleteCheckbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompleteCheckbox.Location = New System.Drawing.Point(308, 156)
        Me.CompleteCheckbox.Name = "CompleteCheckbox"
        Me.CompleteCheckbox.Size = New System.Drawing.Size(85, 20)
        Me.CompleteCheckbox.TabIndex = 10
        Me.CompleteCheckbox.Text = "Complete"
        Me.CompleteCheckbox.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "MelScrobble"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.SystemColors.Menu
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutMelScrobbleToolStripMenuItem, Me.CheckForUpdatesToolStripMenuItem, Me.ToolStripMenuItem3, Me.ShowHideScrobbleWindowToolStripMenuItem, Me.ToolStripMenuItem1, Me.SettingsToolStripMenuItem, Me.ToolStripMenuItem4, Me.EnableScrobblingToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitMelScrobbleToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.ShowCheckMargin = True
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(230, 160)
        '
        'AboutMelScrobbleToolStripMenuItem
        '
        Me.AboutMelScrobbleToolStripMenuItem.Name = "AboutMelScrobbleToolStripMenuItem"
        Me.AboutMelScrobbleToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.AboutMelScrobbleToolStripMenuItem.Text = "About MelScrobble"
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.CheckForUpdatesToolStripMenuItem.Text = "Check for Updates..."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(226, 6)
        '
        'ShowHideScrobbleWindowToolStripMenuItem
        '
        Me.ShowHideScrobbleWindowToolStripMenuItem.Name = "ShowHideScrobbleWindowToolStripMenuItem"
        Me.ShowHideScrobbleWindowToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ShowHideScrobbleWindowToolStripMenuItem.Text = "Show/Hide Scrobble Window"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(226, 6)
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(226, 6)
        '
        'EnableScrobblingToolStripMenuItem
        '
        Me.EnableScrobblingToolStripMenuItem.Name = "EnableScrobblingToolStripMenuItem"
        Me.EnableScrobblingToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.EnableScrobblingToolStripMenuItem.Text = "Enable Scrobbling"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(226, 6)
        '
        'ExitMelScrobbleToolStripMenuItem
        '
        Me.ExitMelScrobbleToolStripMenuItem.Name = "ExitMelScrobbleToolStripMenuItem"
        Me.ExitMelScrobbleToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ExitMelScrobbleToolStripMenuItem.Text = "E&xit MelScrobble"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'Scrobble
        '
        Me.Scrobble.Interval = 180000
        '
        'SendtoTwitter
        '
        Me.SendtoTwitter.AutoSize = True
        Me.SendtoTwitter.Location = New System.Drawing.Point(74, 156)
        Me.SendtoTwitter.Name = "SendtoTwitter"
        Me.SendtoTwitter.Size = New System.Drawing.Size(98, 17)
        Me.SendtoTwitter.TabIndex = 15
        Me.SendtoTwitter.Text = "Send to Twitter"
        Me.SendtoTwitter.UseVisualStyleBackColor = True
        '
        'ToolTips
        '
        Me.ToolTips.AutoPopDelay = 5000
        Me.ToolTips.InitialDelay = 700
        Me.ToolTips.ReshowDelay = 100
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetectBut, Me.UploadImageBut, Me.MediaType, Me.ToolStripSeparator1, Me.UpdateBut, Me.SendBut})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(390, 45)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "Main"
        '
        'DetectBut
        '
        Me.DetectBut.Image = CType(resources.GetObject("DetectBut.Image"), System.Drawing.Image)
        Me.DetectBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DetectBut.Name = "DetectBut"
        Me.DetectBut.Size = New System.Drawing.Size(45, 42)
        Me.DetectBut.Text = "Detect"
        Me.DetectBut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'UploadImageBut
        '
        Me.UploadImageBut.Image = CType(resources.GetObject("UploadImageBut.Image"), System.Drawing.Image)
        Me.UploadImageBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UploadImageBut.Name = "UploadImageBut"
        Me.UploadImageBut.Size = New System.Drawing.Size(85, 42)
        Me.UploadImageBut.Text = "Upload Image"
        Me.UploadImageBut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MediaType
        '
        Me.MediaType.Items.AddRange(New Object() {"Anime", "Music", "Adrama"})
        Me.MediaType.Name = "MediaType"
        Me.MediaType.Size = New System.Drawing.Size(121, 45)
        Me.MediaType.ToolTipText = "Media Type"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 45)
        '
        'UpdateBut
        '
        Me.UpdateBut.Image = CType(resources.GetObject("UpdateBut.Image"), System.Drawing.Image)
        Me.UpdateBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UpdateBut.Name = "UpdateBut"
        Me.UpdateBut.Size = New System.Drawing.Size(49, 42)
        Me.UpdateBut.Text = "Update"
        Me.UpdateBut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SendBut
        '
        Me.SendBut.Image = CType(resources.GetObject("SendBut.Image"), System.Drawing.Image)
        Me.SendBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SendBut.Name = "SendBut"
        Me.SendBut.Size = New System.Drawing.Size(34, 42)
        Me.SendBut.Text = "Post"
        Me.SendBut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 181)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(390, 22)
        Me.StatusStrip1.TabIndex = 17
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Status
        '
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(0, 17)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 203)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.SendtoTwitter)
        Me.Controls.Add(Me.CompleteCheckbox)
        Me.Controls.Add(Me.Message)
        Me.Controls.Add(Me.Segment)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MediaTitle)
        Me.Controls.Add(Me.Label2)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.WindowsApplication1.My.MySettings.Default, "WindowPosition", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = Global.WindowsApplication1.My.MySettings.Default.WindowPosition
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "MelScrobble"
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Message As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MediaTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Segment As System.Windows.Forms.TextBox
    Friend WithEvents CompleteCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowHideScrobbleWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitMelScrobbleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents AboutMelScrobbleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents Scrobble As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EnableScrobblingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendtoTwitter As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UploadImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckForUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DetectBut As System.Windows.Forms.ToolStripButton
    Friend WithEvents UploadImageBut As System.Windows.Forms.ToolStripButton
    Friend WithEvents MediaType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UpdateBut As System.Windows.Forms.ToolStripButton
    Friend WithEvents SendBut As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearFields As System.Windows.Forms.ToolStripMenuItem

End Class
