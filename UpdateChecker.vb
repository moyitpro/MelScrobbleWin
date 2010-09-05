Imports System.Xml

Module UpdateChecker
    Public Sub CheckForUpdates()
        ' in newVersion variable we will store the  
        ' version info from xml file  
        Dim newVersion As Version = Nothing
        ' and in this variable we will put the url we  
        ' would like to open so that the user can  
        ' download the new version  
        ' it can be a homepage or a direct  
        ' link to zip/exe file  
        Dim url As String = ""
        Dim reader As XmlTextReader
        Try
            ' provide the XmlTextReader with the URL of  
            ' our xml document  
            Dim xmlURL As String = "http://chikorita157.com/tools/melscrobbleupdates.xml"
            reader = New XmlTextReader(xmlURL)
            ' simply (and easily) skip the junk at the beginning  
            reader.MoveToContent()
            ' internal - as the XmlTextReader moves only  
            ' forward, we save current xml element name  
            ' in elementName variable. When we parse a  
            ' text node, we refer to elementName to check  
            ' what was the node name  
            Dim elementName As String = ""
            ' we check if the xml starts with a proper  
            ' "ourfancyapp" element node  
            If (reader.NodeType = XmlNodeType.Element) AndAlso (reader.Name = "app") Then
                While reader.Read()
                    ' when we find an element node,  
                    ' we remember its name  
                    If reader.NodeType = XmlNodeType.Element Then
                        elementName = reader.Name
                    Else
                        ' for text nodes...  
                        If (reader.NodeType = XmlNodeType.Text) AndAlso (reader.HasValue) Then
                            ' we check what the name of the node was  
                            Select Case elementName
                                Case "version"
                                    ' thats why we keep the version info  
                                    ' in xxx.xxx.xxx.xxx format  
                                    ' the Version class does the  
                                    ' parsing for us  
                                    newVersion = New Version(reader.Value)
                                    Exit Select
                                Case "url"
                                    url = reader.Value
                                    Exit Select
                            End Select
                        End If
                    End If
                End While
            End If
            ' get the running version  
            Dim curVersion As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
            ' compare the versions  
            If curVersion.CompareTo(newVersion) < 0 Then
                ' ask the user if he would like  
                ' to download the new version  
                Dim title As String = "New Update Available"
                Dim question As String = "There is a new version of MelScrobble (" + newVersion.ToString + ") available. You are using " + curVersion.ToString + vbNewLine + "Do you want to download the update now?"
                If DialogResult.Yes = MessageBox.Show(question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    ' navigate the default web  
                    ' browser to our app  
                    ' homepage (the url  
                    ' comes from the xml content)  
                    System.Diagnostics.Process.Start(url)
                End If
            Else
                MsgBox("MelScrobble " + curVersion.ToString + " is currently the newest version aviliable", MessageBoxIcon.Question, "You're up to date!")
            End If
        Catch generatedExceptionName As Exception
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
        End Try
    End Sub
End Module
