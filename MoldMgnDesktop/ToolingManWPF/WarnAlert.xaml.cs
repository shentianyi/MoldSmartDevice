using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToolingManWPF.MoldPartInfoServiceReference;

namespace ToolingManWPF
{
    /// <summary>
    /// WarnAlert.xaml 的交互逻辑
    /// </summary>
    public partial class WarnAlert : Window
    {
        public static bool Shown = false;
        public WarnAlert(List<MoldWarnInfo> warnInfos)
        {
            InitializeComponent(); 
            Shown = true;
            MoldBaseInfoDG.ItemsSource = warnInfos; 
            Left = SystemParameters.WorkArea.Width - Width;
            Top = SystemParameters.WorkArea.Height - Height;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Shown = false;
        }  
    }
}
