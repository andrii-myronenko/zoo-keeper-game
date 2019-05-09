using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Animals
{
    class Parrot: Bird
    {
        public override string PerformGreeting()
        {
            return "I'm parrrrot, no, pirrrrate!";
        }

        public override AnimalType AnimalType
        {
            get
            {
                return AnimalType.Parrot;
            }
        }

        public Parrot(string name, long userId, Color color) : base(name, userId, color) { }
    }
}
