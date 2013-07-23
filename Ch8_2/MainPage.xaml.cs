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
using System.IO.IsolatedStorage;
using System.IO;

namespace Ch8_2
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            //检测隔离存储是否启用
            if (IsolatedStorageFile.IsEnabled)
            {
                //获取隔离存储文件引用
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    //store.OpenFile("MyStore.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                    using (StreamWriter sw = new StreamWriter(store.OpenFile("MyStore.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)))
                    {
                        sw.WriteLine(textBox1.Text);
                    }

                }
            }
            else 
            { 
                MessageBox.Show("不允许"); 
            }
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            //检测隔离存储是否启用
            if (IsolatedStorageFile.IsEnabled)
            {
                //获取隔离存储文件引用
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    //store.OpenFile("MyStore.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                    using (StreamReader sr = new StreamReader(store.OpenFile("MyStore.txt", System.IO.FileMode.Open, System.IO.FileAccess.Read)))
                    {
                        textBlock1.Text = sr.ReadToEnd();
                    }

                }
            }
            else
            {
                MessageBox.Show("不允许");
            }
        }

        

        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            //检测隔离存储是否启用
            if (IsolatedStorageFile.IsEnabled)
            {
                //获取隔离存储文件引用
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    Int64 newSpace = 2097152;
                    Int64 currSpace = store.AvailableFreeSpace;

                    if (currSpace < newSpace)
                    {
                        if (!store.IncreaseQuotaTo(newSpace))
                        {
                            MessageBox.Show("用户拒绝扩容！");
                        }
                        else
                        {
                            MessageBox.Show("隔离存储提升至 2 MB。");
                        }
                    }

                }
            }
        }
    }
}
