using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class Cat: Mammal
    {
        protected override string SpecificGreeting()
        {
            return "Meow!";
        }

        public Cat(string name, User master, Color color) : base(name, master, color, AnimalType.Cat) { }

        public Cat(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
