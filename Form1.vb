Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.IO
Imports System.Web
Imports DJMatty.AMIP.ClientWrapper
Imports System.Text.RegularExpressions
Imports Growl.Connector

Public Class Form1
    Private _client As AMIPClient = Nothing
    Public musicclient As String
    Public scrobbleenabled As Boolean
    Public scrobblemediatitle As String
    Public scrobblemediasegment As String
    Public scrobblesuccess As Boolean
    Dim WithEvents growl As GrowlConnector
    Dim nt As NotificationType = New NotificationType("Message", "Message")
    Dim app As Growl.Connector.Application

    Private Sub PostBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostBut.Click
        If Message.TextLength = 0 And MediaTitle.TextLength = 0 Then
            MsgBox("You must enter a message or a media title to post a update.", MsgBoxStyle.Exclamation)
            Status.Text = "No Message Entered."
        Else
            Status.Text = "Posting Update..."
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse = Nothing
            Dim reader As StreamReader
            Dim address As Uri
            Dim data As StringBuilder
            Dim byteData() As Byte
            Dim postStream As Stream = Nothing

            address = New Uri("http://melative.com/api/micro/update.json")
            If SendtoTwitter.Checked = True Then
                Message.Text = Message.Text & " @tw"
            End If
            ' Create the web request  
            request = DirectCast(WebRequest.Create(address), HttpWebRequest)
            ' Set type to POST  
            request.Method = "POST"
            request.ContentType = "application/x-www-form-urlencoded"
            request.Headers.Add("Cookie", My.Settings.APIToken)

            data = New StringBuilder()
            If MediaTitle.TextLength > 0 Then
                Dim action As String
                If mediatype.Text = "Anime" Then
                    If CompleteCheckbox.Checked = True Then
                        action = "watched"
                    Else
                        action = "watching"
                    End If
                    If Segment.TextLength > 0 Then
                        data.Append("message=" + HttpUtility.UrlEncode("/" + action + " /an/" + MediaTitle.Text + "/episode " + Segment.Text + ": " + Message.Text))
                    Else
                        data.Append("message=" + HttpUtility.UrlEncode("/" + action + " /an/" + MediaTitle.Text + Message.Text))
                    End If
                    data.Append("&source=" + HttpUtility.UrlEncode("Media Player Classic"))
                ElseIf mediatype.Text = "Music" Then
                    If CompleteCheckbox.Checked = True Then
                        action = "listened"
                    Else
                        action = "listening"
                    End If
                    If Segment.TextLength > 0 Then
                        data.Append("message=" + HttpUtility.UrlEncode("/" + action + " /music/" + MediaTitle.Text + "/" + Segment.Text + ": " + Message.Text))
                    Else
                        data.Append("message=" + HttpUtility.UrlEncode("/" + action + " /music/" + MediaTitle.Text + Message.Text))
                    End If
                    If musicclient.Length > 0 Then
                        data.Append("&source=" + HttpUtility.UrlEncode(musicclient))
                    Else
                        data.Append("&source=" + HttpUtility.UrlEncode("MelScrobble"))
                    End If

                End If
            Else
                data.Append("message=" + HttpUtility.UrlEncode(Message.Text))
                data.Append("&source=" + HttpUtility.UrlEncode("MelScrobble"))
            End If


            ' Create a byte array of the data we want to send  
            byteData = UTF8Encoding.UTF8.GetBytes(data.ToString())

            ' Set the content length in the request headers  
            request.ContentLength = byteData.Length

            ' Write data  
            Try
                postStream = request.GetRequestStream()
                postStream.Write(byteData, 0, byteData.Length)
            Finally
                If Not postStream Is Nothing Then postStream.Close()
            End Try

            Try
                ' Get response  
                response = DirectCast(request.GetResponse(), HttpWebResponse)

                ' Get the response stream into a reader  
                reader = New StreamReader(response.GetResponseStream())
                If My.Settings.RequestOutPut = True Then
                    MsgBox("Post Successful" + vbCrLf + vbCrLf + reader.ReadToEnd, MsgBoxStyle.Information)
                End If
                'Clear Message
                Message.Text = ""
                CompleteCheckbox.Checked = False
                Status.Text = "Post Successful."
            Catch webexception As WebException
                MsgBox("Unable to post update. Check your account info." + vbCrLf + webexception.Message, MsgBoxStyle.Exclamation)
                Status.Text = "Post Failed."
            Finally
                If Not response Is Nothing Then
                    response.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dialog1.ShowDialog()
    End Sub

    Public Sub ScrobbleBut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ScrobbleBut.Click
        If MediaTitle.TextLength = 0 Or Segment.TextLength = 0 Then
            MsgBox("You must enter a media title and a segment to scrobble this title.", MsgBoxStyle.Exclamation)
            Status.Text = "No Title/Segment Entered."
        Else
            Status.Text = "Scrobbling Title..."
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse = Nothing
            Dim reader As StreamReader
            Dim address As Uri
            Dim data As StringBuilder
            Dim byteData() As Byte
            Dim postStream As Stream = Nothing

            address = New Uri("http://melative.com/api/library/scrobble.json")

            ' Create the web request  
            request = DirectCast(WebRequest.Create(address), HttpWebRequest)
            ' Set type to POST  
            request.Method = "POST"
            request.ContentType = "application/x-www-form-urlencoded"
            request.Headers.Add("Cookie", My.Settings.APIToken)
            ' Set up the form
            data = New StringBuilder()

            Select Case mediatype.SelectedIndex
                Case 0
                    data.Append("anime=" + HttpUtility.UrlEncode(MediaTitle.Text))
                    data.Append("&attribute_type=" + HttpUtility.UrlEncode("episode"))
                    data.Append("&attribute_name=" + HttpUtility.UrlEncode(Segment.Text))
                Case 1
                    data.Append("music=" + HttpUtility.UrlEncode(MediaTitle.Text))
                    data.Append("&attribute_type=" + HttpUtility.UrlEncode("track"))
                    data.Append("&attribute_name=" + HttpUtility.UrlEncode(Segment.Text))
            End Select
            ' Create a byte array of the data we want to send  
            byteData = UTF8Encoding.UTF8.GetBytes(data.ToString())

            ' Set the content length in the request headers  
            request.ContentLength = byteData.Length

            ' Write data  
            Try
                postStream = request.GetRequestStream()
                postStream.Write(byteData, 0, byteData.Length)
            Finally
                If Not postStream Is Nothing Then postStream.Close()
            End Try

            Try
                ' Get response  
                response = DirectCast(request.GetResponse(), HttpWebResponse)

                ' Get the response stream into a reader  
                reader = New StreamReader(response.GetResponseStream())
                If My.Settings.RequestOutPut = True Then
                    MsgBox("Scrobble Successful" + vbCrLf + vbCrLf + reader.ReadToEnd, MsgBoxStyle.Information)
                End If
                'Clear Message
                Message.Text = ""
                CompleteCheckbox.Checked = False
                Status.Text = "Scrobble Successful."
            Catch webexception As WebException
                MsgBox("Unable to post update. Check your account info." + vbCrLf + webexception.Message, MsgBoxStyle.Exclamation)
                Status.Text = "Scrobble Failed."
            Finally
                If Not response Is Nothing Then
                    response.Close()
                End If
            End Try
        End If
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

    End Sub

    Private Sub SetFonts()
        Dim sys As Font = SystemFonts.DialogFont
        Label1.Font = sys
        Label2.Font = sys
        Label3.Font = sys
        Label4.Font = sys
        Status.Font = sys
        ScrobbleBut.Font = sys
        PostBut.Font = sys
        Message.Font = sys
        MediaTitle.Font = sys
        mediatype.Font = sys
        mediatype.Font = sys
        Segment.Font = sys
        ArtistName.Font = sys
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

    Private Sub DetectBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetectBut.Click
        DetectMedia()
    End Sub
    Public Sub DetectMedia()
        Select Case mediatype.SelectedIndex
            Case 0
                'Retrieve Recently Played file from registry
                Try
                    Dim file As String
                    file = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Gabest\Media Player Classic\Recent File List", "File1", "")
                    If file.Length > 0 Then
                        'Regex Time
                        file = Regex.Replace(file, "^.+\\", "")
                        file = Regex.Replace(file, "\.\w+$", "")
                        file = Regex.Replace(file, "\s*\[[^\]]+\]\s*", "")
                        file = Regex.Replace(file, "\s*\([^\)]+\)$", "")
                        file = Regex.Replace(file, "_", " ")
                        'Output to fields
                        MediaTitle.Text = Regex.Replace(file, "( \-)? (episode |ep |ep|e)?(\d+)([\w\-! ]*)$", "")
                        Segment.Text = Regex.Replace(Regex.Match(file, "( \-)? (episode |ep |ep|e)?(\d+)([\w\-! ]*)$").ToString, " - ", "")
                        'Trim Whitespace
                        MediaTitle.Text = Trim(MediaTitle.Text)
                        Status.Text = "Detected currently playing video."

                    Else
                        'Show error
                        MsgBox("MelScrobble was unable to detect Media file in Media Player Classic." + vbCrLf + "Make sure 'Keep History of recently opened files' was enabled and try again.", MsgBoxStyle.Exclamation)
                        Status.Text = "Detection failed."
                    End If
                Catch
                    MsgBox("MelScrobble was unable to detect Media file in Media Player Classic." + vbCrLf + "Make sure 'Keep History of recently opened files' was enabled and try again.", MsgBoxStyle.Exclamation)
                    Status.Text = "Detection failed."
                End Try
            Case 1
                'Create a new instance of AMIP
                _client = New AMIPClient("127.0.0.1", 60333, 5000, 5, 1, True)
                Try
                    'Set Music Info
                    MediaTitle.Text = _client.Format("%4")
                    Segment.Text = _client.Format("%2")
                    ArtistName.Text = _client.Format("%1")
                    'Set player as the source (used for Microblogging)
                    musicclient = _client.Eval("var_player")
                    Status.Text = "Detected current " + musicclient + " track."
                Catch ex As Exception
                    Status.Text = "Error: No track is playing."
                End Try
                'Remove the AMIP client, not needed
                _client.Dispose()

        End Select
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Set Mediatype
        mediatype.SelectedIndex = My.Settings.Mediatype
        'Set Fonts
        SetFonts()
        'Set up Growl Notifications
        Me.app = New Growl.Connector.Application("MelScrobbleX")
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
        MsgBox("MelScrobble " + My.Application.Info.Version.ToString + vbCrLf + vbCrLf + "Melative Scrobbler for Windows running on " + My.Computer.Info.OSFullName.ToString + vbCrLf + vbCrLf + "Copyright 2009-2010 James M. All Rights Reserved" + vbCrLf + "Licensed under GNU Public License v3", MsgBoxStyle.Information, "About")
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
        DetectMedia()

        If MediaTitle.TextLength = 0 Or Segment.TextLength = 0 Then
            'Nothing to scrobble, do nothing

        ElseIf MediaTitle.Text = scrobblemediatitle And Segment.Text = scrobblemediasegment And scrobblesuccess = True Then
            'Don't want to scrobble the same title and segment again, so do nothing
        Else
            ' Set media to scrobble temp strings
            scrobblemediatitle = MediaTitle.Text
            scrobblemediasegment = Segment.Text
            ' Start the process
            Status.Text = "Scrobbling Title..."
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse = Nothing
            Dim reader As StreamReader
            Dim address As Uri
            Dim data As StringBuilder
            Dim byteData() As Byte
            Dim postStream As Stream = Nothing

            address = New Uri("http://melative.com/api/library/scrobble.json")

            ' Create the web request  
            request = DirectCast(WebRequest.Create(address), HttpWebRequest)
            ' Set type to POST  
            request.Method = "POST"
            request.ContentType = "application/x-www-form-urlencoded"
            request.Headers.Add("Cookie", My.Settings.APIToken)
            ' Set up the form
            data = New StringBuilder()

            Select Case mediatype.SelectedIndex
                Case 0
                    data.Append("anime=" + HttpUtility.UrlEncode(scrobblemediatitle))
                    data.Append("&attribute_type=" + HttpUtility.UrlEncode("episode"))
                    data.Append("&attribute_name=" + HttpUtility.UrlEncode(scrobblemediasegment))
                Case 1
                    data.Append("music=" + HttpUtility.UrlEncode(scrobblemediatitle))
                    data.Append("&attribute_type=" + HttpUtility.UrlEncode("track"))
                    data.Append("&attribute_name=" + HttpUtility.UrlEncode(scrobblemediasegment))
            End Select

            ' Create a byte array of the data we want to send  
            byteData = UTF8Encoding.UTF8.GetBytes(data.ToString())

            ' Set the content length in the request headers  
            request.ContentLength = byteData.Length

            ' Write data  
            Try
                postStream = request.GetRequestStream()
                postStream.Write(byteData, 0, byteData.Length)
            Finally
                If Not postStream Is Nothing Then postStream.Close()
            End Try

            Try
                ' Get response  
                response = DirectCast(request.GetResponse(), HttpWebResponse)

                ' Get the response stream into a reader  
                reader = New StreamReader(response.GetResponseStream())
                'Clear Message
                Message.Text = ""
                CompleteCheckbox.Checked = False
                Status.Text = "Scrobble Successful."
                SendGrowlMessage("Scrobble Successful!", scrobblemediatitle & " - " & scrobblemediasegment)
                scrobblesuccess = True
            Catch webexception As WebException
                Status.Text = "Scrobble Failed."
                SendGrowlMessage("Scrobble Unsuccessful!", "Check your login token or internet connection and try again.")
                scrobblesuccess = False
            Finally
                If Not response Is Nothing Then
                    response.Close()
                End If
            End Try
        End If
    End Sub
    Public Sub SendGrowlMessage(ByVal Title As String, ByVal Message As String)
        Dim n As New Notification(Me.app.Name, Me.nt.Name, DateTime.Now.Ticks.ToString(), Title, Message)
        growl.Notify(n)
    End Sub
    Public Sub SetToolTips()
        ToolTips.SetToolTip(Message, "Enter your message here.")
        ToolTips.SetToolTip(mediatype, "Selects the Media Type to use in your update or scrobble with.")
        ToolTips.SetToolTip(MediaTitle, "The title of the media.")
        ToolTips.SetToolTip(Segment, "The segment of the media (e.g.: Episode or Track).")
        ToolTips.SetToolTip(CompleteCheckbox, "Check this if you completed with the segment/media.")
        ToolTips.SetToolTip(SendtoTwitter, "Appends @tw to your message and sends this update to Twitter." & vbCrLf & "The Twitter Bridge must be enabled to use this feature")
        ToolTips.SetToolTip(ArtistName, "The artist name. Used only with the Music mediatype.")
        ToolTips.SetToolTip(ScrobbleBut, "Silently update the current media title and segment")
        ToolTips.SetToolTip(PostBut, "Posts the update.")
    End Sub

End Class