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
using System.Windows.Threading;

namespace ch6_1
{
    public partial class MainPage : UserControl
    {
        DispatcherTimer vidTimer = new DispatcherTimer();

        public MainPage()
        {
            InitializeComponent();
            
        }

        void vidTimer_Tick(object sender, EventArgs e)
        {
            slider1.Value = mediaElement1.Position.Seconds;
        }

        private void mediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            slider1.Maximum = mediaElement1.NaturalDuration.TimeSpan.Ticks;

            TimelineMarker t = new TimelineMarker();
            t.Text = "这是动态添加的记号";
            t.Time = new TimeSpan(0, 0, 22);
            mediaElement1.Markers.Add(t);

            vidTimer.Interval = new TimeSpan(0, 0, 0, 1);
            vidTimer.Tick += new EventHandler(vidTimer_Tick);
            vidTimer.Start();

        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();
        }

        private void mediaElement1_MarkerReached(object sender, TimelineMarkerRoutedEventArgs e)
        {
            label1.Text = e.Marker.Text;
        }
    }
}
