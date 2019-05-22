using ZooKeeper.Repositories;
using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    public abstract class Bird : Animal
    {
        public override int FeedingCost { get => 20; }

        protected override string SpecificActionsForFeeding()
        {
            ApplicationRepository.AddBirdsFedForUser(master);
            return "The bird has eaten seeds. It is happy!";
        }

        public Bird(string name, User master, Color color, AnimalType type) : base(name, master, color, type) { }

        public Bird(DatabaseAnimal animal, User master) : base(animal, master) { }
    }
}
