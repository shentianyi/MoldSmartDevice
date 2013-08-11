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

namespace ToolingManWPF
{
    /// <summary>
    /// DataMan.xaml 的交互逻辑
    /// </summary>
    public partial class DataMan : Window
    {
        private static DataExporter instance = null;
        static readonly object padlock = new object();
        public static DataExporter Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) { instance = new DataExporter(); }
                    return instance;
                }
            }
        }
        public DataMan()
        {
            InitializeComponent();
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
    }
}
