using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Net.NetworkInformation;

namespace Ch8_1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            try
            {
                //检测安装状态
                if (Application.Current.InstallState != InstallState.Installed)
                {
                    button2.Visibility = System.Windows.Visibility.Visible;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            //检测状态
            if (Application.Current.IsRunningOutOfBrowser)
            {
                textBlock1.Text = "我正运行于计算机";
            }
            else
            {
                textBlock1.Text = "我正运行于浏览器";
            }

            //检测网络连接性和可用性
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(NetworkChange_NetworkAddressChanged);

            //检查更新和下载更新内容
            Application.Current.CheckAndDownloadUpdateCompleted += new CheckAndDownloadUpdateCompletedEventHandler(Current_CheckAndDownloadUpdateCompleted);
            Application.Current.CheckAndDownloadUpdateAsync();
        }

        void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            //会被调用多次
            ChildWindow cw = new ChildWindow();
            cw.Title = "联网信息";

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                cw.Content = "联机状态";
            }
            else
            {
                cw.Content = "脱机状态";
            }
            cw.Show();
        }

        void Current_CheckAndDownloadUpdateCompleted(object sender, CheckAndDownloadUpdateCompletedEventArgs e)
        {
            if (e.UpdateAvailable)
            {
                ChildWindow cw = new ChildWindow();
                cw.Title = "该应用程序已经更新";
                cw.Content = "已下载并安装了这个应用程序的新版本。请重启以运行新版本。";
                cw.Show();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("我现在是桌面应用程序!");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Install();
        }
    }
}
