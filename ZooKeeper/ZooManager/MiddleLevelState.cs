using ZooKeeper.Animals;

namespace ZooKeeper.ZooManager
{
    class MiddleLevelState : IStoreState
    {
        public bool IsStoreAccessible(AnimalsStore store)
        {
            if (store is PremiumStore)
            {
                return false;
            }
            return true;
        }
    }
}
