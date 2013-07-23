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
using System.IO;
using System.Windows.Media.Imaging;

namespace Ch8_3
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.HasElevatedPermissions)
            {
                string myPics = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                textBlock1.Text = myPics;

                string myPic = myPics + "\\Lighthouse.jpg";
                using (StreamReader reader = new StreamReader(myPic))
                {
                    using (Stream stream = reader.BaseStream)
                    {
                        BitmapImage image = new BitmapImage();
                        image.SetSource(stream);
                        image1.Source = image;
                    }
                }
            }
        }
    }
}
