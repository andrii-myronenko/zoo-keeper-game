using System;
using ZooKeeper.Repositories;
using ZooKeeper.Models;
using System.Collections.ObjectModel;
using ZooKeeper.Animals;
using System.Collections.Generic;

namespace ZooKeeper.ZooManager
{
    public class ZooPark : IObservable
    {
        private static ZooPark zooInstance; 

        public static ZooPark GetInstance()
        {
            if (zooInstance == null)
            {
                throw new Exception("Zoo is not initialised, call ZooPark.GetInstance(string username, string password) first");
            }
            return zooInstance;
        }

        public static ZooPark GetInstance(string username)
        {
            if (zooInstance == null)
            {
                zooInstance = new ZooPark(username);
            }
            return zooInstance;
        }

        public readonly User user;

        public ObservableCollection<Animal> animals;

        private List<IObserver> observers;

        private IShopStrategy strategy = new DecentStrategy();

        private ZooPark(string username)
        {
            user = UserRepository.GetUser(username);

            animals = DBAnimalRepository.GetAnimals(this.user);

            observers = new List<IObserver>();
        }

        public void SetState(IShopStrategy state)
        {
            this.strategy = state;
        }

        public Animal GetAnimal(string name, AnimalsStore store)
        {
            if (!this.strategy.IsStoreAccessible(store))
            {
                throw new Exception("This store is not yet aviable for your level. Middle level store is aviable on level 3, " +
                    "Premium level store is aviable on level 10");
            }
            UserRepository.GetMoneyFromrUser(user, store.GetAnimalCost());
            int randomNumber = new Random().Next(0, 2);
            Animal animal;
            if(randomNumber == 0)
            {
                animal = store.GetBird(name, user.Id);
            }
            else
            {
                animal = store.GetMammal(name, user.Id);
            }
            animals.Add(animal);
            CheckLevel(animals.Count);
            DBAnimalRepository.SaveAnimal(animal);
            return animal;
        }

        public int AddMoney()
        {
            int amount = user.Level * 10;
            UserRepository.AddMoneyForUser(user, amount);
            return amount;
        }

        private void CheckLevel(int numberOfAnimals)
        {
            if (numberOfAnimals / 5 + 1 > user.Level)
            {
                UserRepository.AddLevelForUser(user);
                NotifyObservers(user.Level);
            }
        }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers(int level)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(level);
            }
        }
    }
}
