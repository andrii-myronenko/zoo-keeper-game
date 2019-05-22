using System.Windows;
using System;
using System.Windows.Controls;
using ZooKeeper.Animals;
using ZooKeeper.ZooManager;

namespace ZooKeeper.Pages
{
    public partial class AnimalPage : Page
    {
        private Animal selectedAnimal;

        public AnimalPage(Animal animal)
        {
            InitializeComponent();
            NameBlock.Text = animal.Name;
            TypeBlock.Text = animal.AnimalType.ToString();
            ColorBlock.Text = animal.Color.ToString();
            selectedAnimal = animal;
            FeedingButton.Content = $"Feed({animal.FeedingCost}$)";
        }

        private void Feed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var zooPark = ZooPark.GetInstance();
                MessageBox.Show(zooPark.FeedAnimal(selectedAnimal), "Hoooray!");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        } 

        private void Greeting_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(selectedAnimal.PerformGreeting(), "Greeting");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            selectedAnimal.Name = NameBlock.Text;
        }
    }
}
