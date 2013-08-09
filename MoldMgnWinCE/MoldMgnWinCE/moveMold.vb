Imports MoldMgnWinCE.SVCUtil
Imports System.Media
Imports System.IO

Public Class moveMold



    Private Sub Clear()
        Me.TextBox_moldId.Text = ""
        Me.TextBox_WrkStNr.Text = ""
        Me.TextBox_moldId.Focus()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_clear.Click
        Clear()
    End Sub

    Private Function GetSoundPlayer() As SoundPlayer
        Return New SoundPlayer
    End Function
    Private Sub Button_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_ok.Click
        If String.IsNullOrEmpty(Me.TextBox_moldId.Text) Or String.IsNullOrEmpty(Me.TextBox_operator.Text) Or String.IsNullOrEmpty(Me.TextBox_WrkStNr.Text) Then

            MsgBox("请填写详细信息")
            Exit Sub
        End If
        Dim msg As Message
        Try
            msg = GetSvc.MoldMoveWorkStation(TextBox_moldId.Text, TextBox_operator.Text, TextBox_WrkStNr.Text)
        Catch ex As Exception

        End Try

        If msg Is Nothing Then
            MsgBox("系统错误，可能是网络问题造成，请联系管理员", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If msg.MsgType <> MsgType.OK Then


            MsgBox("转移模具失败：" & msg.Content, MsgBoxStyle.Critical)
        Else
            MsgBox("转移成功！", MsgBoxStyle.Information)
            Clear()
        End If
    End Sub

    Private Sub Label1_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.ParentChanged

    End Sub

  

    Private Sub Label4_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.ParentChanged

    End Sub

    Private Sub TextBox_operator_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_operator.GotFocus
       
    End Sub


    Private Sub TextBox_operator_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_operator.LostFocus
        Me.TextBox_operator.Enabled = False

    End Sub

    Private Sub TextBox_operator_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_operator.TextChanged

    End Sub

    Private Sub TextBox_moldId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_moldId.KeyPress
        If Convert.ToInt16(e.KeyChar) = 13 Then
            Me.TextBox_WrkStNr.Focus()
        End If

    End Sub

    Private Sub TextBox_moldId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_moldId.TextChanged

    End Sub

    Private Sub TextBox_WrkStNr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_WrkStNr.KeyPress
        If Convert.ToInt16(e.KeyChar) = 13 Then
            Me.Button_ok.Focus()
        End If
    End Sub

    Private Sub TextBox_WrkStNr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_WrkStNr.TextChanged

    End Sub

    Private Sub Button_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_back.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.TextBox_operator.Enabled = True
        Me.TextBox_operator.Focus()
        Me.TextBox_operator.SelectAll()
    End Sub
End Class
