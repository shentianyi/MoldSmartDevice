namespace ToolingDataSys
{
    partial class LoadFileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.FilePathTB = new System.Windows.Forms.TextBox();
            this.PickFileBtn = new System.Windows.Forms.Button();
            this.ImBtn = new System.Windows.Forms.Button();
            this.filedia = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件路径";
            // 
            // FilePathTB
            // 
            this.FilePathTB.Location = new System.Drawing.Point(92, 36);
            this.FilePathTB.Name = "FilePathTB";
            this.FilePathTB.Size = new System.Drawing.Size(356, 21);
            this.FilePathTB.TabIndex = 1;
            // 
            // PickFileBtn
            // 
            this.PickFileBtn.Location = new System.Drawing.Point(454, 34);
            this.PickFileBtn.Name = "PickFileBtn";
            this.PickFileBtn.Size = new System.Drawing.Size(106, 23);
            this.PickFileBtn.TabIndex = 2;
            this.PickFileBtn.Text = "选择文件";
            this.PickFileBtn.UseVisualStyleBackColor = true;
            this.PickFileBtn.Click += new System.EventHandler(this.PickFileBtn_Click);
            // 
            // ImBtn
            // 
            this.ImBtn.Location = new System.Drawing.Point(454, 96);
            this.ImBtn.Name = "ImBtn";
            this.ImBtn.Size = new System.Drawing.Size(106, 57);
            this.ImBtn.TabIndex = 3;
            this.ImBtn.Text = "导入";
            this.ImBtn.UseVisualStyleBackColor = true;
            this.ImBtn.Click += new System.EventHandler(this.ImBtn_Click);
            // 
            // filedia
            // 
            this.filedia.Filter = "Excel (*.xls)|*.xls";
            // 
            // LoadFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 179);
            this.Controls.Add(this.ImBtn);
            this.Controls.Add(this.PickFileBtn);
            this.Controls.Add(this.FilePathTB);
            this.Controls.Add(this.label1);
            this.Name = "LoadFileForm";
            this.Text = "导入文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FilePathTB;
        private System.Windows.Forms.Button PickFileBtn;
        private System.Windows.Forms.Button ImBtn;
        private System.Windows.Forms.OpenFileDialog filedia;
    }
}