<<<<<<< HEAD
﻿Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.IO
Imports System.Web
Imports DJMatty.AMIP.ClientWrapper
Imports System.Text.RegularExpressions

Public Class Form1
    Private _client As AMIPClient = Nothing
    Public musicclient As String

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

    Private Sub ScrobbleBut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ScrobbleBut.Click
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
            If mediatype.Text = "Anime" Then
                data.Append("anime=" + HttpUtility.UrlEncode(MediaTitle.Text))
                data.Append("&attribute_type=" + HttpUtility.UrlEncode("episode"))
                data.Append("&attribute_name=" + HttpUtility.UrlEncode(Segment.Text))
            ElseIf mediatype.Text = "Music" Then
                data.Append("music=" + HttpUtility.UrlEncode(MediaTitle.Text))
                data.Append("&attribute_type=" + HttpUtility.UrlEncode("track"))
                data.Append("&attribute_name=" + HttpUtility.UrlEncode(Segment.Text))
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

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ExitMelScrobbleToolStripMenuItem.Checked = False Then
            e.Cancel = True
            Me.Hide()
            NotifyIcon1.ShowBalloonTip(30000, "MelScrobble is still running!", "MelScrobble will still run even if the scrobble window is closed.", ToolTipIcon.Info)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetFonts()
    End Sub

    Private Sub SetFonts()
        Dim sys As Font = SystemFonts.CaptionFont
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
        Application.Exit()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub DetectBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetectBut.Click
        If mediatype.SelectedIndex = 1 Then
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
        Else
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
            End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        mediatype.SelectedIndex = 0
        SetFonts()
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
=======
﻿Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.IO
Imports System.Web
Imports DJMatty.AMIP.ClientWrapper
Imports System.Text.RegularExpressions

Public Class Form1
    Private _client As AMIPClient = Nothing
    Public musicclient As String

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
                        data.Append("message=" + HttpUtility.UrlEncode("/" + action + " /an/" + MediaTitle.Text + "/" + Segment.Text + ": " + Message.Text))
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

    Private Sub ScrobbleBut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ScrobbleBut.Click
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
            If mediatype.Text = "Anime" Then
                data.Append("anime=" + HttpUtility.UrlEncode(MediaTitle.Text))
                data.Append("&atribute_type=" + HttpUtility.UrlEncode("episode"))
                data.Append("&atribute_name=" + HttpUtility.UrlEncode(Segment.Text))
            ElseIf mediatype.Text = "Music" Then
                data.Append("music=" + HttpUtility.UrlEncode(MediaTitle.Text))
                data.Append("&atribute_type=" + HttpUtility.UrlEncode("track"))
                data.Append("&segment=" + HttpUtility.UrlEncode(Segment.Text))
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

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ExitMelScrobbleToolStripMenuItem.Checked = False Then
            e.Cancel = True
            Me.Hide()
            NotifyIcon1.ShowBalloonTip(30000, "MelScrobble is still running!", "MelScrobble will still run even if the scrobble window is closed.", ToolTipIcon.Info)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SetFonts()
        Dim sys As Font = SystemFonts.CaptionFont
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
        Application.Exit()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub DetectBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetectBut.Click
        If mediatype.SelectedIndex = 1 Then
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
        Else
            'Retrieve Recently Played file from registry
            Try
                Dim file As String
                file = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Gabest\Media Player Classic\Recent File List", "File1", "")
                If file.Length > 0 Then
                    'Regex Time
                    file = Regex.Replace(file, "^.+\\", "")
                    file = Regex.Replace(file, "\.\w+$", "")
                    file = Regex.Replace(file, "[\s_]*\[[^\]]+\]\s*", "")
                    file = Regex.Replace(file, "[\s_]*\([^\)]+\)$", "")
                    file = Regex.Replace(file, "_", " ")
                    'Output to fields
                    MediaTitle.Text = Regex.Replace(file, "( \-)? (episode |ep |ep|e)?(\d+)([\w\-! ]*)$", "")
                    Segment.Text = Regex.Replace(Regex.Match(file, "( \-)? (episode |ep |ep|e)?(\d+)([\w\-! ]*)$").ToString, " - ", "Episode ")
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
            End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        mediatype.SelectedIndex = 0
        SetFonts()
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
>>>>>>> 48c293ee20ce17708d5d1ae7ae23b1fb4e4103bf
End Class