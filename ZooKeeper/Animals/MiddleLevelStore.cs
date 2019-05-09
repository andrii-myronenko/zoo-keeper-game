using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.Animals
{
    class MiddleLevelStore : AnimalsStore
    {
        public override int GetAnimalCost()
        {
            return 150;
        }

        public override Bird GetBird(string name, long userId)
        {
            Color color = (Color)new Random().Next(0, colorsNubmer);
            return new Parrot(name, userId, color);
        }

        public override Mammal GetMammal(string name, long userId)
        {
            Color color = (Color)new Random().Next(0, colorsNubmer);
            return new Wolf(name, userId, color);
        }
    }
}
