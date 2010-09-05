Public Class About


    Private Sub About_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label2.Text = "Version " + My.Application.Info.Version.ToString
    End Sub
End Class