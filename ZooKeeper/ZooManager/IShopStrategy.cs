using ZooKeeper.Animals;

namespace ZooKeeper.ZooManager
{
    public interface IShopStrategy
    {
        bool IsStoreAccessible(AnimalsStore store);
    }
}
