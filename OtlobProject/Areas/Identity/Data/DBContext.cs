using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OtlobProject.Areas.Identity.Data;
using OtlobProject.Models;

namespace OtlobProject.Data
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DBContext() { }
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Order> orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<MealsInMenu> Meals { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=OtlobProject;Integrated Security=True");
        }*/
    }
}
