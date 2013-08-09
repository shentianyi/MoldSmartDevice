<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class viewInfo
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
        Me.Button_back = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox_MoldId = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label_status = New System.Windows.Forms.Label
        Me.Labe_position = New System.Windows.Forms.Label
        Me.Label_Project = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_back
        '
        Me.Button_back.BackColor = System.Drawing.Color.White
        Me.Button_back.Location = New System.Drawing.Point(18, 13)
        Me.Button_back.Name = "Button_back"
        Me.Button_back.Size = New System.Drawing.Size(72, 20)
        Me.Button_back.TabIndex = 17
        Me.Button_back.Text = "返回菜单"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(152, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.Text = "LEONI"
        '
        'TextBox_MoldId
        '
        Me.TextBox_MoldId.Location = New System.Drawing.Point(18, 69)
        Me.TextBox_MoldId.Name = "TextBox_MoldId"
        Me.TextBox_MoldId.Size = New System.Drawing.Size(203, 23)
        Me.TextBox_MoldId.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.Text = "请输入模具ID"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.Controls.Add(Me.Label_status)
        Me.Panel1.Controls.Add(Me.Labe_position)
        Me.Panel1.Controls.Add(Me.Label_Project)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(18, 98)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(203, 191)
        '
        'Label_status
        '
        Me.Label_status.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label_status.Location = New System.Drawing.Point(109, 52)
        Me.Label_status.Name = "Label_status"
        Me.Label_status.Size = New System.Drawing.Size(76, 20)
        '
        'Labe_position
        '
        Me.Labe_position.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Labe_position.Location = New System.Drawing.Point(3, 124)
        Me.Labe_position.Name = "Labe_position"
        Me.Labe_position.Size = New System.Drawing.Size(134, 20)
        '
        'Label_Project
        '
        Me.Label_Project.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label_Project.Location = New System.Drawing.Point(3, 52)
        Me.Label_Project.Name = "Label_Project"
        Me.Label_Project.Size = New System.Drawing.Size(81, 20)
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(109, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 20)
        Me.Label6.Text = "状态"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(3, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 20)
        Me.Label5.Text = "项目"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.Text = "当前位置"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.Text = "详细信息"
        '
        'viewInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(238, 300)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox_MoldId)
        Me.Controls.Add(Me.Button_back)
        Me.Controls.Add(Me.Label3)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "viewInfo"
        Me.Text = "查看模具信息"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button_back As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox_MoldId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label_status As System.Windows.Forms.Label
    Friend WithEvents Labe_position As System.Windows.Forms.Label
    Friend WithEvents Label_Project As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
