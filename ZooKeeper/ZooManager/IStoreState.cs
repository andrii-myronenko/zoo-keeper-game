using ZooKeeper.Animals;

namespace ZooKeeper.ZooManager
{
    interface IStoreState
    {
        bool IsStoreAccessible(AnimalsStore store);
    }
}
