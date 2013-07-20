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

namespace ch6_2
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            bool flag = CaptureDeviceConfiguration.RequestDeviceAccess();

            if (flag)
            {
                CaptureSource cs = new CaptureSource 
                { 
                    VideoCaptureDevice = CaptureDeviceConfiguration.GetDefaultVideoCaptureDevice()
                };

                VideoBrush brush = new VideoBrush();
                brush.SetSource(cs);

                cam.Fill = brush;
                cs.Start();

            }

        }
    }
}


