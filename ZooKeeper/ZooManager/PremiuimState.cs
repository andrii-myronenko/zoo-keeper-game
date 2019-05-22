using ZooKeeper.Animals;

namespace ZooKeeper.ZooManager
{
    class PremiuimState : IStoreState
    {
        public bool IsStoreAccessible(AnimalsStore store)
        {
            return true;
        }
    }
}
