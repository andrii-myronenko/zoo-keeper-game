using System;
using System.Windows;
using System.Windows.Controls;
using ZooKeeper.ZooManager;
using ZooKeeper.Animals;
using ZooKeeper.ObserverInterfaces;

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
            AnimalsList.ItemsSource = zooPark.animals;
            UsernameBox.Text += zooPark.user.Username;
            DisplayLevel(zooPark.user.Level);
            DisplayMoney(zooPark.user.Money);
        }
        
        private void Premium_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = this.NameBox.Text;
                Animal animal = ZooPark.GetInstance().BuyRandomAnimal(name, new PremiumStore());
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
                Animal animal = ZooPark.GetInstance().BuyRandomAnimal(name, new MiddleLevelStore());
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
                Animal animal = ZooPark.GetInstance().BuyRandomAnimal(name, new DecentStore());
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
            int amount = ZooPark.GetInstance().AddMoney();
            MessageBox.Show($"You got {amount}$. Raise your level to get more. +10$ for each new level", "Hurray!");
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            var zooPark = ZooPark.GetInstance();
            MessageBox.Show($"Username: {zooPark.user.Username}\n" +
                $"Level: {zooPark.user.Level}\n" +
                $"All animals: {zooPark.animals.Count}\n" +
                $"Mammals fed: {zooPark.user.MammalsFed}\n" +
                $"Fishes fed: {zooPark.user.FishesFed}\n" +
                $"Birds fed: {zooPark.user.BirdsFed}", "Profile");
        }

        public void Update(ActionType actionType, int value)
        {
            switch (actionType)
            {
                case ActionType.LevelChanged:
                    DisplayLevel(value);
                    MessageBox.Show($"You got a new level {value}", "Hurray!");
                    break;
                case ActionType.MoneyChanged:
                    DisplayMoney(value);
                    break;
                default:
                    break;
            }
            
        }
        private void DisplayMoney(int moneyAmount)
        {
            MoneyBox.Text = $"Money: {moneyAmount}";
        }

        private void DisplayLevel(int level)
        {
            LevelBox.Text = $"Level: {level}\nNew level each 5 animals.";
        }
    }
}
