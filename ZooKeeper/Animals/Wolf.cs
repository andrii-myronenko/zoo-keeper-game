using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Animals
{
    class Wolf: Mammal
    {
        public override string PerformGreeting()
        {
            return "Owwwwwwwwwwwwww!";
        }

        public override AnimalType AnimalType
        {
            get
            {
                return AnimalType.Wolf;
            }
        }

        public Wolf(string name, long userId, Color color) : base(name, userId, color) { }
    }
}
