using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(x => x.Title).IsUnique();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(40);

            builder.HasMany(p => p.OrderLines)
                .WithOne(ol => ol.Product)
                .HasForeignKey(ol => ol.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.ProductPics)
                .WithOne(pp => pp.Product)
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
