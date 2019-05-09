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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZooKeeper.ZooManager;
using ZooKeeper.Animals;

namespace ZooKeeper.Pages
{
    /// <summary>
    /// Interaction logic for ZooPage.xaml
    /// </summary>
    public partial class ZooPage : Page, IObserver
    {

        public ZooPage(ZooPark zooPark)
        {
            InitializeComponent();
            zooPark.AddObserver(this);
            new StrategyController(zooPark);
            AnimalsList.ItemsSource = zooPark.animals;
            UsernameBox.Text += zooPark.user.Username;
            LevelBox.Text += zooPark.user.Level;
            MoneyBox.Text += zooPark.user.Money;
        }

        public void Update(int level)
        {
            DisplayLevel(level);
            MessageBox.Show($"You got a new level {level}", "Hurray!");
        }

        private void Premium_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = this.NameBox.Text;
                ZooPark park = ZooPark.GetInstance();
                Animal animal = park.GetAnimal(name, new PremiumStore());
                DisplayMoney(park.user.Money);
                this.NameBox.Text = "";
                ShowCreatedAnimal(animal.AnimalType, animal.Name, animal.Color);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception");
            }
            
        }

        private void Middle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = this.NameBox.Text;
                ZooPark park = ZooPark.GetInstance();
                Animal animal = park.GetAnimal(name, new MiddleLevelStore());
                DisplayMoney(park.user.Money);
                this.NameBox.Text = "";
                ShowCreatedAnimal(animal.AnimalType, animal.Name, animal.Color);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception");
            }
        }

        private void Decent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = this.NameBox.Text;
                ZooPark park = ZooPark.GetInstance();
                Animal animal = park.GetAnimal(name, new DecentStore());
                DisplayMoney(park.user.Money);
                this.NameBox.Text = "";
                ShowCreatedAnimal(animal.AnimalType, animal.Name, animal.Color);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception");
            }
        }

        private void ShowCreatedAnimal(AnimalType type, string name, Color color)
        {
            if (name.Length > 0)
            {
                MessageBox.Show($"You got a new {type} {name} with {color} color", "Congrats!");
            }
            else
            {
                MessageBox.Show($"You got a new {type} with {color} color", "Congrats!");
            }
        }

        private void AnimalsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var animal = (Animal)item.SelectedItem;
            AnimalInfo.Navigate(new AnimalPage(animal));
        }

        private void Collect_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            ZooPark park = ZooPark.GetInstance();
            int amount = park.AddMoney();
            DisplayMoney(park.user.Money);
            MessageBox.Show($"You got {amount}$. Raise your level to get more. +10$ for each new level", "Hurray!");
        }

        private void DisplayMoney(int amount)
        {
            MoneyBox.Text = $"Money: {amount}";
        }

        private void DisplayLevel(int level)
        {
            LevelBox.Text = $"Level: {level}";
        }
    }
}
