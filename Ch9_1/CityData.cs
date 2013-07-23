using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Ch9_1
{
    #region 作者和版权
    /*************************************************************************************
     * CLR 版本:       4.0.30319.18034
     * 类 名 称:       CityData
     * 机器名称:       LUMIA800
     * 命名空间:       Ch9_1
     * 文 件 名:       CityData
     * 创建时间:       2013/7/23 17:13:05
     * 作    者:       常伟华 Changweihua
	 * 版    权:	   CityData说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2013
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com  
     * 唯一标识：	   5d1ee116-5528-4c84-a40e-0f6af741ac54  
	 *
	 * 登录用户:       Changweihua
	 * 所 属 域:       Lumia800

	 * 创建年份:       2013
     * 修改时间:
     * 修 改 人:
     * 
     ************************************************************************************/
    #endregion

    /// <summary>
    /// 摘要
    /// </summary>
    public class CityData
    {
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public CityData(string cityName, double latitude, double longitude)
        {
            this.CityName = cityName;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

    }
}
