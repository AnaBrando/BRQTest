using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace CrossCutting.Infra.Mapping
{
    [ExcludeFromCodeCoverage]
    public class TruckMap : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(x => x.ManufactoryYear);
            builder.Property(x => x.ModelYear);
            builder.Property(x => x.Model);
        }
    }
}
