﻿using System;
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
using ToolingManWPF.ConditionServiceReference;
using ToolingManWPF.Properties;
using ToolingManWPF.MoldPartInfoServiceReference;
using ToolingManWPF.StorageManageServiceReference;
using ToolingManWPF.Utilities;
using System.Windows.Threading;
using System.Threading;

namespace ToolingManWPF
{
    /// <summary>
    /// Search.xaml 的交互逻辑
    /// </summary>
    public partial class Search : Window
    {
        /// <summary>
        /// 实例化窗体
        /// </summary>
        private Search()
        {
            InitializeComponent();
        }

        private static Search instance = null;
        static readonly object padlock = new object();
        public static Search Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) { instance = new Search(); }
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
          this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,new LoadConditionDelegate(LoadConditions));
           // LoadConditions();
        }
        /// <summary>
        /// 按钮点击事件-搜索模具
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            MoldSearchCondition condition = new MoldSearchCondition();
            condition.MoldNR = MoldNRTB.Text+";"+PositionTB.Text;
            condition.MoldTypeId = MoldTypeCB.SelectedIndex < 1 ? string.Empty : MoldTypeCB.SelectedValue.ToString();
            condition.ProjectId = ProjectCB.SelectedIndex <1 ? string.Empty :ProjectCB.SelectedValue.ToString();
            condition.State = StateCB.SelectedIndex < 1 ? ToolingManWPF.MoldPartInfoServiceReference.MoldStateType.NULL : (ToolingManWPF.MoldPartInfoServiceReference.MoldStateType)(int.Parse(StateCB.SelectedValue.ToString()));
            //condition.Warn = WarnCB.SelectedIndex < 1 ? MoldWarnType.NULL : (MoldWarnType)(int.Parse(WarnCB.SelectedValue.ToString()));
          
            MoldPartInfoServiceClient client=new MoldPartInfoServiceClient ();
            List<MoldBaseInfo> moldBaseInfo = client.GetMoldByMutiConditions(condition);
            MoldBaseInfoDG.ItemsSource = moldBaseInfo;
        }

        /// <summary>
        /// 加载选择条件
        /// </summary>
        private void LoadConditions()
        {
            ConditionServiceClient conditionClient = new ConditionServiceClient();
            
            ConfigUtil config = new ConfigUtil("partgroup");
            // load the select conditions

            //List<MoldCategory> moldTypes = conditionClient.GetMoldTypes();
            //moldTypes.Insert(0, new MoldCategory() { MoldCateID = string.Empty, Name = "--------全部-------" });
            //MoldTypeCB.ItemsSource = moldTypes;

            List<MoldType> moldTypes = conditionClient.GetMoldTypes();
            moldTypes.Insert(0, new MoldType() { MoldTypeID = string.Empty, Name = "--------全部-------" });
            MoldTypeCB.ItemsSource = moldTypes;


            List<Project> projects = conditionClient.GetProjects();
            projects.Insert(0, new Project() { ProjectID = string.Empty, Name = "--------全部-------" });
            ProjectCB.ItemsSource = projects;

            List<EnumItem> stateItems = conditionClient.GetEnumItems(typeof(ToolingManWPF.ConditionServiceReference.MoldStateType).ToString());
            stateItems.Insert(0,new EnumItem() { Value = "-1", Description = "--------全部-------" });
            StateCB.ItemsSource = stateItems;

            //List<EnumItem> warnItems = conditionClient.GetEnumItems(typeof(MoldWarnType).ToString());
            //warnItems.Insert(0,new EnumItem() { Value = "-1", Description = "--------全部-------" });
            //WarnCB.ItemsSource = warnItems;

        }

        /// <summary>
        /// 按钮点击事件-查看模具详细信息
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void DetailBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MoldBaseInfoDG.SelectedItem != null)
            {
                MoldBaseInfo moldBaseInfo = MoldBaseInfoDG.SelectedItem as MoldBaseInfo;
                ToolInfo toolInfo = new ToolInfo(moldBaseInfo.MoldNR);
                toolInfo.ShowDialog();
            }

        }
        /// <summary>
        /// 按钮点击事件-申领模具
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MoldBaseInfoDG.SelectedItem != null)
            {
                MoldBaseInfo moldBaseInfo = MoldBaseInfoDG.SelectedItem as MoldBaseInfo;
                 if (moldBaseInfo.State != ToolingManWPF.MoldPartInfoServiceReference.MoldStateType.NotReturned)
                 {
                    MoldApply moldApply = new MoldApply(moldBaseInfo);
                    moldApply.ShowDialog();
                }
          }
        }

        /// <summary>
        /// 按钮点击事件-归还模具
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MoldBaseInfoDG.SelectedItem != null)
            {
                MoldBaseInfo moldBaseInfo = MoldBaseInfoDG.SelectedItem as MoldBaseInfo;
                if (moldBaseInfo.State == ToolingManWPF.MoldPartInfoServiceReference.MoldStateType.NotReturned)
                {
                    MoldReturn moldReturn = new MoldReturn(moldBaseInfo.MoldNR);
                    moldReturn.ShowDialog();
                }
            }
        }
        /// <summary>
        /// 按钮点击事件-模具入库
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void MoldInStoreBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MoldBaseInfoDG.SelectedItem != null)
            {
                MoldBaseInfo moldBaseInfo = MoldBaseInfoDG.SelectedItem as MoldBaseInfo;
                if (moldBaseInfo.CurrentPosition == (new StorageManageServiceClient()).GetPartPoolPosiNr())
                {
                    //MoldReturn moldReturn = new MoldReturn(moldBaseInfo.MoldNR);
                    //moldReturn.Show();
                    MoldInStore mis = new MoldInStore(moldBaseInfo.MoldNR);
                    mis.ShowDialog();
                }
            }
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

        private void MoldNRTB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchBtn_Click(sender, e);
            }
        }

        private void MoldNRTB_GotFocus(object sender, RoutedEventArgs e)
        {
            MoldNRTB.Text = string.Empty;
        }

        private void PositionTB_GotFocus(object sender, RoutedEventArgs e)
        {
            PositionTB.Text = string.Empty;
        }

    }
}
