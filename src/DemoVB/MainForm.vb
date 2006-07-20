Public Class MainForm

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Using f As New SimpleForm
            f.ShowDialog(Me)
        End Using
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        Using f As New AggregateForm
            f.ShowDialog(Me)
        End Using
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        Close()
    End Sub
End Class
