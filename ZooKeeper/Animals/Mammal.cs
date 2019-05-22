using ZooKeeper.Repositories;
using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    public abstract class Mammal: Animal
    {
        public override int FeedingCost { get => 30; }

        protected override string SpecificActionsForFeeding()
        {
            ApplicationRepository.AddMammalsFedForUser(master);
            return "The mammal has eaten meat. It is happy!";
        }

        public Mammal(string name, User master, Color color, AnimalType type) : base(name, master, color, type) { }

        public Mammal(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
