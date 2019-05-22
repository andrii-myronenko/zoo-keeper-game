using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class Dolphin: Mammal
    {
        protected override string SpecificGreeting()
        {
            return "Ui ui!";
        }

        public Dolphin(string name, User master, Color color) : base(name, master, color, AnimalType.Dolphin) { }

        public Dolphin(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
