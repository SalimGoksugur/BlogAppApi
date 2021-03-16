using BlogAppApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.Configurations
{
    public class CommentLikeConfigurations :  IEntityTypeConfiguration<CommentLike>
    {
        public void Configure(EntityTypeBuilder<CommentLike> builder)
        {
            builder.HasKey(comLike => comLike.Id);
            builder.Property(comLike => comLike.Id).ValueGeneratedOnAdd();
            builder.Property(comLike => comLike.CommentId).IsRequired();
            builder.Property(comLike => comLike.UserId).IsRequired();
         }
    }
}
