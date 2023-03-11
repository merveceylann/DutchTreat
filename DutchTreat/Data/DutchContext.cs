using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace DutchTreat.Data
{
    public class DutchContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DutchContext(IConfiguration config)
        {
            _configuration= config;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DutchContextDb"]);     
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Product>()
            //    .HasData(new Order()){

            //}
        }
    }
    
}
