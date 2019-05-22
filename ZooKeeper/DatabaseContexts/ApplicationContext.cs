using System.Data.Entity;
using ZooKeeper.Models;

namespace ZooKeeper.DatabaseContexts
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ZooKeeperConnection") { }

        public DbSet<User> Users { get; set; }

        public DbSet<DatabaseAnimal> Animals { get; set; }
    }
}
