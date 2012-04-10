Imports System.Net
Imports System.IO
Imports System.Web
Imports System.Text
Imports DJMatty.AMIP.ClientWrapper
Imports System.Text.RegularExpressions
Imports System.Management

Public Class Melative
    Private responsedata As String
    Private _client As AMIPClient = Nothing
    Private musicclient As String
    Private detectedmediatitle As String
    Private detectedmediasegment As String
    Private scrobblemediatitle As String
    Private scrobblemediasegment As String
    Private scrobblesuccess As Boolean
    Private scrobbledmediatitle As String
    Private scrobbledmediasegment As String
    'Accessors
    Public Function getMedia() As String
        Return detectedmediatitle
    End Function
    Public Function getSegment() As String
        Return detectedmediasegment
    End Function
    Public Function getResponseData() As String
        Return responsedata
    End Function
    Public Function getScrobbleSuccess() As Boolean
        Return scrobblesuccess
    End Function
    Public Function getscrobbledmediatitle() As String
        Return scrobbledmediatitle
    End Function
    Public Function getscrobbledmediaSegment() As String
        Return scrobbledmediasegment
    End Function
    Public Function setScrobbleSucess(ByVal s As Boolean)
        setScrobbleSucess = s
    End Function
    'Functions
    Public Function DetectMedia(ByVal mediatype As Integer) As Boolean
        Select Case mediatype
            Case 0
                Return detectvideo()
            Case 1
                Return detectaudio()
            Case 2
                Return detectvideo()
        End Select
    End Function
    Private Function detectaudio() As Boolean
        'Create a new instance of AMIP
        _client = New AMIPClient("127.0.0.1", 60333, 5000, 5, 1, True)
        Try
            'Set Music Info
            detectedmediatitle = _client.Format("%4")
            detectedmediasegment = _client.Format("%2")
            'ArtistName.Text = _client.Format("%1")
            'Set player as the source (used for Microblogging)
            musicclient = _client.Eval("var_player")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function detectvideo() As Boolean
        ' Get WMIC Output
        Dim wmicoutput As String = ""
        Dim file As String
        Dim searcher As New ManagementObjectSearcher( _
        "SELECT * FROM Win32_Process WHERE Name='mpc-hc.exe'")

        For Each process As ManagementObject In searcher.Get()
            wmicoutput = process("CommandLine") + wmicoutput
        Next

        If wmicoutput.Length = 0 Then
            Try
                file = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Gabest\Media Player Classic\Recent File List", "File1", "")
            Catch
                Return False
            End Try
        Else
            file = WMICRegex(wmicoutput)
        End If

        ' Show Output
        If file.Length > 0 Then
            'Regex Time
            file = Regex.Replace(file, "^.+\\", "")
            file = Regex.Replace(file, "\.\w+$", "")
            file = Regex.Replace(file, "[\s_]*\[[^\]]+\]\s*", "")
            file = Regex.Replace(file, "[\s_]*\([^\)]+\)$", "")
            file = Regex.Replace(file, "_", " ")
            'Output to fields
            detectedmediatitle = Regex.Replace(file, "( \-)? (episode |ep |ep|e)?(\d+)([\w\-! ]*)$", "")
            detectedmediasegment = Regex.Replace(Regex.Match(file, "( \-)? (episode |ep |ep|e)?(\d+)([\w\-! ]*)$").ToString, " - ", "")
            'Trim Whitespace
            detectedmediatitle = Trim(detectedmediatitle)
            Return True

        Else
            Return False
        End If
    End Function
    Public Function PostUpdate(ByVal media As String, ByVal mediatype As Integer, ByVal segment As String, ByVal message As String, ByVal twitter As Boolean, ByVal completed As Boolean) As Integer
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim address As Uri
        Dim data As StringBuilder
        Dim byteData() As Byte
        Dim postStream As Stream = Nothing

        address = New Uri("http://melative.com/api/micro/update.json")
        If twitter = True Then
            message = message & " @tw"
        End If
        ' Create the web request  
        request = DirectCast(WebRequest.Create(address), HttpWebRequest)
        ' Set type to POST  
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"
        request.Headers.Add("Cookie", My.Settings.APIToken)

        data = New StringBuilder()
        If media.Length > 0 Then
            Dim action As String
            If mediatype = 0 Then
                If completed = True Then
                    action = "watched"
                Else
                    action = "watching"
                End If
                If segment.Length > 0 Then
                    data.Append("message=" + HttpUtility.UrlEncode(action + " /anime/" + media + "/episode/" + segment + ": " + message))
                Else
                    data.Append("message=" + HttpUtility.UrlEncode(action + " /anime/" + media + "/: " + message))
                End If
                data.Append("&source=" + HttpUtility.UrlEncode("Media Player Classic"))
            ElseIf mediatype = 1 Then
                If completed = True Then
                    action = "listened"
                Else
                    action = "listening"
                End If
                If segment.Length > 0 Then
                    data.Append("message=" + HttpUtility.UrlEncode("/" + action + " /music/" + media + "/" + segment + ": " + message))
                Else
                    data.Append("message=" + HttpUtility.UrlEncode("/" + action + " /music/" + media + "/: " + message))
                End If
                If musicclient.Length > 0 Then
                    data.Append("&source=" + HttpUtility.UrlEncode(musicclient))
                Else
                    data.Append("&source=" + HttpUtility.UrlEncode("MelScrobble"))
                End If
            ElseIf mediatype = 3 Then
                If completed = True Then
                    action = "watched"
                Else
                    action = "watching"
                End If
                If segment.Length > 0 Then
                    data.Append("message=" + HttpUtility.UrlEncode("/" + action + " /adrama/" + media + "/episode/" + segment + ": " + message))
                Else
                    data.Append("message=" + HttpUtility.UrlEncode("/" + action + " /adrama/" + media + "/: " + message))
                End If
                data.Append("&source=" + HttpUtility.UrlEncode("Media Player Classic"))
            End If
        Else
            data.Append("message=" + HttpUtility.UrlEncode(message))
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
            responsedata = reader.ReadToEnd
            Return 200
        Catch webexception As WebException
            responsedata = webexception.Message
            Return 500
        Finally
            If Not response Is Nothing Then
                response.Close()
            End If
        End Try
    End Function
    Public Function Scrobble(ByVal media As String, ByVal segment As String, ByVal mediatype As Integer) As Integer
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

        Select Case mediatype
            Case 0
                data.Append("anime=" + HttpUtility.UrlEncode(media))
                data.Append("&attribute_type=" + HttpUtility.UrlEncode("episode"))
                data.Append("&attribute_name=" + HttpUtility.UrlEncode(segment))
            Case 1
                data.Append("music=" + HttpUtility.UrlEncode(media))
                data.Append("&attribute_type=" + HttpUtility.UrlEncode("track"))
                data.Append("&attribute_name=" + HttpUtility.UrlEncode(segment))
            Case 2
                data.Append("adrama=" + HttpUtility.UrlEncode(media))
                data.Append("&attribute_type=" + HttpUtility.UrlEncode("episode"))
                data.Append("&attribute_name=" + HttpUtility.UrlEncode(segment))
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
            responsedata = reader.ReadToEnd
            scrobbledmediatitle = media
            scrobbledmediasegment = segment
            Return 200
        Catch webexception As WebException
            responsedata = webexception.Message
            Return 500
        Finally
            If Not response Is Nothing Then
                response.Close()
            End If
        End Try
    End Function
    Private Function WMICRegex(ByVal Input As String) As String
        Dim pattern As String = "\\([^\\]+)$"
        Dim rgx As New Regex(pattern, RegexOptions.IgnoreCase)
        Dim matches As MatchCollection = rgx.Matches(Input)
        If matches.Count > 0 Then
            Input = "C:" & matches(0).Value
            Input = Trim(Regex.Replace(Input, Chr(34), ""))
            Input = Regex.Replace(Input, "\n", "")
            Return Input
        Else
            Return ""
        End If
    End Function
End Class
