using System;
using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    class DecentStore : AnimalsStore
    {
        public override int GetAnimalCost()
        {
            return 50;
        }

        public override Bird GetBird(string name, User user)
        {
            Color color = (Color)new Random().Next(0, colorsNubmer);
            return new Raven(name, user, color);
        }

        public override Mammal GetMammal(string name, User user)
        {
            Color color = (Color)new Random().Next(0, colorsNubmer);
            return new Cat(name, user, color);
        }

        public override Fish GetFish(string name, User user)
        {
            Color color = (Color)new Random().Next(0, colorsNubmer);
            return new Carp(name, user, color);
        }
    }
}
