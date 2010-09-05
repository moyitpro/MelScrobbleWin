Public Class About


    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Label2.Text = "Version " + My.Application.Info.Version.ToString
    End Sub
End Class