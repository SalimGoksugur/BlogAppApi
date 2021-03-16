using BlogAppApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.Configurations
{
    public class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();
            builder.Property(user => user.UserName).IsRequired().HasMaxLength(30);

            builder.HasMany(user => user.Articles).
                WithOne(article => article.Author).
                HasForeignKey(article => article.AuthorId).
                OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(user => user.Comments).
                WithOne(comment => comment.User).
                HasForeignKey(comment => comment.UserId).
                OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(user => user.ArticleLikes).
                WithOne(artLike => artLike.User).
                HasForeignKey(artLike => artLike.UserId).
                OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(user => user.CommentLikes).
                WithOne(comLike => comLike.User).
                HasForeignKey(comLike => comLike.UserId).
                OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(user => user.SavedArticles).
                WithOne(savedArt => savedArt.User).
                HasForeignKey(savedArt => savedArt.UserId).
                OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(user => user.SecurityCode)
                .WithOne(code => code.User)
                .HasForeignKey<SecurityCode>(code => code.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(user => user.RefreshToken)
                .WithOne(token => token.User)
                .HasForeignKey<UserRefreshToken>(token => token.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
