using CrossCutting.Infra.Mapping;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Infra
{
    [ExcludeFromCodeCoverage]
    public class ApplicationContext : DbContext
    {
        public DbSet<Truck> Truck { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<Truck>();
            config.ToTable("Truck");
            modelBuilder.ApplyConfiguration(new TruckMap());
        }
    }
}
