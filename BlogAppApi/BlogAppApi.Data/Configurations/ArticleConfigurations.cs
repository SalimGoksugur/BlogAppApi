using BlogAppApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.Configurations
{
    public class ArticleConfigurations : IEntityTypeConfiguration<Article>

    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(art => art.Id);
            builder.Property(art => art.Id).ValueGeneratedOnAdd();
            builder.Property(art => art.Title).IsRequired().HasMaxLength(100);
            builder.HasIndex(art => art.Title).IsUnique();
            builder.Property(art => art.Content).IsRequired().HasMaxLength(5000);
            builder.Property(art => art.ContentSummary).IsRequired().HasMaxLength(300);
            builder.Property(art => art.CategoryId).IsRequired();
            builder.Property(art => art.AuthorId).IsRequired();

            builder.HasMany(art => art.Comments).
                WithOne(comment => comment.Article).
                HasForeignKey(comment => comment.ArticleId).
                OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(art => art.Likes).
                WithOne(like => like.Article).
                HasForeignKey(like => like.ArticleId).
                OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(art => art.SavedArticles).
                WithOne(savedArt => savedArt.Article).
                HasForeignKey(savedArt => savedArt.ArticleId).
                OnDelete(DeleteBehavior.Cascade);




        }
    }
}
