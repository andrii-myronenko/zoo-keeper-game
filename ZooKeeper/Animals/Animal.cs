using ZooKeeper.Models;
using ZooKeeper.Repositories;
using System;

namespace ZooKeeper.Animals
{

    public abstract class Animal
    {
        protected DatabaseAnimal dbAnimal;

        protected readonly User master;

        public abstract int FeedingCost { get; }
        
        public string Name {
            get
            {
                return dbAnimal.Name;
            }
            set
            {
                ApplicationRepository.ChangeAnimalName(dbAnimal, value);
            }
        }

        public long Id { get { return dbAnimal.Id; } }

        public Color Color { get { return (Color)dbAnimal.Color; } }

        public AnimalType AnimalType { get { return (AnimalType)dbAnimal.Type; } }

        public string Eat()
        {
            return CommonActionsForFeeding() + SpecificActionsForFeeding();
        }

        protected string CommonActionsForFeeding()
        {
            ApplicationRepository.GetMoneyFromrUser(master, FeedingCost);
            return  "Feeding has been completed! ";
        }

        protected abstract string SpecificActionsForFeeding();


        public string PerformGreeting()
        {
            return CommonGreeting() + SpecificGreeting();
        }

        protected string CommonGreeting()
        {
            return "You come to the animal and say Hi! The animal answers: ";
        }

        protected abstract string SpecificGreeting();

        public Animal(string name, User master, Color color, AnimalType type)
        {
            dbAnimal = ApplicationRepository.CreateAnimal(name, type, color, master.Id);
            this.master = master;
        }

        public Animal(DatabaseAnimal animal, User master)
        {
            dbAnimal = animal;
            this.master = master;
        }
    }
}
