using FuneralHome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data
{
    public class FuneralHomeContext : DbContext
    {
        public FuneralHomeContext() : base("Data Source=.; Initial Catalog = FuneralHomeDB; Integrated Security = true")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Funeral>()
                .HasRequired(x => x.Client)
                .WithMany(x => x.Funerals)
                .HasForeignKey(x => x.ClientId);

            modelBuilder.Entity<Funeral>()
                .HasMany(x => x.Employees)
                .WithMany(x => x.Funerals);
        }

        public DbSet<Funeral> Funerals { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }


    }
}
