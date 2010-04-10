Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.IO
Imports System.Web

Public Class Form1

    ' Import functions from dwmapi.dll - get this info from the sdk dwmapi.h

    <DllImport("dwmapi.dll", CharSet:=CharSet.Auto)> _
    Public Shared Sub DwmExtendFrameIntoClientArea(ByVal hWnd As System.IntPtr, ByRef pMargins As Margins)

    End Sub

    <DllImport("dwmapi.dll", CharSet:=CharSet.Auto)> _
    Public Shared Sub DwmIsCompositionEnabled(ByRef IsIt As Boolean)

    End Sub

    ' Create the brush that'll work around the Alpha transparency issue

    Private DWMFrame As SolidBrush = New SolidBrush(Color.Black)

    Dim BlurBehind As Boolean = False

    Dim MaxTrans As Boolean = False

    Dim blurect As Boolean = False

    ' Create an instance of the Margins struct for use in our form

    Private inset As Margins = New Margins



    ' Define the Margins struct - get this from dwmapi.h

    Public Structure Margins

        Public Left As Integer

        Public Right As Integer

        Public Top As Integer

        Public Bottom As Integer

    End Structure

    Public Sub New()

        InitializeComponent()

        ' Set the Margins to their default values

        inset.Top = 0

        inset.Left = 0

        inset.Right = 0

        inset.Bottom = 0

        ' Check if DWM is enabled. This is a pretty stupid way to check, since it requires dwmapi.dll to be present anyway...

        Dim isit As Boolean = False

        DwmIsCompositionEnabled(isit)

        If isit Then

            ' If DWM is enabled, call the function that gives us glass, passing a reference to our inset Margins

            DwmExtendFrameIntoClientArea(Me.Handle, inset)

        Else

            ' If DWM isn't enabled, shout it out

            MessageBox.Show("DWM isn't enabled")

        End If

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        MyBase.OnPaint(e)

        Me.PaintSquare(e, Me.DWMFrame)

    End Sub

    Private Sub PaintSquare(ByRef e As System.Windows.Forms.PaintEventArgs, ByVal b As SolidBrush)

        e.Graphics.FillRectangle(b, 0, 0, Width, inset.Top)

        e.Graphics.FillRectangle(b, 0, 0, inset.Left, Height)

        ' Note the numbers ( -14, -34) are just trial-and-error values, used to fix the glass... try omitting them, you'll get the idea.

        e.Graphics.FillRectangle(b, Width - inset.Right - 14, 0, inset.Right, Height)

        e.Graphics.FillRectangle(b, 0, Height - inset.Bottom - 34, Width, inset.Bottom)

    End Sub

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
                    data.Append("&source=" + HttpUtility.UrlEncode("Winamp"))
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

                MsgBox("Post Successful" + vbCrLf + vbCrLf + reader.ReadToEnd, MsgBoxStyle.Information)

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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

                MsgBox("Scrobble Successful" + vbCrLf + vbCrLf + reader.ReadToEnd, MsgBoxStyle.Information)

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

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mediatype.SelectedIndex = 0
    End Sub
End Class