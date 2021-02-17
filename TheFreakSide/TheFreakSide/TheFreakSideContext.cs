using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TheFreakSide.Models;

namespace TheFreakSide
{
    public class TheFreakSideContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=DESKTOP-CGCIHMP\\SQLEXPRESS;Initial Catalog=Polis;Integrated Security=True");
        }

        public TheFreakSideContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public TheFreakSideContext()
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ContactEnquirie> ContactEnquiries { get; set; }
    }
}
