using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Animals
{
    public abstract class Bird : Animal
    {
        public override string Eat()
        {
            return "The bird has eaten seeds";
        }

        public Bird(string name, long userId, Color color) : base(name, userId, color) { }
    }
}
