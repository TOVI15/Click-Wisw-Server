
using ClickWise.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace ClickWise.Data
{
    public class DataContext : DbContext
    {
        public DbSet<StudentBasicInfo> Students {get; set;}
        public DbSet<StudentDetails> StudentDetails { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=localhost_cs");
        }

    }
}
