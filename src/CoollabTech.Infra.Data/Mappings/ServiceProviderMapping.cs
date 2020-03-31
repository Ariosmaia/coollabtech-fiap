using CoollabTech.Domain.Tickets;
using CoollabTech.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoollabTech.Infra.Data.Mappings
{
    public class ServiceProviderMapping : EntityTypeConfiguration<ServiceProvider>
    {
        public override void Map(EntityTypeBuilder<ServiceProvider> builder)
        {
            builder.Property(e => e.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.DateRegister)
                .IsRequired();

            builder.Ignore(c => c.ValidationResult);

            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("ServiceProviders");
        }
    }
}
