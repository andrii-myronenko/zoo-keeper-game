using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Animals
{
    class Penguin : Bird
    {
        public override string PerformGreeting()
        {
            return "Hi, Private Penguin is here!";
        }

        public override AnimalType AnimalType
        {
            get
            {
                return AnimalType.Penguin;
            }
        }

        public Penguin(string name, long userId, Color color) : base(name, userId, color) { }
    }
}
