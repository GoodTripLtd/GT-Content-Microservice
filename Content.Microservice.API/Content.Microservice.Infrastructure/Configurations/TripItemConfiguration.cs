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
    internal class TripItemConfiguration : BaseEntityConfiguration<TripItem>
    {        
        public override void Configure(EntityTypeBuilder<TripItem> builder)
        {
            base.Configure(builder);

            // PK
            builder.HasKey(ti => ti.Id);

            // Поля
            builder.Property(ti => ti.Notes)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(ti => ti.DisplayOrder)
                   .IsRequired();

            // Дати зберігаються/налаштовуються в BaseEntity – не задаємо тут HasDefaultValueSql
            builder.Property(ti => ti.CreatedAt)
                   .IsRequired();
            builder.Property(ti => ti.ModifiedAt)
                   .IsRequired(false);

            // Зв'язок TripItem → TripPlan
            builder
                .HasOne(ti => ti.TripPlan)
                .WithMany() // якщо TripPlan не містить навігаційної колекції TripItems
                .HasForeignKey(ti => ti.TripPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            // Зв'язок TripItem → Place
            builder
                .HasOne(ti => ti.Place)
                .WithMany() // якщо Place не містить навігаційної колекції TripItems
                .HasForeignKey(ti => ti.PlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Індекси
            builder.HasIndex(ti => ti.TripPlanId);
            builder.HasIndex(ti => ti.PlaceId);
            builder.HasIndex(ti => ti.DisplayOrder);
        }
    }
}
