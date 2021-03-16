using BlogAppApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.Seed
{
    class CategoriesSeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category(1,"Web Programlama"),
                new Category(2,".Net Core"),
                new Category(3,"İlişkisel Veri Tabanları"),
                new Category(4,"Identity ile Kimlik Doğrulama"),
                new Category(5,"JWT Authorization"),
                new Category(6,"Frontend Programlama"),
                new Category(7,"Katmanlı mimari"),
                new Category(8,"Restful servisler")
            );
        }
    }
}
