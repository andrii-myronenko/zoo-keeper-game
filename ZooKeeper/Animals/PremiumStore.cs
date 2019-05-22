using System;
using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class PremiumStore: AnimalsStore
    {
        public override int GetAnimalCost()
        {
            return 250;
        }

        public override Bird GetBird(string name, User user)
        {
            Color color = (Color)new Random().Next(0, colorsNubmer);
            return new Penguin(name, user, color);
        }

        public override Mammal GetMammal(string name, User user)
        {
            Color color = (Color)new Random().Next(0, colorsNubmer);
            return new Dolphin(name, user, color);
        }

        public override Fish GetFish(string name, User user)
        {
            Color color = (Color)new Random().Next(0, colorsNubmer);
            return new Whipping(name, user, color);
        }
    }
}
