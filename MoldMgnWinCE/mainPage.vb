Public Class mainPage

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim form As moveMold = New moveMold
        Me.Hide()
        form.ShowDialog()
        Me.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim form As viewInfo = New viewInfo
        Me.Hide()
        form.ShowDialog()
        Me.Show()
    End Sub
End Class