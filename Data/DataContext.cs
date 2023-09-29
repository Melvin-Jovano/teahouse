using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using teahouse.Models;

namespace teahouse.Data {
    public class DataContext : DbContext {
        public DbSet<Tea> Teas => Set<Tea>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Bartender> Bartenders => Set<Bartender>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Recipe> Recipes => Set<Recipe>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // Configure the database connection
            optionsBuilder.UseNpgsql(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Tea>()
                .HasMany(t => t.Bartenders)
                .WithMany(b => b.Teas)
                .UsingEntity(j => j.ToTable("BartenderTea"));

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            
        }
    }
}