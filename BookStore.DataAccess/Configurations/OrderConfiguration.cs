using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.OrderStatus)
                .HasDefaultValue(OrderStatus.Received);

            builder.HasMany(o => o.OrderLines)
                .WithOne(ol => ol.Order)
                .HasForeignKey(ol => ol.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
