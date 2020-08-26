using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookStore.DataAccess.Configurations
{
    public class ProductPicConfiguration : IEntityTypeConfiguration<ProductPic>
    {
        public void Configure(EntityTypeBuilder<ProductPic> builder)
        {
            builder.Property(x => x.src).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.src).IsUnique();

        }
    }
}
