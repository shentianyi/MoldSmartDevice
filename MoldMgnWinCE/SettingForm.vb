Imports System.IO
Public Class SettingForm


    Private Sub Button_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_ok.Click

        Try
            Dim rd As StreamWriter = New StreamWriter("setting.txt", False)
            rd.WriteLine(Me.TextBox_Setting.Text)
            rd.Close()
            MsgBox("修改成功")
        Catch ex As Exception
            MsgBox("读取配置文件时失败")
        End Try
       
    End Sub

    Private Sub SettingForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim reader As StreamReader = New StreamReader("setting.txt")
            reader.ReadLine()
            Me.TextBox_Setting.Text = reader.ReadLine
            reader.Close()
        Catch ex As Exception
            MsgBox("读取配置文件时失败")
        End Try

    End Sub
End Class