using Microsoft.EntityFrameworkCore;
using MNH_Ecommerce.Domain.Entity;
using MNH_Ecommerce.Domain.Utils;
using MNH_Ecommerce.Repository.Config;

namespace MNH_Ecommerce.Repository.Context
{
    public class MNH_EcommerceContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<ItemDemand> ItemDemands { get; set; }
        public DbSet<PayWay> PayWays { get; set; }

        public MNH_EcommerceContext(DbContextOptions options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //classes de mapeamento db
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ItemDemandConfiguration());
            modelBuilder.ApplyConfiguration(new DemandConfiguration());
            modelBuilder.ApplyConfiguration(new PayWayConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
