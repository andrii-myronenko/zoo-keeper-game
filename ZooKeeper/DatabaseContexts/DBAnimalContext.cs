using System.Data.Entity;
using ZooKeeper.Models;

namespace ZooKeeper.DatabaseContexts
{
    class DBAnimalContext : DbContext
    {
        public DBAnimalContext() : base("ZooKeeperConnection") { }

        public DbSet<DBAnimal> Animals { get; set; }
    }
}
