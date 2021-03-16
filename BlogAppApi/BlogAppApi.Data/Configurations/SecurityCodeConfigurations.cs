using BlogAppApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.Configurations
{
    public class SecurityCodeConfigurations : IEntityTypeConfiguration<SecurityCode>
    {
        public void Configure(EntityTypeBuilder<SecurityCode> builder)
        {
            builder.HasKey(code => code.UserId);
            builder.Property(code => code.Code).HasMaxLength(6);
        }
    }
}
