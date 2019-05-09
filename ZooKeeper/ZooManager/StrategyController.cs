using System;
using ZooKeeper.Models;
using ZooKeeper.Repositories;

namespace ZooKeeper.ZooManager
{
    public class StrategyController : IObserver
    {
        private readonly ZooPark zooPark;

        public void Update(int level)
        {
            zooPark.SetState(GetStateForLevel(level));
        }

        private IShopStrategy GetStateForLevel(int level)
        {
            if(level >= 10)
            {
                return new PremiuimStrategy();
            }
            if(level >= 3)
            {
                return new MiddleLevelStrategy();
            }
            return new DecentStrategy();
        }

        public StrategyController(ZooPark zooPark)
        {
            this.zooPark = zooPark;
            zooPark.AddObserver(this);
            zooPark.SetState(GetStateForLevel(zooPark.user.Level));
        }
    }
}
