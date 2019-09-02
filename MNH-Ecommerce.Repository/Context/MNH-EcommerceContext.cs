using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MNH_Ecommerce.Domain.Entity;
using MNH_Ecommerce.Domain.Utils;

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
    }
}
