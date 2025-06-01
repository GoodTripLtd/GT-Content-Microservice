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
    internal class ReplyConfiguration : BaseEntityConfiguration<Reply>
    {
        public override void Configure(EntityTypeBuilder<Reply> builder)
        {
            base.Configure(builder);

            builder.HasKey(rp => rp.Id);

            // 2. Властивості
            builder.Property(rp => rp.Content)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(rp => rp.UserId)
                   .IsRequired();

            builder.Property(rp => rp.ModifiedAt);

            builder
                .HasOne(rp => rp.User)
                .WithMany(u => u.Replies)
                .HasForeignKey(rp => rp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Reply → Review (N:1), без каскаду
            builder
                .HasOne(rp => rp.Review)
                .WithMany(r => r.Replies)
                .HasForeignKey(rp => rp.ReviewId)
                .OnDelete(DeleteBehavior.Restrict);

            // Reply → ParentReply (N:1), без каскаду
            builder
                .HasOne(rp => rp.ParentReply)
                .WithMany(rp => rp.ChildReplies)
                .HasForeignKey(rp => rp.ParentReplyId)
                .OnDelete(DeleteBehavior.Restrict);

            // 5. Відношення Reply → Photo (1:N) через ReplyId
            // Якщо у вас є колекція Photos у Reply, то треба прописати:
            builder
                .HasMany(rp => rp.Photos)
                .WithOne(p => p.Reply)
                .HasForeignKey(p => p.ReplyId)
                .OnDelete(DeleteBehavior.Cascade);

            // 6. CHECK-CONSTRAINT: лише один з ReviewId або ParentReplyId може бути НЕ NULL
            //  Це спрацює у EF Core версії ≥ 5.0
            builder.ToTable(t=> t.HasCheckConstraint(
                name: "CK_Replies_OneFk",
                sql: @"
                    (ReviewId IS NOT NULL AND ParentReplyId IS NULL)
                    OR (ReviewId IS NULL AND ParentReplyId IS NOT NULL)
                ".Replace(Environment.NewLine, " ")));

            // 7. Індекси (опційно) для швидшого пошуку
            builder.HasIndex(rp => rp.UserId);
            builder.HasIndex(rp => rp.ReviewId);
            builder.HasIndex(rp => rp.ParentReplyId);
        }
    }
}
