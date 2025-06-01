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
    internal class TripPlanConfiguration : BaseEntityConfiguration<TripPlan>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<TripPlan> builder)
        {
            base.Configure(builder);

            builder.HasKey(tp => tp.Id);

            // Поля
            builder.Property(tp => tp.Title)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(tp => tp.Description)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(tp => tp.StartDate)
                   .IsRequired();

            builder.Property(tp => tp.EndDate)
                   .IsRequired();

            builder.Property(tp => tp.IsPublic)
                   .IsRequired();

            // Дати з BaseEntity
            builder.Property(tp => tp.CreatedAt)
                   .IsRequired();
            builder.Property(tp => tp.ModifiedAt)
                   .IsRequired(false);

            // Зв'язок TripPlan → UserSummary
            builder
                .HasOne(tp => tp.User)
                .WithMany() // якщо UserSummary не містить колекції TripPlans
                .HasForeignKey(tp => tp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Індекси
            builder.HasIndex(tp => tp.UserId);
            builder.HasIndex(tp => tp.StartDate);
            builder.HasIndex(tp => tp.EndDate);
        }
    }
}
