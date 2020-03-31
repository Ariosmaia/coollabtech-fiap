using CoollabTech.Domain.Citizen.Enums;
using CoollabTech.Domain.Tickets;
using CoollabTech.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CoollabTech.Infra.Data.Mappings
{
    public class TicketMapping : EntityTypeConfiguration<Ticket>
    {
        public override void Map(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(e => e.Description)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Localization)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(e => e.DateRegister)
                .IsRequired();

            builder.Ignore(c => c.ValidationResult);

            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Tickets");
        }
    }
}
