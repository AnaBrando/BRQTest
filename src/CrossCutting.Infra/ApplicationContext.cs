using CrossCutting.Infra.Mapping;
using Domain;
using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<Truck> Truck { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TruckMap());
        }
    }
}
