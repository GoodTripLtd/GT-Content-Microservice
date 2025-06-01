using Content.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Infrastructure.Configurations
{
    internal class PlaceConfiguration : BaseEntityConfiguration<Place>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Place> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(500);

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(p => p.Latitude)
                   .IsRequired()
                   .HasColumnType("decimal(9,6)");

            builder.Property(p => p.Longitude)
                   .IsRequired()
                   .HasColumnType("decimal(9,6)");

            builder.Property(p => p.Rating)
                   .IsRequired()
                   .HasDefaultValue(0.0);

            // індекси
            builder.HasIndex(p => p.Name);
            builder.HasIndex(p => new { p.Latitude, p.Longitude });
            builder.HasIndex(p => p.Rating);
        }
    }
}
