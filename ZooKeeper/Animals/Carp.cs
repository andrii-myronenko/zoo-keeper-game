using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class Carp : Fish
    {
        protected override string SpecificGreeting()
        {
            return "Splash splash!";
        }

        public Carp(string name, User master, Color color) : base(name, master, color, AnimalType.Carp) { }

        public Carp(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
