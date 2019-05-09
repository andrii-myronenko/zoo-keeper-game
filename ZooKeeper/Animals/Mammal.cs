using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Animals
{
    public abstract class Mammal: Animal
    {
        public override string Eat()
        {
            return "The mammal has eaten meat";
        }

        public Mammal(string name, long userId, Color color) : base(name, userId, color) { }
    }
}
