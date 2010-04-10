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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PostBut = New System.Windows.Forms.Button
        Me.ScrobbleBut = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Message = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MediaTitle = New System.Windows.Forms.TextBox
        Me.mediatype = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Segment = New System.Windows.Forms.TextBox
        Me.DetectBut = New System.Windows.Forms.Button
        Me.CompleteCheckbox = New System.Windows.Forms.CheckBox
        Me.Status = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ArtistName = New System.Windows.Forms.TextBox
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowHideScrobbleWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitMelScrobbleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PostBut
        '
        Me.PostBut.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PostBut.Location = New System.Drawing.Point(333, 148)
        Me.PostBut.Name = "PostBut"
        Me.PostBut.Size = New System.Drawing.Size(75, 23)
        Me.PostBut.TabIndex = 0
        Me.PostBut.Text = "Post"
        Me.PostBut.UseVisualStyleBackColor = True
        '
        'ScrobbleBut
        '
        Me.ScrobbleBut.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrobbleBut.Location = New System.Drawing.Point(252, 148)
        Me.ScrobbleBut.Name = "ScrobbleBut"
        Me.ScrobbleBut.Size = New System.Drawing.Size(75, 23)
        Me.ScrobbleBut.TabIndex = 1
        Me.ScrobbleBut.Text = "Scrobble"
        Me.ScrobbleBut.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Message:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Message
        '
        Me.Message.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Message.Location = New System.Drawing.Point(78, 15)
        Me.Message.Multiline = True
        Me.Message.Name = "Message"
        Me.Message.Size = New System.Drawing.Size(304, 44)
        Me.Message.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Media:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MediaTitle
        '
        Me.MediaTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MediaTitle.Location = New System.Drawing.Point(78, 66)
        Me.MediaTitle.Name = "MediaTitle"
        Me.MediaTitle.Size = New System.Drawing.Size(145, 21)
        Me.MediaTitle.TabIndex = 5
        '
        'mediatype
        '
        Me.mediatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.mediatype.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mediatype.FormattingEnabled = True
        Me.mediatype.Items.AddRange(New Object() {"Anime", "Music"})
        Me.mediatype.Location = New System.Drawing.Point(229, 66)
        Me.mediatype.Name = "mediatype"
        Me.mediatype.Size = New System.Drawing.Size(83, 21)
        Me.mediatype.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Segment:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Segment
        '
        Me.Segment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Segment.Location = New System.Drawing.Point(78, 93)
        Me.Segment.Name = "Segment"
        Me.Segment.Size = New System.Drawing.Size(304, 21)
        Me.Segment.TabIndex = 8
        '
        'DetectBut
        '
        Me.DetectBut.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetectBut.Location = New System.Drawing.Point(319, 65)
        Me.DetectBut.Name = "DetectBut"
        Me.DetectBut.Size = New System.Drawing.Size(63, 20)
        Me.DetectBut.TabIndex = 9
        Me.DetectBut.Text = "Detect"
        Me.DetectBut.UseVisualStyleBackColor = True
        '
        'CompleteCheckbox
        '
        Me.CompleteCheckbox.AutoSize = True
        Me.CompleteCheckbox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompleteCheckbox.Location = New System.Drawing.Point(312, 122)
        Me.CompleteCheckbox.Name = "CompleteCheckbox"
        Me.CompleteCheckbox.Size = New System.Drawing.Size(71, 17)
        Me.CompleteCheckbox.TabIndex = 10
        Me.CompleteCheckbox.Text = "Complete"
        Me.CompleteCheckbox.UseVisualStyleBackColor = True
        '
        'Status
        '
        Me.Status.AutoSize = True
        Me.Status.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status.Location = New System.Drawing.Point(11, 153)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(0, 13)
        Me.Status.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(39, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Artist:"
        '
        'ArtistName
        '
        Me.ArtistName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArtistName.Location = New System.Drawing.Point(78, 121)
        Me.ArtistName.Name = "ArtistName"
        Me.ArtistName.Size = New System.Drawing.Size(218, 21)
        Me.ArtistName.TabIndex = 14
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
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowHideScrobbleWindowToolStripMenuItem, Me.ToolStripMenuItem1, Me.SettingsToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitMelScrobbleToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(230, 82)
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 184)
        Me.Controls.Add(Me.ArtistName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.CompleteCheckbox)
        Me.Controls.Add(Me.DetectBut)
        Me.Controls.Add(Me.Segment)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.mediatype)
        Me.Controls.Add(Me.MediaTitle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Message)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ScrobbleBut)
        Me.Controls.Add(Me.PostBut)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "MelScrobble"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PostBut As System.Windows.Forms.Button
    Friend WithEvents ScrobbleBut As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Message As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MediaTitle As System.Windows.Forms.TextBox
    Friend WithEvents mediatype As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Segment As System.Windows.Forms.TextBox
    Friend WithEvents DetectBut As System.Windows.Forms.Button
    Friend WithEvents CompleteCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents Status As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ArtistName As System.Windows.Forms.TextBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowHideScrobbleWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitMelScrobbleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
