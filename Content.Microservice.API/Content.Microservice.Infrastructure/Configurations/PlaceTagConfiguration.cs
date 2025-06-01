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
    internal class PlaceTagConfiguration : BaseEntityConfiguration<PlaceTag>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<PlaceTag> builder)
        {
            base.Configure(builder);

            builder
            .HasOne(pt => pt.Place)
            .WithMany() // або .WithMany(p => p.PlaceTags), якщо додасте колекцію в Place
            .HasForeignKey(pt => pt.PlaceId)
            .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(pt => pt.Tag)
                .WithMany() // або .WithMany(t => t.PlaceTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            // унікальний індекс, щоб поєднання (PlaceId, TagId) було унікальним
            builder.HasIndex(pt => new { pt.PlaceId, pt.TagId }).IsUnique();

            // індекси на FK
            builder.HasIndex(pt => pt.PlaceId);
            builder.HasIndex(pt => pt.TagId);
        }
    }
}
