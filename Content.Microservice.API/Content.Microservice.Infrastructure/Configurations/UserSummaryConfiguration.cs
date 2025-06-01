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
        public override void ConfigureOtherProperties(EntityTypeBuilder<UserSummary> builder)
        {
            base.Configure(builder);

            // Властивості
            builder.Property(us => us.UserName)
                   .IsRequired()
                   .HasMaxLength(50);

            // Унікальний індекс на UserName
            builder.HasIndex(us => us.UserName).IsUnique();

            // Зв'язки “один UserSummary → багато Replies/Votes/TripPlans/Reviews”
            builder
                .HasMany(us => us.Replies)
                .WithOne(rp => rp.User)
                .HasForeignKey(rp => rp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(us => us.TripPlans)
                .WithOne(tp => tp.User)
                .HasForeignKey(tp => tp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(us => us.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
