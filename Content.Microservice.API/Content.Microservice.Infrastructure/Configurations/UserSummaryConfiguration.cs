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
    internal class UserSummaryConfiguration : BaseEntityConfiguration<UserSummary>
    {
        public override void Configure(EntityTypeBuilder<UserSummary> builder)
        {
            base.Configure(builder);

            // Властивості
            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.HasIndex(u => u.UserName).IsUnique();

            // UserSummary → Review (1:N), без каскаду
            builder
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // UserSummary → Reply (1:N), без каскаду
            builder
                .HasMany(u => u.Replies)
                .WithOne(rp => rp.User)
                .HasForeignKey(rp => rp.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // UserSummary → TripPlan (1:N), без каскаду
            builder
                .HasMany(u => u.TripPlans)
                .WithOne(tp => tp.User)
                .HasForeignKey(tp => tp.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
