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
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'PostBut
        '
        Me.PostBut.Location = New System.Drawing.Point(334, 129)
        Me.PostBut.Name = "PostBut"
        Me.PostBut.Size = New System.Drawing.Size(75, 23)
        Me.PostBut.TabIndex = 0
        Me.PostBut.Text = "Post"
        Me.PostBut.UseVisualStyleBackColor = True
        '
        'ScrobbleBut
        '
        Me.ScrobbleBut.Location = New System.Drawing.Point(253, 129)
        Me.ScrobbleBut.Name = "ScrobbleBut"
        Me.ScrobbleBut.Size = New System.Drawing.Size(75, 23)
        Me.ScrobbleBut.TabIndex = 1
        Me.ScrobbleBut.Text = "Scrobble"
        Me.ScrobbleBut.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Message:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Message
        '
        Me.Message.Location = New System.Drawing.Point(78, 15)
        Me.Message.Multiline = True
        Me.Message.Name = "Message"
        Me.Message.Size = New System.Drawing.Size(304, 44)
        Me.Message.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Title:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MediaTitle
        '
        Me.MediaTitle.Location = New System.Drawing.Point(78, 66)
        Me.MediaTitle.Name = "MediaTitle"
        Me.MediaTitle.Size = New System.Drawing.Size(145, 20)
        Me.MediaTitle.TabIndex = 5
        '
        'mediatype
        '
        Me.mediatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
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
        Me.Label3.Location = New System.Drawing.Point(20, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Segment:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Segment
        '
        Me.Segment.Location = New System.Drawing.Point(78, 96)
        Me.Segment.Name = "Segment"
        Me.Segment.Size = New System.Drawing.Size(145, 20)
        Me.Segment.TabIndex = 8
        '
        'DetectBut
        '
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
        Me.CompleteCheckbox.Location = New System.Drawing.Point(230, 98)
        Me.CompleteCheckbox.Name = "CompleteCheckbox"
        Me.CompleteCheckbox.Size = New System.Drawing.Size(70, 17)
        Me.CompleteCheckbox.TabIndex = 10
        Me.CompleteCheckbox.Text = "Complete"
        Me.CompleteCheckbox.UseVisualStyleBackColor = True
        '
        'Status
        '
        Me.Status.AutoSize = True
        Me.Status.Location = New System.Drawing.Point(12, 134)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(0, 13)
        Me.Status.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(183, 129)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 24)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Settings"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 162)
        Me.Controls.Add(Me.Button1)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "MelScrobble"
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
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
