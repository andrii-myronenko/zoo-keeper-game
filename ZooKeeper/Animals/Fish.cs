using ZooKeeper.Repositories;
using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    public abstract class Fish: Animal
    {
        public override int FeedingCost { get => 10; }

        protected override string SpecificActionsForFeeding()
        {
            ApplicationRepository.AddFishesFedForUser(master);
            return "The fish has eaten bread. It is happy!";
        }

        public Fish(string name, User master, Color color, AnimalType type) : base(name, master, color, type) { }

        public Fish(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
