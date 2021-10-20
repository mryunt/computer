using Computer.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Homework.DAL.Context
{
    public class ComputerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-IS5UPP6;Database=LibraryDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Pc> Pcs{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PcUser> PcUsers { get; set; }
    }
}
