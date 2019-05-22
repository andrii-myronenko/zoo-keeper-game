using System;
using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class MiddleLevelStore : AnimalsStore
    {
        public override int GetAnimalCost()
        {
            return 150;
        }

        public override Bird GetBird(string name, User user)
        {
            Color color = (Color)new Random().Next(0, colorsNubmer);
            return new Parrot(name, user, color);
        }

        public override Mammal GetMammal(string name, User user)
        {
            Color color = (Color)new Random().Next(0, colorsNubmer);
            return new Wolf(name, user, color);
        }

        public override Fish GetFish(string name, User user)
        {
            Color color = (Color)new Random().Next(0, colorsNubmer);
            return new Shark(name, user, color);
        }
    }
}
