using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Animals
{
    class Dolphin: Mammal
    {
        public override string PerformGreeting()
        {
            return "Ui, ui!";
        }

        public override AnimalType AnimalType
        {
            get
            {
                return AnimalType.Dolphin;
            }
        }

        public Dolphin(string name, long userId, Color color) : base(name, userId, color) { }
    }
}
