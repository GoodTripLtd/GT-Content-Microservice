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
        public override void ConfigureOtherProperties(EntityTypeBuilder<Reply> builder)
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

            // 3. Відношення Reply → Review (1:N) через ReviewId
            // Якщо ReviewId != null, то ця Reply належить до Review
            builder
                .HasOne(rp => rp.Review)
                .WithMany(r => r.Replies)   // вказуємо, що Review.Replies – колекція всіх Reply
                .HasForeignKey(rp => rp.ReviewId)
                .OnDelete(DeleteBehavior.Restrict);

            // 4. Самозв’язок Reply → ChildReplies (1:N) через ParentReplyId
            // Якщо ParentReplyId != null, то ця Reply — дочірня для іншої Reply
            builder
                .HasOne(rp => rp.ParentReply)
                .WithMany(rp => rp.ChildReplies)
                .HasForeignKey(rp => rp.ParentReplyId)
                .OnDelete(DeleteBehavior.Cascade);

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
