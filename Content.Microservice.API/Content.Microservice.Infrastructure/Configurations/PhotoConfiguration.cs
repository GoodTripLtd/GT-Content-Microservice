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
    internal class PhotoConfiguration : BaseEntityConfiguration<Photo>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Photo> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id);

            // Властивості
            builder.Property(p => p.PhotoUrl)
                .IsRequired()
                .HasMaxLength(1000); // довжину URL можна підправити

            builder.Property(p => p.ModifiedAt);

            // --- Відношення Photo → Review (1:N) через ReviewId ---
            builder
                .HasOne(p => p.Review)
                .WithMany(r => r.Photos)
                .HasForeignKey(p => p.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- Відношення Photo → Reply (1:N) через ReplyId ---
            builder
                .HasOne(p => p.Reply)
                .WithMany(rp => rp.Photos)
                .HasForeignKey(p => p.ReplyId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- CHECK-CONSTRAINT: лише одне з ReviewId або ReplyId може бути НЕ NULL ---
            builder.ToTable(t=>t.HasCheckConstraint(
                name: "CK_Photos_OneFk",
                sql: @"
                    (ReviewId IS NOT NULL AND ReplyId IS NULL)
                    OR (ReviewId IS NULL AND ReplyId IS NOT NULL)"
                    .Replace(Environment.NewLine, " ")));

            // Індекси для швидкого пошуку
            builder.HasIndex(p => p.ReviewId);
            builder.HasIndex(p => p.ReplyId);
        }
    }
}
