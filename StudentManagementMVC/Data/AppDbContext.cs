using Microsoft.EntityFrameworkCore;
using StudentManagementMVC.Models;

namespace StudentManagementMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seedata for the student entity
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, StudentName = "Sedat", Age = 23, Department = "Bilgisayar Programcılığı"},
                new Student { Id = 2, StudentName = "Sıla", Age = 22, Department = "YZ Mühendisliği"},
                new Student { Id = 3, StudentName = "Mehmet", Age = 21, Department = "TDE Öğretmenliği"},
                new Student { Id = 4, StudentName = "Tarık", Age = 15, Department = "Bilgisayar Mühendisliği"},
                new Student { Id = 5, StudentName = "Süleyman", Age = 24, Department = "Siber Güvenlik"}
            );
        }
    }
}
