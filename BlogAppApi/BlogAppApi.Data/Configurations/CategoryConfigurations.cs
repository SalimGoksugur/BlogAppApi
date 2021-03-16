using BlogAppApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.Configurations
{
    public class CategoryConfigurations :  IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Id).ValueGeneratedOnAdd();
            builder.Property(category => category.Name).HasMaxLength(30);
            builder.HasIndex(category => category.Name).IsUnique();

            builder.HasMany(category => category.Articles).
                WithOne(article => article.Category).
                HasForeignKey(article => article.CategoryId);
        }
    }
}
