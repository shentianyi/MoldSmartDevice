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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ImPosiBtn_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new PositionFile());
            file.ShowDialog();
        }

        private void ImpMoldCateBtn_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new MoldCateFile());
            file.ShowDialog();
        }

        private void ImProjectBtn_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new ProjectFile());
            file.ShowDialog();
        }

        private void ImpEmpBtn_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new EmployeeFile());
            file.ShowDialog();
        }

        private void ImpMoldTypeBtn_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new MoldTypeFile());
            file.ShowDialog();
        }

        private void ImpWorkstationBtn_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new WorkstationFile());
            file.ShowDialog();
        }

        private void ImpMold_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new MoldFile());
            file.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void UpdatePosiBtn_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new PositionFile(), FileDataOperateType.Update);
            file.ShowDialog();
        }

        private void UpdateMoldBtn_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new MoldFile(), FileDataOperateType.Update);
            file.ShowDialog();
        }

        private void DeletePosiBtn_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new PositionFile(), FileDataOperateType.Delete);
            file.ShowDialog();
        }

        private void DeleteMoldBtn_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new MoldFile(), FileDataOperateType.Delete);
            file.ShowDialog();
        }

        private void UpdateMoldPosiBtn_Click(object sender, EventArgs e)
        {
            LoadFileForm file = new LoadFileForm(new MoldFile(), FileDataOperateType.TransPosition);
            file.ShowDialog();
        } 
         
    }
}
