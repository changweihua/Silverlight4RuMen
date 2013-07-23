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
using System.Windows.Browser;

namespace Ch9_1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            UpdateCities("德国");

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //向浏览器注册为 “可脚本处理”
            HtmlPage.RegisterScriptableObject("MySilverlightObject", this);
        }

        private List<CityData> getCities(string country)
        {
            List<CityData> cities = new List<CityData>();

            switch (country)
            {
                case "法国":
                    {
                        cities.Add(new CityData("巴黎", 48.87, 2.33));
                        cities.Add(new CityData("卢尔德", 43.1, 0.05));
                        cities.Add(new CityData("图卢兹", 43.6, 1.38));
                        break;
                    }
                case "英国":
                    {
                        cities.Add(new CityData("伦敦", 51.5, 0));
                        cities.Add(new CityData("斯特拉特福", 52.3, -1.71));
                        cities.Add(new CityData("爱丁堡", 55.95, -3.16));
                        break;
                    }
                case "德国":
                    {
                        cities.Add(new CityData("柏林", 52.52, 13.42));
                        cities.Add(new CityData("慕尼黑", 48.13, 11.57));
                        cities.Add(new CityData("汉堡", 53.58, 9.98));
                        break;
                    }
                default:
                    break;
            }

            return cities;
        }

        [ScriptableMember]//公开函数
        public void UpdateCities(string country)
        {
            List<CityData> myCities = getCities(country);
            itmCities.ItemsSource = myCities;
        }

    }
}
