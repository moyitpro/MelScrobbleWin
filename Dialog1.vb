Imports System.Windows.Forms
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Web

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAtStartup.CheckedChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Username.TextLength = 0 Then
            MsgBox("No Username was entered. Please type a valid username and password and try again", MsgBoxStyle.Exclamation)
        ElseIf Password.TextLength = 0 Then
            MsgBox("No Password was entered. Please type a valid username and password and try again", MsgBoxStyle.Exclamation)
        Else
            Dim requestsocket1 As HttpWebRequest = WebRequest.Create("http://melative.com/api/account/verify_credentials.xml")
            requestsocket1.Method = "GET"
            requestsocket1.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(Username.Text + ":" + Password.Text)))
            Try
                Dim response As WebResponse = requestsocket1.GetResponse()
                Dim data As Stream = response.GetResponseStream()
                data = response.GetResponseStream()
                Dim reader As New StreamReader(data)
                MsgBox("Login Successful" + vbCrLf + vbCrLf + reader.ReadToEnd, MsgBoxStyle.Information)
                CreateTokens(Username.Text, Password.Text)
                If My.Settings.APIToken.Length > 0 Then
                    Button2.Enabled = False
                    Button1.Enabled = True
                End If
            Catch webException As WebException
                MsgBox("Unable to verify account. Check your account info." + vbCrLf + webException.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub CreateTokens(ByVal UsernameS As String, ByVal PasswordS As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim address As Uri
        Dim data As StringBuilder
        Dim byteData() As Byte
        Dim postStream As Stream = Nothing

        address = New Uri("http://melative.com/api/session/create.xml")

        ' Create the web request  
        request = DirectCast(WebRequest.Create(address), HttpWebRequest)
        ' Set type to POST  
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"
        request.CookieContainer = New CookieContainer()

        data = New StringBuilder()
        data.Append("user=" + HttpUtility.UrlEncode(UsernameS))
        data.Append("&password=" + HttpUtility.UrlEncode(PasswordS))

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

            ' Console application output  
            My.Settings.APIToken = response.Cookies.Item(0).ToString
        Catch

        Finally
            If Not response Is Nothing Then
                response.Close()
            End If
        End Try
    End Sub

    Private Sub Dialog1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Settings.APIToken.Length > 0 Then
            Button2.Enabled = False
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim choice As Integer
        choice = MsgBox("Are you sure you want to delete the token from this computer?" + vbCrLf + vbCrLf + "Once done, this action cannot be undone.", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
        If choice = 6 Then
            My.Settings.APIToken = ""
            If My.Settings.APIToken.Length = 0 Then
                Button2.Enabled = True
                Button1.Enabled = False
            End If
        End If


    End Sub
End Class
