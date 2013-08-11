namespace ToolingDataSys
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ImPosiBtn = new System.Windows.Forms.Button();
            this.ImpMoldCateBtn = new System.Windows.Forms.Button();
            this.ImProjectBtn = new System.Windows.Forms.Button();
            this.ImpEmpBtn = new System.Windows.Forms.Button();
            this.ImpMoldTypeBtn = new System.Windows.Forms.Button();
            this.ImpWorkstationBtn = new System.Windows.Forms.Button();
            this.ImpMold = new System.Windows.Forms.Button();
            this.dataManTab = new System.Windows.Forms.TabControl();
            this.addData = new System.Windows.Forms.TabPage();
            this.deleteData = new System.Windows.Forms.TabPage();
            this.dataManTab.SuspendLayout();
            this.addData.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImPosiBtn
            // 
            this.ImPosiBtn.Location = new System.Drawing.Point(58, 34);
            this.ImPosiBtn.Name = "ImPosiBtn";
            this.ImPosiBtn.Size = new System.Drawing.Size(113, 48);
            this.ImPosiBtn.TabIndex = 0;
            this.ImPosiBtn.Text = "导入库位";
            this.ImPosiBtn.UseVisualStyleBackColor = true;
            this.ImPosiBtn.Click += new System.EventHandler(this.ImPosiBtn_Click);
            // 
            // ImpMoldCateBtn
            // 
            this.ImpMoldCateBtn.Location = new System.Drawing.Point(58, 102);
            this.ImpMoldCateBtn.Name = "ImpMoldCateBtn";
            this.ImpMoldCateBtn.Size = new System.Drawing.Size(113, 48);
            this.ImpMoldCateBtn.TabIndex = 1;
            this.ImpMoldCateBtn.Text = "导入模具种类";
            this.ImpMoldCateBtn.UseVisualStyleBackColor = true;
            this.ImpMoldCateBtn.Click += new System.EventHandler(this.ImpMoldCateBtn_Click);
            // 
            // ImProjectBtn
            // 
            this.ImProjectBtn.Location = new System.Drawing.Point(198, 34);
            this.ImProjectBtn.Name = "ImProjectBtn";
            this.ImProjectBtn.Size = new System.Drawing.Size(113, 48);
            this.ImProjectBtn.TabIndex = 2;
            this.ImProjectBtn.Text = "导入成本中心";
            this.ImProjectBtn.UseVisualStyleBackColor = true;
            this.ImProjectBtn.Click += new System.EventHandler(this.ImProjectBtn_Click);
            // 
            // ImpEmpBtn
            // 
            this.ImpEmpBtn.Location = new System.Drawing.Point(331, 34);
            this.ImpEmpBtn.Name = "ImpEmpBtn";
            this.ImpEmpBtn.Size = new System.Drawing.Size(113, 48);
            this.ImpEmpBtn.TabIndex = 3;
            this.ImpEmpBtn.Text = "导入员工";
            this.ImpEmpBtn.UseVisualStyleBackColor = true;
            this.ImpEmpBtn.Click += new System.EventHandler(this.ImpEmpBtn_Click);
            // 
            // ImpMoldTypeBtn
            // 
            this.ImpMoldTypeBtn.Location = new System.Drawing.Point(198, 102);
            this.ImpMoldTypeBtn.Name = "ImpMoldTypeBtn";
            this.ImpMoldTypeBtn.Size = new System.Drawing.Size(113, 48);
            this.ImpMoldTypeBtn.TabIndex = 4;
            this.ImpMoldTypeBtn.Text = "导入模具型号";
            this.ImpMoldTypeBtn.UseVisualStyleBackColor = true;
            this.ImpMoldTypeBtn.Click += new System.EventHandler(this.ImpMoldTypeBtn_Click);
            // 
            // ImpWorkstationBtn
            // 
            this.ImpWorkstationBtn.Location = new System.Drawing.Point(331, 102);
            this.ImpWorkstationBtn.Name = "ImpWorkstationBtn";
            this.ImpWorkstationBtn.Size = new System.Drawing.Size(113, 48);
            this.ImpWorkstationBtn.TabIndex = 5;
            this.ImpWorkstationBtn.Text = "导入工作台";
            this.ImpWorkstationBtn.UseVisualStyleBackColor = true;
            this.ImpWorkstationBtn.Click += new System.EventHandler(this.ImpWorkstationBtn_Click);
            // 
            // ImpMold
            // 
            this.ImpMold.Location = new System.Drawing.Point(58, 192);
            this.ImpMold.Name = "ImpMold";
            this.ImpMold.Size = new System.Drawing.Size(113, 48);
            this.ImpMold.TabIndex = 6;
            this.ImpMold.Text = "导入模具";
            this.ImpMold.UseVisualStyleBackColor = true;
            this.ImpMold.Click += new System.EventHandler(this.ImpMold_Click);
            // 
            // dataManTab
            // 
            this.dataManTab.Controls.Add(this.addData);
            this.dataManTab.Controls.Add(this.deleteData);
            this.dataManTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataManTab.Location = new System.Drawing.Point(0, 0);
            this.dataManTab.Name = "dataManTab";
            this.dataManTab.SelectedIndex = 0;
            this.dataManTab.Size = new System.Drawing.Size(607, 381);
            this.dataManTab.TabIndex = 7;
            // 
            // addData
            // 
            this.addData.Controls.Add(this.ImPosiBtn);
            this.addData.Controls.Add(this.ImpMold);
            this.addData.Controls.Add(this.ImpMoldCateBtn);
            this.addData.Controls.Add(this.ImpWorkstationBtn);
            this.addData.Controls.Add(this.ImProjectBtn);
            this.addData.Controls.Add(this.ImpMoldTypeBtn);
            this.addData.Controls.Add(this.ImpEmpBtn);
            this.addData.Location = new System.Drawing.Point(4, 22);
            this.addData.Name = "addData";
            this.addData.Padding = new System.Windows.Forms.Padding(3);
            this.addData.Size = new System.Drawing.Size(599, 355);
            this.addData.TabIndex = 0;
            this.addData.Text = "导入数据";
            this.addData.UseVisualStyleBackColor = true;
            // 
            // deleteData
            // 
            this.deleteData.Location = new System.Drawing.Point(4, 22);
            this.deleteData.Name = "deleteData";
            this.deleteData.Padding = new System.Windows.Forms.Padding(3);
            this.deleteData.Size = new System.Drawing.Size(599, 355);
            this.deleteData.TabIndex = 1;
            this.deleteData.Text = "删除数据";
            this.deleteData.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 381);
            this.Controls.Add(this.dataManTab);
            this.Name = "MainForm";
            this.Text = "模具数据管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.dataManTab.ResumeLayout(false);
            this.addData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ImPosiBtn;
        private System.Windows.Forms.Button ImpMoldCateBtn;
        private System.Windows.Forms.Button ImProjectBtn;
        private System.Windows.Forms.Button ImpEmpBtn;
        private System.Windows.Forms.Button ImpMoldTypeBtn;
        private System.Windows.Forms.Button ImpWorkstationBtn;
        private System.Windows.Forms.Button ImpMold;
        private System.Windows.Forms.TabControl dataManTab;
        private System.Windows.Forms.TabPage addData;
        private System.Windows.Forms.TabPage deleteData;
    }
}

