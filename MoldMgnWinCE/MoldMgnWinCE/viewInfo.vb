﻿Imports MoldMgnWinCE.Microsoft.Tools.ServiceModel

Public Class viewInfo

    Private Sub Button_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_back.Click
        Me.Close()
    End Sub

    Private Sub Label1_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.ParentChanged

    End Sub

    Private Sub Clear()
        Me.Label_status.Text = ""
        Me.Label_Project.Text = ""
        Me.Labe_position.Text = ""
    End Sub

    Private Sub TextBox_MoldId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_MoldId.GotFocus

        Me.TextBox_MoldId.SelectAll()

    End Sub

    Private Sub TextBox_MoldId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_MoldId.KeyPress
        If Convert.ToInt16(e.KeyChar) = 13 Then
            Clear()
            Dim dynamicinfo As MoldDynamicInfo
            Try
                dynamicinfo = SVCUtil.GetSvc().GetMoldDynamicInfoByMoldNR(Me.TextBox_MoldId.Text)
                If dynamicinfo Is Nothing Then
                    MsgBox("没有找到模具号下的信息")
                Else
                    BindElement(dynamicinfo)
                End If
            Catch exf As CFFaultException
                MsgBox("获取信息失败，可能是模具号不存在")
            Catch ex As Exception
                MsgBox("获取信息失败，可能是网络问题")
            End Try
            init()

        End If


    End Sub

    Private Sub BindElement(ByVal dynamicInfo As MoldDynamicInfo)
        If dynamicInfo IsNot Nothing Then
            Me.Labe_position.Text = dynamicInfo.CurrentPosition
            Me.Label_Project.Text = dynamicInfo.ProjectName
            Me.Label_status.Text = dynamicInfo.StateCN
        End If

    End Sub

    Private Sub TextBox_MoldId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_MoldId.TextChanged

    End Sub

    Private Sub Label_Project_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_Project.ParentChanged

    End Sub

    Private Sub viewInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        init()
    End Sub

    Private Sub init()
        Me.TextBox_MoldId.SelectAll()
        Me.TextBox_MoldId.Focus()

    End Sub
End Class