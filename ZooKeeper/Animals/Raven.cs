using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class Raven: Bird
    {
        protected override string SpecificGreeting()
        {
            return "Karrrrrr!";
        }

        public Raven(string name, User master, Color color) : base(name, master, color, AnimalType.Raven) { }

        public Raven(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
