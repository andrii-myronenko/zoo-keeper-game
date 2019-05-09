using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Models { 
    public class User
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Level { get; set; }

        public int Money { get; set; }

        public virtual ICollection<DBAnimal> Animals { get; set; }

    public User(string username, string password)
        {
            Username = username;
            Password = password;
            Level = 1;
            Money = 100;
            Animals = new List<DBAnimal>();
        }

        public User() { }
    }
}
