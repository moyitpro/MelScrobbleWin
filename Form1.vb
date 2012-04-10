Imports System
Imports System.Management
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.IO
Imports System.Web
Imports Growl.Connector

Public Class Form1
    Dim WithEvents growl As GrowlConnector
    Dim nt As NotificationType = New NotificationType("Message", "Message")
    Dim app As Growl.Connector.Application
    Dim melclient As New Melative
    Private scrobbleenabled As Boolean

    Private Property sucess As Object

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dialog1.ShowDialog()
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Settings.Mediatype = mediatype.SelectedIndex
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ExitMelScrobbleToolStripMenuItem.Checked = False Then
            e.Cancel = True
            Me.Hide()
            NotifyIcon1.ShowBalloonTip(30000, "MelScrobble is still running!", "MelScrobble will still run even if the scrobble window is closed.", ToolTipIcon.Info)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set Fonts
        SetFonts()
        'Set the tooltips
        SetToolTips()
        'winsparkle
        WinSparkle.win_sparkle_set_appcast_url("http://chikorita157.com/updates/melscrobblewin.xml")
        WinSparkle.win_sparkle_init()
    End Sub

    Private Sub SetFonts()
        Dim sys As Font = SystemFonts.DialogFont
        Label1.Font = sys
        Label2.Font = sys
        Label3.Font = sys
        Status.Font = sys
        Message.Font = sys
        MediaTitle.Font = sys
        mediatype.Font = sys
        mediatype.Font = sys
        Segment.Font = sys
        CompleteCheckbox.Font = sys
        DetectBut.Font = sys
        SendtoTwitter.Font = sys
    End Sub

    Private Sub ShowHideScrobbleWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHideScrobbleWindowToolStripMenuItem.Click
        If Me.Visible = False Then
            Me.Show()
        Else
            Me.Hide()
        End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        Dialog1.ShowDialog()
    End Sub

    Private Sub ExitMelScrobbleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitMelScrobbleToolStripMenuItem.Click
        ExitMelScrobbleToolStripMenuItem.Checked = True
        End
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Set Mediatype
        mediatype.SelectedIndex = My.Settings.Mediatype
        'Set Fonts
        SetFonts()
        'Set up Growl Notifications
        Me.app = New Growl.Connector.Application("MelScrobbleX")
        Me.app.Icon = My.Resources.MelScrobbleIcon
        Me.growl = New GrowlConnector()
        Dim types() As NotificationType = New NotificationType() {Me.nt}
        Me.growl.Register(Me.app, types)
        If My.Settings.ScrobbleAtStartup = False Then
            Me.Hide()
            Timer1.Enabled = False
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub AboutMelScrobbleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutMelScrobbleToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub EnableScrobblingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableScrobblingToolStripMenuItem.Click
        If EnableScrobblingToolStripMenuItem.Checked = False Then
            scrobbleenabled = True
            SendGrowlMessage("MelScrobble", "Auto Scrobble is now turned on")
        Else
            scrobbleenabled = False
            SendGrowlMessage("MelScrobble", "Auto Scrobble is now turned off")
        End If
        EnableScrobblingToolStripMenuItem.Checked = scrobbleenabled
        Scrobble.Enabled = scrobbleenabled
    End Sub

    Private Sub Scrobble_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Scrobble.Tick
        Dim success As Boolean
        sucess = melclient.DetectMedia(MediaType.SelectedIndex)
        If success = True Then
            MediaTitle.Text = melclient.getMedia
            Segment.Text = melclient.getSegment
            If melclient.getScrobbleSuccess = True & MediaTitle.Text = melclient.getscrobbledmediatitle & Segment.Text = melclient.getscrobbledmediaSegment Then
            Else
                Dim httpcode As Integer
                httpcode = melclient.Scrobble(MediaTitle.Text, Segment.Text, MediaType.SelectedIndex)
                Select Case httpcode
                    Case 200
                        melclient.setScrobbleSucess(True)
                        Status.Text = "Scrobble Successful."
                        SendGrowlMessage("Scrobble Successful!", melclient.getscrobbledmediatitle & " - " & melclient.getscrobbledmediaSegment)
                        NotifyIcon1.Text = "MelScrobble - Last Scrobbled: " & melclient.getscrobbledmediatitle & " - " & melclient.getscrobbledmediaSegment
                    Case 500
                        melclient.setScrobbleSucess(False)
                        Status.Text = "Scrobble Failed."
                        SendGrowlMessage("Scrobble Unsuccessful!", "Check your login token or internet connection and try again.")
                End Select
            End If
        End If   
    End Sub
    Public Sub SendGrowlMessage(ByVal Title As String, ByVal Message As String)
        If growl.IsGrowlRunning = True Then
            Dim n As New Notification(Me.app.Name, Me.nt.Name, DateTime.Now.Ticks.ToString(), Title, Message)
            growl.Notify(n)
        Else
            If My.Settings.BalloonFallback = True Then
                NotifyIcon1.ShowBalloonTip(30000, Title, Message, ToolTipIcon.Info)
            End If
        End If
    End Sub
    Public Sub SetToolTips()
        ToolTips.SetToolTip(Message, "Specify a message here. No message is required if Media Title and Segment fields are filled. Not used for Scrobble.")
        '       ToolTips.SetToolTip(mediatype, "Selects the Media Type to use in your update or scrobble with.")
        ToolTips.SetToolTip(MediaTitle, "The title of the media.")
        ToolTips.SetToolTip(Segment, "The segment of the media (e.g.: Episode or Track).")
        ToolTips.SetToolTip(CompleteCheckbox, "Check this if you completed with the segment/media.")
        ToolTips.SetToolTip(SendtoTwitter, "Appends @tw to your message and sends this update to Twitter." & vbCrLf & "The Twitter Bridge must be enabled to use this feature")
        'ToolTips.SetToolTip(ArtistName, "The artist name. Used only with the Music mediatype.")
        '        ToolTips.SetToolTip(ScrobbleBut, "Silently update the current media title and segment")
        '       ToolTips.SetToolTip(PostBut, "Posts the update.")
    End Sub

    Private Sub UploadImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadImageToolStripMenuItem.Click
        uploadImage()
    End Sub
    Public Sub uploadImage()
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "Image Files (*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim IUploader As New ImgurUploader
            Dim ImageURL As String
            ImageURL = IUploader.UploadToImgur(openFileDialog1.FileName)
            If ImageURL.Length > 0 Then
                Message.Text = "#image " + ImageURL + vbNewLine + Message.Text
            Else
                MsgBox("Upload Failed " + vbNewLine + vbNewLine + "Unable to upload the selected picture. Check your Internet Connection and try again.")
            End If
        End If
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        WinSparkle.win_sparkle_check_update_with_ui()
    End Sub

    Private Sub ToolStripComboBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaType.Click

    End Sub

    Private Sub DetectBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetectBut.Click
        Dim success As Boolean
        success = melclient.DetectMedia(MediaType.SelectedIndex)
        If success = True Then
            MediaTitle.Text = melclient.getMedia
            Segment.Text = melclient.getSegment
            Status.Text = "Detected playing Media"
        Else
            Status.Text = "Nothing is playing..."
        End If
    End Sub

    Private Sub UploadImageBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadImageBut.Click
        uploadImage()
    End Sub

    Private Sub UpdateBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateBut.Click
        If MediaTitle.TextLength = 0 Or Segment.TextLength = 0 Then
            MsgBox("You must enter a media title and a segment to scrobble this title.", MsgBoxStyle.Exclamation)
            Status.Text = "No Title/Segment Entered."
        Else
            Status.Text = "Scrobbling Title..."
            Dim httpcode As Integer
            httpcode = melclient.Scrobble(MediaTitle.Text, Segment.Text, MediaType.SelectedIndex)
            Select Case httpcode
                Case 200
                    ' Get response  
                    If My.Settings.RequestOutPut = True Then
                        MsgBox("Scrobble Successful" + vbCrLf + vbCrLf + melclient.getResponseData, MsgBoxStyle.Information)
                    End If
                    Status.Text = "Scrobble Successful."
                Case 500
                    MsgBox("Unable to post update. Check your account info." + vbCrLf + melclient.getResponseData, MsgBoxStyle.Exclamation)
                    Status.Text = "Scrobble Failed."
            End Select

        End If
    End Sub

    Private Sub SendBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendBut.Click
        If Message.TextLength = 0 And MediaTitle.TextLength = 0 Then
            MsgBox("You must enter a message or a media title to post a update.", MsgBoxStyle.Exclamation)
            Status.Text = "No Message Entered."
        Else
            Dim httpcode As Integer
            Status.Text = "Posting Update..."
            httpcode = melclient.PostUpdate(MediaTitle.Text, MediaType.SelectedIndex, Segment.Text, Message.Text, SendtoTwitter.Checked, CompleteCheckbox.Checked)
            Select Case (httpcode)
                Case 200
                    If My.Settings.RequestOutPut = True Then
                        MsgBox("Post Successful" + vbCrLf + vbCrLf + melclient.getResponseData, MsgBoxStyle.Information)
                    End If
                    'Clear Message
                    Message.Text = ""
                    If CompleteCheckbox.Checked = True Then
                        MediaTitle.Text = ""
                        Segment.Text = ""
                    End If
                    CompleteCheckbox.Checked = False
                    Status.Text = "Post Successful."
                Case 500
                    MsgBox("Unable to post update. Check your account info." + vbCrLf + melclient.getResponseData, MsgBoxStyle.Exclamation)
                    Status.Text = "Post Failed."
                Case Else
                    MsgBox("Unable to post update. Unknown Error." + vbCrLf + melclient.getResponseData, MsgBoxStyle.Exclamation)
                    Status.Text = "Post Failed."
            End Select
        End If
    End Sub

    Private Sub ClearFields_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearFields.Click
        MediaTitle.Text = ""
        Segment.Text = ""
        Message.Text = ""
        Status.Text = "All fields are cleared."
    End Sub
End Class