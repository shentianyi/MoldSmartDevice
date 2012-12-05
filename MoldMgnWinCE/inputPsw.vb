Public Class inputPsw
    Private psl As List(Of String)
    Public Sub New(ByRef psw As List(Of String))
        psl = psw
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()


        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub
    Private Sub Button_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_ok.Click
        psl.Add(TextBox_psw.Text)
        Me.Close()
    End Sub

    Private Sub TextBox_psw_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_psw.KeyPress
        If Convert.ToInt16(e.KeyChar) = 13 Then
            psl.Add(TextBox_psw.Text)
            Me.Close()
        End If
    End Sub

    Private Sub TextBox_psw_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_psw.TextChanged

    End Sub
End Class