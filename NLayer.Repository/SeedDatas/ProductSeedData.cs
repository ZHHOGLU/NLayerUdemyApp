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
    internal class ProductSeedData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
            {
                Id = 1,
                CategoryId = 3,
                Name = "Kalem1",
                Price = 1,
                Stock = 20,
                CreatedDate = DateTime.Now,


            },
                new Product
                {
                    Id = 2,
                    CategoryId = 3,
                    Name = "Kalem2",
                    Price = 300,
                    Stock = 20,
                    CreatedDate = DateTime.Now,


                },
                new Product
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Defter1",
                    Price = 300,
                    Stock = 20,
                    CreatedDate = DateTime.Now,


                },
                new Product
                {
                    Id = 4,
                    CategoryId = 1,
                    Name = "Kitap1",
                    Price = 201,
                    Stock = 20,
                    CreatedDate = DateTime.Now,


                },
                new Product
                {
                    Id = 5,
                    CategoryId = 1,
                    Name = "Defter2",
                    Price = 100,
                    Stock = 20,
                    CreatedDate = DateTime.Now,


                });

        }
    }
}
