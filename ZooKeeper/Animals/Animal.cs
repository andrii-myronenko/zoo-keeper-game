using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Animals
{
    public abstract class Animal
    {
        public string Name { get; }

        public long UserId { get; }

        public Color Color { get; }

        public abstract AnimalType AnimalType {
            get;
        }
        
        public abstract string PerformGreeting();
        public abstract string Eat();

        public Animal(string name, long userId, Color color) {
            Name = name;
            UserId = userId;
            Color = color;
        }
    }
}
