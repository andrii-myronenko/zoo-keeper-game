using ZooKeeper.Animals;

namespace ZooKeeper.ZooManager
{
    class DecentState: IStoreState
    {
        public bool IsStoreAccessible(AnimalsStore store)
        {
            if(store is MiddleLevelStore)
            {
                return false;
            }
            if(store is PremiumStore)
            {
                return false;
            }
            return true;
        }
    }
}
