<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class moveMold
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox_moldId = New System.Windows.Forms.TextBox
        Me.TextBox_WrkStNr = New System.Windows.Forms.TextBox
        Me.Button_ok = New System.Windows.Forms.Button
        Me.Button_clear = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox_operator = New System.Windows.Forms.TextBox
        Me.Button_back = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.Text = "请扫描模具号"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.Text = "请扫描工作台编号"
        '
        'TextBox_moldId
        '
        Me.TextBox_moldId.Location = New System.Drawing.Point(21, 78)
        Me.TextBox_moldId.Name = "TextBox_moldId"
        Me.TextBox_moldId.Size = New System.Drawing.Size(180, 23)
        Me.TextBox_moldId.TabIndex = 2
        '
        'TextBox_WrkStNr
        '
        Me.TextBox_WrkStNr.Location = New System.Drawing.Point(21, 127)
        Me.TextBox_WrkStNr.Name = "TextBox_WrkStNr"
        Me.TextBox_WrkStNr.Size = New System.Drawing.Size(180, 23)
        Me.TextBox_WrkStNr.TabIndex = 3
        '
        'Button_ok
        '
        Me.Button_ok.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button_ok.Location = New System.Drawing.Point(21, 230)
        Me.Button_ok.Name = "Button_ok"
        Me.Button_ok.Size = New System.Drawing.Size(70, 46)
        Me.Button_ok.TabIndex = 4
        Me.Button_ok.Text = "确定"
        '
        'Button_clear
        '
        Me.Button_clear.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button_clear.Location = New System.Drawing.Point(125, 230)
        Me.Button_clear.Name = "Button_clear"
        Me.Button_clear.Size = New System.Drawing.Size(76, 46)
        Me.Button_clear.TabIndex = 5
        Me.Button_clear.Text = "清空"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(153, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.Text = "LEONI"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(21, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 20)
        Me.Label4.Text = "当前操作人员(点击更换)"
        '
        'TextBox_operator
        '
        Me.TextBox_operator.Location = New System.Drawing.Point(21, 188)
        Me.TextBox_operator.Name = "TextBox_operator"
        Me.TextBox_operator.Size = New System.Drawing.Size(180, 23)
        Me.TextBox_operator.TabIndex = 10
        '
        'Button_back
        '
        Me.Button_back.BackColor = System.Drawing.Color.White
        Me.Button_back.Location = New System.Drawing.Point(19, 11)
        Me.Button_back.Name = "Button_back"
        Me.Button_back.Size = New System.Drawing.Size(72, 20)
        Me.Button_back.TabIndex = 15
        Me.Button_back.Text = "返回菜单"
        '
        'moveMold
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Controls.Add(Me.Button_back)
        Me.Controls.Add(Me.TextBox_operator)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button_clear)
        Me.Controls.Add(Me.Button_ok)
        Me.Controls.Add(Me.TextBox_WrkStNr)
        Me.Controls.Add(Me.TextBox_moldId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "moveMold"
        Me.Text = "转移工作台"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox_moldId As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_WrkStNr As System.Windows.Forms.TextBox
    Friend WithEvents Button_ok As System.Windows.Forms.Button
    Friend WithEvents Button_clear As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox_operator As System.Windows.Forms.TextBox
    Friend WithEvents Button_back As System.Windows.Forms.Button

End Class
