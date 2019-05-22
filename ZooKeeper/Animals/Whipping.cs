using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class Whipping : Fish
    {
        protected override string SpecificGreeting()
        {
            return "Hello, i'm really clever whipping!";
        }

        public Whipping(string name, User master, Color color) : base(name, master, color, AnimalType.Whipping) { }

        public Whipping(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
