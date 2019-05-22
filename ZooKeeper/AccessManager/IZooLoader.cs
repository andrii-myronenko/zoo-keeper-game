using ZooKeeper.ZooManager;
using ZooKeeper.Validators;

namespace ZooKeeper.AccessManager
{
    interface IZooLoader
    {
        ZooPark GetZoo(string username, string password);
    }
}
