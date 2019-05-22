using System;
using System.Windows;
using System.Windows.Controls;
using ZooKeeper.AccessManager;
using ZooKeeper.ZooManager;
using ZooKeeper.Validators;

namespace ZooKeeper.Pages
{
    public partial class ZooKeeperHome : Page
    {
        public ZooKeeperHome()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = this.LoginBox.Text;
                string password = this.PasswordBox.Password;
                IZooLoader loader = new ProtectedZooLoader();
                ZooPark park = loader.GetZoo(username, password);
                ZooPage zooPage = new ZooPage(park);
                this.NavigationService.Navigate(zooPage);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = this.LoginBox.Text;
                string password = this.PasswordBox.Password;
                Registrator.RegisterUser(username, password);
                MessageBox.Show("Registered Successfuly!", "Success");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception");
            }
        }
    }
}
