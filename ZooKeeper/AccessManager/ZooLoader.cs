using ZooKeeper.ZooManager;
using ZooKeeper.Validators;

namespace ZooKeeper.AccessManager
{
    class ZooLoader : IZooLoader
    {
        public ZooPark GetZoo(Credentials credentials)
        {
            return ZooPark.GetInstance(credentials.Username);
        }
    }
}
