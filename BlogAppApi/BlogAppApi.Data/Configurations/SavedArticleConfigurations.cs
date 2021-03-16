using BlogAppApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.Configurations
{
    public class SavedArticleConfigurations :  IEntityTypeConfiguration<SavedArticle>
    {
        public void Configure(EntityTypeBuilder<SavedArticle> builder)
        {
            builder.HasKey(art => art.Id);
            builder.Property(art => art.Id).ValueGeneratedOnAdd();
            builder.Property(art => art.ArticleId).IsRequired();
            builder.Property(art => art.UserId).IsRequired();
        }
    }
}
