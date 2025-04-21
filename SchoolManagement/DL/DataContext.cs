
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
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<StudentBasicInfo>()
        //        .HasOne(s => s.AdditionalInfo)
        //        .WithOne(d => d.BasicInfo)
        //        .HasForeignKey<StudentDetails>(d => d.StudentBasicInfoId); 

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
