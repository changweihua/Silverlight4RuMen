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
using System.Runtime.InteropServices.Automation;

namespace Ch8_4
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.IsRunningOutOfBrowser && AutomationFactory.IsAvailable)
            {
                dynamic excel = AutomationFactory.CreateObject("Excel.Application");
                excel.Workbooks.Add();
                excel.Cells[1, 1] = "单元格 A1 ";
                excel.Cells[1, 2] = "单元格 B1 ";
                excel.Visible = true;

                NotificationWindow nWin = new NotificationWindow();
                nWin.Height = 100;
                nWin.Width = 320;
                TextBlock t = new TextBlock();
                t.FontSize = 24.0;
                t.Text = "Excel 准备就绪";
                nWin.Content = t;
                nWin.Show(2000);
            }
        }
    }
}
