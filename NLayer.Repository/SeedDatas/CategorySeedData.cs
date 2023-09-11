using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.SeedDatas
{
    internal class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
                (
                    new Category { Id = 1, Name = "Kitaplar" },
                    new Category { Id = 2, Name = "Defterler" },
                    new Category { Id = 3, Name = "Kalemler" }


                );
        }
    }
}
