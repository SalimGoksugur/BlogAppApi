using BlogAppApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.Configurations
{
    public class ArticleLikeConfigurations : IEntityTypeConfiguration<ArticleLike>
    {
        public void Configure(EntityTypeBuilder<ArticleLike> builder)
        {
            builder.HasKey(artLike => artLike.Id);
            builder.Property(artLike => artLike.Id).ValueGeneratedOnAdd();
            builder.Property(artLike => artLike.ArticleId).IsRequired();
            builder.Property(artLike => artLike.UserId).IsRequired();
        }
    }
}
