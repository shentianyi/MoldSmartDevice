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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim psl As List(Of String) = New List(Of String)
        Dim formPsw As inputPsw = New inputPsw(psl)
        formPsw.ShowDialog()


        If Not String.Compare(psl(0), "123456") = 0 Then
            MsgBox("密码错误")
        Else
            Dim setting As Form = New SettingForm
            setting.ShowDialog()
        End If
    End Sub
End Class