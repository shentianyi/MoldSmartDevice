using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolingDataSys.Code;

namespace ToolingDataSys
{
    public partial class LoadFileForm : Form
    {
        IFileData file = null;
        public LoadFileForm(IFileData file)
        {
            InitializeComponent();
            this.file = file;
        }

        private void PickFileBtn_Click(object sender, EventArgs e)
        {
            if (filedia.ShowDialog() == DialogResult.OK)
            {
                FilePathTB.Text = filedia.FileName;
            }
        }

        private void ImBtn_Click(object sender, EventArgs e)
        {
            if (FilePathTB.Text.Length > 0)
            {
              ImExcel excel = new ImExcel();
              DataTable dt=  excel.LoadExcel(FilePathTB.Text);
                List<ToolingDataSys.Code.Message> message=file.Insert(dt);
             
                    if (message.Count > 0)
                    {
                        new MessageDialog(message).ShowDialog();
                    }
                    else {
                        MessageBox.Show("导入成功！");
                    }
            }
        }
    }
}
