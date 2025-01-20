using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;

namespace Product.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Products>().ToTable("Products");
        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
