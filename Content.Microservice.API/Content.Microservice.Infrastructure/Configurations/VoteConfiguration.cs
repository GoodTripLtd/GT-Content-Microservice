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
    internal class VoteConfiguration : BaseEntityConfiguration<Vote>
    {
        public override void Configure(EntityTypeBuilder<Vote> builder)
        {
            base.Configure(builder);

            builder.Property(v => v.Value).IsRequired();
            builder.Property(v => v.VotedAt).IsRequired();

            // Vote → Review (N:1), без каскаду
            builder
                .HasOne(v => v.Review)
                .WithMany(r => r.Votes)
                .HasForeignKey(v => v.ReviewId)
                .OnDelete(DeleteBehavior.NoAction);

            // Додаткові індекси
            builder.HasIndex(v => v.ReviewId);
        }
    }
}
