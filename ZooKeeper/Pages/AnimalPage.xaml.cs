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
using ZooKeeper.Animals;

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
        }

        private void Feed_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(selectedAnimal.Eat(), "Greeting");
        } 

        private void Greeting_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(selectedAnimal.PerformGreeting(), "Greeting");
        }
    }
}
