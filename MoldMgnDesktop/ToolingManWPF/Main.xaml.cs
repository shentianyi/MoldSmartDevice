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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using ToolingManWPF.ConditionServiceReference;
using System.Windows.Threading;
using ToolingManWPF.MoldPartInfoServiceReference;

namespace ToolingManWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dTimer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            dTimer.IsEnabled = true;

            dTimer.Interval = new TimeSpan(0, 30, 0);
            dTimer.Tick += new EventHandler(DataTimer_Tick);
            dTimer.Start();
        }
        private void DataTimer_Tick(object sender, EventArgs e)
        {
            if (!WarnAlert.Shown)
            {
                MoldPartInfoServiceClient client = new MoldPartInfoServiceClient();
                List<MoldWarnInfo> warnInfos = client.GetMoldWarnInfo(MoldWarnType.OutTime);
                if (warnInfos.Count > 0)
                {
                    new WarnAlert(warnInfos).Show();
                }
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        { 
            Search.Instance.Show();
            Search.Instance.Activate();
        }
        private void ToolInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            ToolInfo.Instance.Show();
            ToolInfo.Instance.Activate();
        }
        private void MoldInStoreBtn_Click(object sender, RoutedEventArgs e)
        {
            MoldInStore.Instance.Show();
            MoldInStore.Instance.Activate();

        }

        private void MoldWarnInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            MoldWarnInfos.Instance.Show();
            MoldWarnInfos.Instance.Activate();
        }

        private void MoldLabBtn_Click(object sender, RoutedEventArgs e)
        {
            Lab.Instance.Show();
            Lab.Instance.Activate();
        }

        private void DataExportBtn_Click(object sender, RoutedEventArgs e)
        {
            DataExporter.Instance.Show();
            DataExporter.Instance.Activate();
        }

        private void DataManBtn_Click(object sender, RoutedEventArgs e)
        {
            DataMan.Instance.Show();
            DataMan.Instance.Activate();
        }

      
      
    }
}
