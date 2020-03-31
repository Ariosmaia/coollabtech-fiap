using CoollabTech.Domain.Tickets;
using CoollabTech.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoollabTech.Infra.Data.Mappings
{
    public class TicketStatusMapping : EntityTypeConfiguration<TicketStatus>
    {
        public override void Map(EntityTypeBuilder<TicketStatus> builder)
        {
            builder.Property(e => e.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.DateRegister)
                .IsRequired();

            builder.Ignore(c => c.ValidationResult);

            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("TicketStatus");
        }
    }
}
