using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Animals
{
    class Raven: Bird
    {
        public override string PerformGreeting()
        {
            return "Karrrrrr!";
        }

        public override AnimalType AnimalType
        {
            get
            {
                return AnimalType.Raven;
            }
        }

        public Raven(string name, long userId, Color color) : base(name, userId, color) { }
    }
}
