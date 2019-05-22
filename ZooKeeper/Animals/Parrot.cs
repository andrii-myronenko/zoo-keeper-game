using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class Parrot: Bird
    {
        protected override string SpecificGreeting()
        {
            return "I'm parrrrot, no, pirrrrate!";
        }

        public Parrot(string name, User master, Color color) : base(name, master, color, AnimalType.Parrot) { }

        public Parrot(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
