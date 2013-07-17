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
using Ch4_1.Web;
using System.ServiceModel.DomainServices.Client;

namespace Ch4_1
{
    public partial class MainPage : UserControl
    {
        private FriendsContext context = new FriendsContext();

        private LoadOperation<MyFriends> loadOp;

        public MainPage()
        {
            InitializeComponent();
            loadOp = this.context.Load(this.context.GetMyFriendsQuery());
            loadOp.Completed += new EventHandler(loadOp_Completed);
        }

        void loadOp_Completed(object sender, EventArgs e)
        {
            FriendsGrid.ItemsSource = loadOp.Entities;
        }
    }
}
