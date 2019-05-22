using System;
using ZooKeeper.Repositories;
using ZooKeeper.Models;
using System.Collections.ObjectModel;
using ZooKeeper.Animals;
using System.Collections.Generic;
using ZooKeeper.ObserverInterfaces;

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

        public ObservableCollection<Animal> animals;

        public User user;

        private List<IObserver> observers;

        private IStoreState state;

        private ZooPark(string username)
        {
            user = ApplicationRepository.GetUser(username);

            animals = ApplicationRepository.GetAnimalsForUser(user);

            observers = new List<IObserver>();

            SetProperState(user.Level);
        }

        public Animal BuyRandomAnimal(string name, AnimalsStore store)
        {
            if (!this.state.IsStoreAccessible(store))
            {
                throw new Exception("This store is not yet aviable for your level. Middle level store is aviable on level 3, " +
                    "Premium level store is aviable on level 10");
            }
            ApplicationRepository.GetMoneyFromrUser(user, store.GetAnimalCost());
            NotifyObservers(ActionType.MoneyChanged, user.Money);
            int randomNumber = new Random().Next(0, 3);
            Animal animal;
            if (randomNumber == 0)
            {
                animal = store.GetBird(name, user);
            }
            else if (randomNumber == 1)
            {
                animal = store.GetMammal(name, user);
            }
            else
            {
                animal = store.GetFish(name, user);
            }
            animals.Add(animal);
            CheckLevel(animals.Count);
            return animal;
        }

        public int AddMoney()
        {
            int amount = user.Level * 10;
            ApplicationRepository.AddMoneyForUser(user, amount);
            NotifyObservers(ActionType.MoneyChanged, user.Money);
            return amount;
        }

        private void CheckLevel(int numberOfAnimals)
        {
            if (numberOfAnimals / 5 + 1 > user.Level)
            {
                ApplicationRepository.AddLevelForUser(user);
                SetProperState(user.Level);
                NotifyObservers(ActionType.LevelChanged, user.Level);
            }
        }

        public string FeedAnimal(Animal animal)
        {
            string feedingResult = animal.Eat();
            NotifyObservers(ActionType.MoneyChanged, user.Money);
            return feedingResult;
        }

        private void SetProperState(int level)
        {
            if (level >= 10)
            {
                state = new PremiuimState();
            }
            else if (level >= 3)
            {
                state = new MiddleLevelState();
            }
            else
            {
                state = new DecentState();
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

        public void NotifyObservers(ActionType actionType, int value)
        {
            foreach(var observer in observers)
            {
                observer.Update(actionType, value);
            }
        }
    }
}
