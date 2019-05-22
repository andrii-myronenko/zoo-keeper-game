using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class Penguin : Bird
    {
        protected override string SpecificGreeting()
        {
            return "Hi, Private Penguin is here!";
        }

        public Penguin(string name, User master, Color color) : base(name, master, color, AnimalType.Penguin) { }

        public Penguin(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
