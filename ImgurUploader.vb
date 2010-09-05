Imports System.Net
Imports System.IO
Imports System.Web
Imports System.Text
Imports System.Xml.XPath
Imports System.Xml

Public Class ImgurUploader
    Public Property APIKey As String = "c8c106319f11dd5bb187d7f54caf696e"

    Public Function UploadToImgur(ByVal filename As String) As String
        Dim xmlresponse As String
        'Attempt to upload picture and get response in XML
        xmlresponse = UploadEx(filename)
        If xmlresponse.Length > 0 Then
            'Intitalize new XmlDocument
            Dim xmlDoc As New XmlDocument

            'Read XML from the string provided
            xmlDoc.LoadXml(xmlresponse)

            'Instantiate the XPathNavigator class.
            Dim xmlNav As System.Xml.XPath.XPathNavigator = xmlDoc.CreateNavigator()

            'XPath
            Dim xmlNI As XPathNodeIterator

            'Select XPath
            xmlNI = xmlNav.Select("//upload/links/original")

            'Get the URLs
            Dim OriginalURL As String = ""
            While (xmlNI.MoveNext())
                OriginalURL = xmlNI.Current.Value
            End While
            Return OriginalURL
        Else
            ' Failed Upload
            Return ""
        End If
    End Function
    Public Function UploadEx(ByVal filename As String) As String
        Try
            Dim imageData As Byte()

            Dim fileStream As FileStream = File.OpenRead(filename)
            imageData = New Byte(fileStream.Length - 1) {}
            fileStream.Read(imageData, 0, imageData.Length)
            fileStream.Close()

            Dim uploadRequestString As [String] = HttpUtility.UrlEncode("image", Encoding.UTF8) & "=" & HttpUtility.UrlEncode(System.Convert.ToBase64String(imageData)) & "&" & HttpUtility.UrlEncode("key", Encoding.UTF8) & "=" & HttpUtility.UrlEncode(APIKey, Encoding.UTF8)

            Dim webRequest__1 As HttpWebRequest = DirectCast(WebRequest.Create("http://api.imgur.com/2/upload"), HttpWebRequest)
            webRequest__1.Method = "POST"
            webRequest__1.ContentType = "application/x-www-form-urlencoded"
            webRequest__1.ServicePoint.Expect100Continue = False

            Dim streamWriter As New StreamWriter(webRequest__1.GetRequestStream())
            streamWriter.Write(uploadRequestString)
            streamWriter.Close()

            Dim response As WebResponse = webRequest__1.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            Dim responseReader As New StreamReader(responseStream)

            Dim responseString As String = responseReader.ReadToEnd()
            Return responseString
        Catch ex As WebException
            Return ""
        End Try
    End Function


End Class
