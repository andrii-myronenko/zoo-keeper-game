using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
                ZooPark park = loader.GetZoo(new Credentials(username, password));
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
