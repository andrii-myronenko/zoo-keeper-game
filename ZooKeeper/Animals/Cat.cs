using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Animals
{
    class Cat: Mammal
    {
        public override string PerformGreeting()
        {
            return "Meow!";
        }

        public override AnimalType AnimalType
        {
            get {
                return AnimalType.Cat;
            }
        }

        public Cat(string name, long userId, Color color) : base(name, userId, color) { }
    }
}
