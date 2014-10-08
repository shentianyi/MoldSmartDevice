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
using System.Windows.Threading;
using ToolingManWPF.ConditionServiceReference;
using ToolingManWPF.MoldPartInfoServiceReference;
using Microsoft.Win32;
using ToolingManWPF.Helper;

namespace ToolingManWPF
{
    /// <summary>
    /// MoldWarnInfos.xaml 的交互逻辑
    /// </summary>
    public partial class MoldWarnInfos : Window
    {
        SaveFileDialog saveFileDialog = null;

        /// <summary>
        /// 实例化窗体
        /// </summary>
        private MoldWarnInfos()
        {
            InitializeComponent();
        }
        private static MoldWarnInfos instance = null;

        static readonly object padlock = new object();
        public static MoldWarnInfos Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) { instance = new MoldWarnInfos(); }
                    return instance;
                }
            }
        }

        private delegate void LoadConditionDelegate();
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new LoadConditionDelegate(LoadConditions));
            // LoadConditions();
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "导出Excel (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.Title = "导出文件保存路径";
        }
        /// <summary>
        /// 加载模具警报条件
        /// </summary>
        private void LoadConditions()
        {
            ConditionServiceClient conditionClient = new ConditionServiceClient();
            List<EnumItem> warnItems = conditionClient.GetEnumItems(typeof(MoldWarnType).ToString());
            WarnCB.ItemsSource = warnItems;

        }
        /// <summary>
        /// 按钮点击事件-模具警报信息搜索
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            MoldPartInfoServiceClient client = new MoldPartInfoServiceClient();
            List<MoldWarnInfo> warnInfos=client.GetMoldWarnInfo((MoldWarnType)(int.Parse(WarnCB.SelectedValue.ToString())));
            MoldBaseInfoDG.ItemsSource = warnInfos;
        }
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
             saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
             if ((bool)saveFileDialog.ShowDialog())
             {
                 MoldPartInfoServiceClient client = new MoldPartInfoServiceClient();
                 List<MoldWarnInfo> warnInfos = client.GetMoldWarnInfo((MoldWarnType)(int.Parse(WarnCB.SelectedValue.ToString())));
                 string[] headers = { "模具号","借出员工", "成本中心", "当前位置", "维护周期","借出时间","应还时间","相距时间"};
                 string[] pathes = { "MoldNR", "ApplicantId", "ProjectName", "CurrentPosition", "MaxLendHour", "LendTime", "ShouldReTime", "DisTimeText" };
                 if (warnInfos.Count > 0)
                     if (GenExcelHelper.GenExcel<MoldWarnInfo>(saveFileDialog.FileName, "超期数据", headers, pathes, warnInfos))
                         MessageBox.Show("数据导出成功，请到保存路径查看");
                     else
                         MessageBox.Show("数据导出失败(可能指定文件已经打开)，请重试");
                 else
                     MessageBox.Show("不存在记录数据");
             }
        }

      
    }
}
