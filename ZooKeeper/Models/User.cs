using System.Collections.Generic;

namespace ZooKeeper.Models { 
    public class User
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Level { get; set; }

        public int Money { get; set; }

        public int MammalsFed { get; set; }

        public int FishesFed { get; set; }

        public int BirdsFed { get; set; }

        public virtual ICollection<DatabaseAnimal> Animals { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Level = 1;
            Money = 100;
            Animals = new List<DatabaseAnimal>();
            MammalsFed = 0;
            FishesFed = 0;
            BirdsFed = 0;
        }

        public User() { }
    }
}
