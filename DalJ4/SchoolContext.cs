using DalJ4.Model;
using Microsoft.EntityFrameworkCore;

namespace DalJ4
{
    public class SchoolContext : DbContext
    {
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\czimmermann\\source\\repos\\supinfo-2024-3asp\\DalJ4\\School.mdf;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
