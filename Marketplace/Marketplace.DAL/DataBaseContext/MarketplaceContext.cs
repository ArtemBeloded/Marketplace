using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Marketplace.DAL.Models;

namespace Marketplace.DAL.DataBaseContext
{
    public class MarketplaceContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Credential> Credentials { get; set; }

        public DbSet<Order> Orders { get; set; }

        public MarketplaceContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var converter = new EnumToNumberConverter<Category, int>();
            modelBuilder.Entity<Product>().Property(x => x.Category).HasConversion(converter);
            modelBuilder.Entity<User>().HasMany(x => x.Products).WithOne(x => x.Owner).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(x => x.Orders).WithOne(x => x.Buyer).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
