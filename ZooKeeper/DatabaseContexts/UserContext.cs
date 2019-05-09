using System.Data.Entity;
using ZooKeeper.Models;

namespace ZooKeeper.DatabaseContexts
{
    class UserContext : DbContext
    {
        public UserContext() : base("ZooKeeperConnection") { }

        public DbSet<User> Users { get; set; }
    }
}
