<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class inputPsw
    Inherits System.Windows.Forms.Form

    '窗体重写释放，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.TextBox_psw = New System.Windows.Forms.TextBox
        Me.Button_ok = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextBox_psw
        '
        Me.TextBox_psw.Location = New System.Drawing.Point(14, 12)
        Me.TextBox_psw.Name = "TextBox_psw"
        Me.TextBox_psw.Size = New System.Drawing.Size(136, 23)
        Me.TextBox_psw.TabIndex = 0
        '
        'Button_ok
        '
        Me.Button_ok.BackColor = System.Drawing.Color.White
        Me.Button_ok.Location = New System.Drawing.Point(78, 41)
        Me.Button_ok.Name = "Button_ok"
        Me.Button_ok.Size = New System.Drawing.Size(72, 20)
        Me.Button_ok.TabIndex = 1
        Me.Button_ok.Text = "确定"
        '
        'inputPsw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(169, 73)
        Me.Controls.Add(Me.Button_ok)
        Me.Controls.Add(Me.TextBox_psw)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "inputPsw"
        Me.Text = "请输入密码"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBox_psw As System.Windows.Forms.TextBox
    Friend WithEvents Button_ok As System.Windows.Forms.Button
End Class
