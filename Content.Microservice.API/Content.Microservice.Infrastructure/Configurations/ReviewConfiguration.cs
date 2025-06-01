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
    internal class ReviewConfiguration : BaseEntityConfiguration<Review>
    {
        public override void Configure(EntityTypeBuilder<Review> builder)
        {
            base.Configure(builder);

            builder.HasKey(r => r.Id);

            builder.Property(r => r.UserId)
                   .IsRequired();
            builder.Property(r => r.PlaceId)
                   .IsRequired();
            builder.Property(r => r.IsApproved)
                   .IsRequired();
            builder.Property(r => r.PhotoUrl)
                   .HasMaxLength(500);

            builder
                .HasMany(r => r.Photos)
                .WithOne(p => p.Review)
                .HasForeignKey(p => p.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Review → Reply (1:N), без каскаду
            builder
                .HasMany(r => r.Replies)
                .WithOne(rp => rp.Review)
                .HasForeignKey(rp => rp.ReviewId)
                .OnDelete(DeleteBehavior.NoAction);

            // Review → Vote (1:N), без каскаду
            builder
                .HasMany(r => r.Votes)
                .WithOne(v => v.Review)
                .HasForeignKey(v => v.ReviewId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(r => r.PlaceId);
            builder.HasIndex(r => r.UserId);
        }
    }
}
