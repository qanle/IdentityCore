using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Imip.Models.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        //public DbSet<CatLayout> CatLayouts { get; set; }
        //public DbSet<CatObject> CatObjects { get; set; }
        //public DbSet<ObjectInfo> ObjectInfos { get; set; }
        //public DbSet<ObjectInfoDetail> ObjectInfoDetails { get; set; }
        public DbSet<Users> User { get; set; }
        //public DbSet<Alarm> Alarms { get; set; }
        //public DbSet<AlarmType> AlarmTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("ConnStr");
                //optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString);
            }
        }


    }
}
