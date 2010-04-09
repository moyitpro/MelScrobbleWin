Imports System.Data

Imports System.Drawing

Imports System.Text

Imports System.Windows.Forms

Imports System.Runtime.InteropServices
Imports System.Net
Imports System.IO

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
        If Message.TextLength = 0 Or MediaTitle.TextLength < 0 Then
            MsgBox("You must enter a message or a media title to post a update.",MsgBoxStyle.Exclamation)
        Else
            Dim requestsocket1 As HttpWebRequest = WebRequest.Create("http://melative.com/api/micro/update.json")
            requestsocket1.Method = "POST"
            requestsocket1.Headers.Add("Cookies", My.Settings.APIToken)
            Try
                Dim response As WebResponse = requestsocket1.GetResponse()
                Dim data As Stream = response.GetResponseStream()
                data = response.GetResponseStream()
                Dim reader As New StreamReader(data)
                MsgBox("Post Successful" + vbCrLf + vbCrLf + reader.ReadToEnd, MsgBoxStyle.Information)
                reader.Close()
                response.Close()
            Catch webException As WebException 
                MsgBox("Unable to post update. Check your account info." + vbCrLf + webException.Message,MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dialog1.ShowDialog()
    End Sub
End Class