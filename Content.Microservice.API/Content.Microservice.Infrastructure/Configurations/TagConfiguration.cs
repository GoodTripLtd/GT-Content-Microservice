using Content.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Infrastructure.Configurations
{
    internal class TagConfiguration : BaseEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            // Унікальний індекс на Name
            builder.HasIndex(t => t.Name).IsUnique();
        }
    }
}
