using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Models
{
    public class DBAnimal
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public int Type { get; set; }

        public int Color { get; set; }

        public string Name { get; set; }

        public DBAnimal(string name, int type, int color, long userId)
        {
            Type = type;
            Color = color;
            Name = name;
            UserId = userId;
        }

        public DBAnimal() { }
    }
}
