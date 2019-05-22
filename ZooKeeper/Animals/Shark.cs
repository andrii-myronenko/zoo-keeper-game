using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class Shark : Fish
    {
        protected override string SpecificGreeting()
        {
            return "Grrrrr!";
        }

        public Shark(string name, User master, Color color) : base(name, master, color, AnimalType.Shark) { }

        public Shark(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
