using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooKeeper.Animals;

namespace ZooKeeper.ZooManager
{
    class PremiuimStrategy : IShopStrategy
    {
        public bool IsStoreAccessible(AnimalsStore store)
        {
            return true;
        }
    }
}
