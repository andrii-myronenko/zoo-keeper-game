using System;
using ZooKeeper.Models;

namespace ZooKeeper.Animals
{
    public enum Color { Red, Green, Blue, White, Pink, Purple, Violet, Burgundy, Yellow, Grey }

    public enum AnimalType { Wolf, Cat, Parrot, Raven, Dolphin, Penguin, Carp, Shark, Whipping }

    public abstract class AnimalsStore
    {
        protected int colorsNubmer = 10;

        public abstract Bird GetBird(string name, User user);

        public abstract Mammal GetMammal(string name, User user);

        public abstract Fish GetFish(string name, User user);

        public abstract int GetAnimalCost();

        public static Animal GetAnimalFromDatabaseRecord(DatabaseAnimal dbAnimal, User user)
        {
            AnimalType type = (AnimalType)dbAnimal.Type;

            switch (type)
            {
                case AnimalType.Wolf:
                    return new Wolf(dbAnimal, user);
                case AnimalType.Cat:
                    return new Cat(dbAnimal, user);
                case AnimalType.Parrot:
                    return new Parrot(dbAnimal, user);
                case AnimalType.Raven:
                    return new Raven(dbAnimal, user);
                case AnimalType.Dolphin:
                    return new Dolphin(dbAnimal, user);
                case AnimalType.Penguin:
                    return new Penguin(dbAnimal, user);
                case AnimalType.Carp:
                    return new Carp(dbAnimal, user);
                case AnimalType.Shark:
                    return new Shark(dbAnimal, user);
                case AnimalType.Whipping:
                    return new Whipping(dbAnimal, user);
                default:
                    throw new Exception("Unknown animal type");
            }
        }
    }
}
