using BlogAppApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.Configurations
{
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(comment => comment.Id);
            builder.Property(comment => comment.Id).ValueGeneratedOnAdd();
            builder.Property(comment => comment.UserId).IsRequired();
            builder.Property(comment => comment.Content).IsRequired().HasMaxLength(200);
            builder.Property(comment => comment.ArticleId).IsRequired();
            builder.Property(comment => comment.Date).IsRequired();

            builder.HasMany(comment => comment.Likes).
                WithOne(like => like.Comment).
                HasForeignKey(like => like.CommentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(comment => comment.ChildComents).
                WithOne(childCom => childCom.ParentComment).
                HasForeignKey(childCom => childCom.ParentCommentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
