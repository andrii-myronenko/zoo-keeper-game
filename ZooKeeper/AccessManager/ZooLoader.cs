using ZooKeeper.ZooManager;
using ZooKeeper.Validators;

namespace ZooKeeper.AccessManager
{
    class ZooLoader : IZooLoader
    {
        public ZooPark GetZoo(string username, string password)
        {
            return ZooPark.GetInstance(username);
        }
    }
}
