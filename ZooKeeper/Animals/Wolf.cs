using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class Wolf : Mammal
    {
        protected override string SpecificGreeting()
        {
            return "Owwwwwwwwwwwwwwwwwwww!";
        }

        public Wolf(string name, User master, Color color) : base(name, master, color, AnimalType.Wolf) { }

        public Wolf(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
