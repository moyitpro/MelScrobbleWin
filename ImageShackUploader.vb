Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.XPath

Public Class ImageShackUploader
    Structure ReturnedURLs
        Dim DirectLinkURL As String
        Dim yflogURL As String
        Dim ThumbnailURL As String
        Dim Exitoso As Boolean
    End Structure
    Private Function GetReturnedURLsFromXMLRta(ByVal XML As String)
        'Intitalize new XmlDocument
        Dim xmlDoc As New XmlDocument

        'Read XML from the string provided
        xmlDoc.LoadXml(XML)

        'Instantiate the XPathNavigator class.
        Dim xmlNav As System.Xml.XPath.XPathNavigator = xmlDoc.CreateNavigator()

        'XPath
        Dim xmlNI As XPathNodeIterator

        'Select XPath
        xmlNI = xmlNav.Select("//links")

        Dim RtaURLs As New ReturnedURLs
        RtaURLs.Exitoso = True
        'Get the URLs
        While (xmlNI.MoveNext())
            Select Case xmlNI.Current.Name
                Case "image_link"
                    RtaURLs.DirectLinkURL = xmlNI.Current.Value
                    MsgBox("Direct Link: " + xmlNI.Current.Value)
                Case "thumb_link"
                    RtaURLs.ThumbnailURL = xmlNI.Current.Value
                    MsgBox("Thumbnail Link: " + xmlNI.Current.Value)
                Case "yfrog_link"
                    RtaURLs.yflogURL = xmlNI.Current.Value
                    MsgBox("yFlog Link: " + xmlNI.Current.Value)
            End Select
        End While

        Return RtaURLs

    End Function
    Public Function UploadFileToImageShack(ByVal FileName As String) As ReturnedURLs
        Dim OldValue As Boolean = System.Net.ServicePointManager.Expect100Continue

        Try

            System.Net.ServicePointManager.Expect100Continue = False
            '1. Cookie
            Dim Cookie As New Net.CookieContainer()

            '2. Arguments
            Dim QueryStringArguments As New Dictionary(Of String, String)
            QueryStringArguments.Add("rembar", "1")
            QueryStringArguments.Add("key", "")

            '3. contentType 
            Dim ContentType As String = ""
            Select Case IO.Path.GetExtension(FileName).ToLower
                Case ".jpg"
                    ContentType = "image/jpeg"
                Case ".jpeg"
                    ContentType = "image/jpeg"
                Case ".gif"
                    ContentType = "image/gif"
                Case ".png"
                    ContentType = "image/png"
                Case ".bmp"
                    ContentType = "image/bmp"
                Case ".tif"
                    ContentType = "image/tiff"
                Case ".tiff"
                    ContentType = "image/tiff"
                Case Else
                    ContentType = "image/unknown"
            End Select

            '4. Upload and return Rta
            Return GetReturnedURLsFromXMLRta(UploadFileEx(FileName, "http://www.imageshack.us/upload_api.php", "fileupload", ContentType, QueryStringArguments, Cookie))
        Catch ex As Exception
            Dim Rta As New ReturnedURLs
            Rta.Exitoso = False
            Return Rta
        Finally
            System.Net.ServicePointManager.Expect100Continue = OldValue
        End Try
    End Function
    Private Function UploadFileEx(ByVal FileName As String, ByVal URL As String, ByVal FileFormName As String, ByVal ContentType As String, ByVal QueryStringArguments As Dictionary(Of String, String), ByVal Cookies As Net.CookieContainer) As String

        If FileFormName = "" Then FileFormName = "file"
        If ContentType = "" Then ContentType = "application/octet-stream"

        Dim PostData As String = "?"
        If QueryStringArguments IsNot Nothing Then
            For Each kvp As KeyValuePair(Of String, String) In QueryStringArguments
                PostData &= kvp.Key & "=" & kvp.Value & "&"
            Next
        End If


        Dim URI As New Uri(URL + PostData)
        Dim Boundary As String = "----------" + DateTime.Now.Ticks.ToString("x")
        Dim WReq As Net.HttpWebRequest = DirectCast(Net.WebRequest.Create(URI), Net.HttpWebRequest)
        WReq.CookieContainer = Cookies
        WReq.ContentType = "multipart/form-data; boundary=" + Boundary
        WReq.Method = "POST"

        Dim PostHeader As String = String.Format("--" & Boundary & "{0}" & _
        "Content-Disposition: form-data; name=""" & FileFormName _
        & """; fileupload=""" & IO.Path.GetFileName(FileName) & """{0}" _
        & "Content-Type: " & ContentType & "{0}{0}", vbNewLine)

        Dim PostHeaderBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(PostHeader)
        Dim BoundaryBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(vbNewLine & "--" + Boundary + vbNewLine)

        Dim FileStream As New IO.FileStream(FileName, IO.FileMode.Open, IO.FileAccess.Read)

        WReq.ContentLength = PostHeaderBytes.Length + FileStream.Length + BoundaryBytes.Length

        Dim RequestStream As IO.Stream = WReq.GetRequestStream()
        RequestStream.Write(PostHeaderBytes, 0, PostHeaderBytes.Length)
        Dim buffer As Byte() = New Byte(CInt(Math.Min(4096, CInt(FileStream.Length))) - 1) {}
        Dim bytesRead As Integer = 0
        Do
            bytesRead = FileStream.Read(buffer, 0, buffer.Length)
            If bytesRead = 0 Then Exit Do
            RequestStream.Write(buffer, 0, bytesRead)
        Loop
        RequestStream.Write(BoundaryBytes, 0, BoundaryBytes.Length)
        RequestStream.Flush()
        RequestStream.Close()
        Dim Rta As Net.WebResponse = WReq.GetResponse()
        Dim s As IO.Stream = Rta.GetResponseStream()
        Dim sr As New IO.StreamReader(s)
        FileStream.Close()
        MsgBox(sr.ReadToEnd())
        Return sr.ReadToEnd()
    End Function


End Class