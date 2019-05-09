using System;
using System.Collections.Generic;
using System.Linq;
using ZooKeeper.DatabaseContexts;
using ZooKeeper.Validators;
using ZooKeeper.Models;
using ZooKeeper.Helpers;

namespace ZooKeeper.Repositories
{
    static class UserRepository
    {
        private static readonly UserContext _context = new UserContext();

        public static User AddUser(string username, string password)
        {
            if (UserRepository.UserExists(username))
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

        public static bool UserAllowedToAccess(string username, string password)
        {
            string passwordToCheck = Encrypter.GetMd5Hash(password);
            if (_context.Users.Any(user => user.Username == username &&
                passwordToCheck == user.Password))
            {
                return true;
            }
            return false;
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
                throw new Exception("User don't have enough money");
            }
            user.Money -= amount;
            _context.SaveChanges();
        }
    }
}
