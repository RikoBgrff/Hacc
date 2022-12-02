using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class ApplicationDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
        
        public ApplicationDbContext()
        {

        }

        public virtual DbSet<AppRole>? AppRoles { get; set; }

        public virtual DbSet<Item>? Items { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Hacc_Database;Integrated Security=True; Encrypt=False;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
    
}
