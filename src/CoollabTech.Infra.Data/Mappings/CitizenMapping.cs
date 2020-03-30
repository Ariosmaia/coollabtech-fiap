using CoollabTech.Domain.Citizen;
using CoollabTech.Domain.Citizen.Enums;
using CoollabTech.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Infra.Data.Mappings
{
    public class CitizenMapping : EntityTypeConfiguration<Citizen>
    {
        public override void Map(EntityTypeBuilder<Citizen> builder)
        {
            builder.Property(e => e.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.NickName)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.Document)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasConversion(x => x.ToString(), 
                    x => (EGender) Enum.Parse(typeof(EGender), x))
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.DateRegister)
                .IsRequired();

            builder.Ignore(c => c.ValidationResult);

            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Citizens");
        }
    }
}
