using System;
using System.Linq;
using ZooKeeper.DatabaseContexts;
using ZooKeeper.Models;
using ZooKeeper.Helpers;
using ZooKeeper.Animals;
using System.Collections.ObjectModel;

namespace ZooKeeper.Repositories
{
    static class ApplicationRepository
    {
        private static readonly ApplicationContext _context = new ApplicationContext();

        public static User AddUser(string username, string password)
        {
            if (ApplicationRepository.UserExists(username))
            {
                throw new Exception("Username already exists");
            }

            User user = new User(username, Encrypter.GetMd5Hash(password));
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public static bool UserExists(string username)
        {
            if (_context.Users.Any(user => user.Username == username))
            {
                return true;
            }
            return false;
        }

        public static User GetUser(string username)
        {
            var foundUser = _context.Users.First(user => user.Username == username);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            return foundUser;
        }

        public static User GetUser(long id)
        {
            var foundUser = _context.Users.First(user => user.Id == id);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            return foundUser;
        }

        public static bool CheckUserAllowedToAccess(string username, string password)
        {
            string passwordToCheck = Encrypter.GetMd5Hash(password);
            if (_context.Users.Any(user => user.Username == username &&
                passwordToCheck == user.Password))
            {
                return true;
            }
            return false;
        }

        public static ObservableCollection<Animal> GetAnimalsForUser(User user)
        {
            var dbAnimals = user.Animals;
            ObservableCollection<Animal> animals = new ObservableCollection<Animal>();
            foreach (DatabaseAnimal animal in dbAnimals)
            {
                animals.Add(AnimalsStore.GetAnimalFromDatabaseRecord(animal, user));
            }
            return animals;
        }

        public static void AddLevelForUser(User user)
        {
            user.Level += 1;
            _context.SaveChanges();
        }

        public static void AddMoneyForUser(User user, int amount)
        {
            user.Money += amount;
            _context.SaveChanges();
        }

        public static void GetMoneyFromrUser(User user, int amount)
        {
            if(amount > user.Money)
            {
                throw new Exception("User doesn't have enough money");
            }
            user.Money -= amount;
            _context.SaveChanges();
        }

        public static void AddMammalsFedForUser(User user)
        {
            user.MammalsFed += 1;
            _context.SaveChanges();
        }

        public static void AddFishesFedForUser(User user)
        {
            user.FishesFed += 1;
            _context.SaveChanges();
        }

        public static void AddBirdsFedForUser(User user)
        {
            user.BirdsFed += 1;
            _context.SaveChanges();
        }

        public static DatabaseAnimal CreateAnimal(string name, AnimalType type, Color color, long userId)
        {
            DatabaseAnimal dbAnimal = new DatabaseAnimal(name, (int)type, (int)color, userId);
            _context.Animals.Add(dbAnimal);
            _context.SaveChanges();
            return dbAnimal;
        }

        public static void ChangeAnimalName(DatabaseAnimal animal, string name)
        {
            animal.Name = name;
            _context.SaveChanges();
        }
    }
}
