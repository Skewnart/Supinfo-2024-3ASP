using Microsoft.EntityFrameworkCore;
using PresentationEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationEF
{
    public class ClassContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\czimmermann\\source\\repos\\supinfo-2024-3asp\\PresentationEF\\Database1.mdf;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
