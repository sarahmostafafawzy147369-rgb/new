using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp16.Models;
using Microsoft.EntityFrameworkCore;
namespace WpfApp16.Data
{
    public class MyDbcontext : DbContext
    {
        public DbSet<_User_> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=COM166-LAB3\\SQLEXPRESS;Initial Catalog=Inventory_Management;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
