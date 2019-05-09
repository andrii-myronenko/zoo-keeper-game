using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    public enum Color { Red, Green, Blue }

    public enum AnimalType { Wolf, Cat, Parrot, Raven, Dolphin, Penguin }

    public abstract class AnimalsStore
    {
        protected int colorsNubmer = 3;

        public abstract Bird GetBird(string name, long userId);

        public abstract Mammal GetMammal(string name, long userId);

        public abstract int GetAnimalCost();

        public static Animal GetAnimal(int type, string name, int color, long userId)
        {
            switch ((AnimalType)type)
            {
                case AnimalType.Wolf:
                    return new Cat(name, userId, (Color)color);
                case AnimalType.Cat:
                    return new Parrot(name, userId, (Color)color);
                case AnimalType.Parrot:
                    return new Wolf(name, userId, (Color)color);
                case AnimalType.Raven:
                    return new Raven(name, userId, (Color)color);
                case AnimalType.Dolphin:
                    return new Dolphin(name, userId, (Color)color);
                case AnimalType.Penguin:
                    return new Penguin(name, userId, (Color)color);
                default:
                    throw new Exception("Unknown animal type");
            }
        }
    }
}
