using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasIndex(x => x.GenreName).IsUnique();
            builder.Property(x => x.GenreName).IsRequired().HasMaxLength(30);

            builder.HasMany(g => g.Products)
                .WithOne(p => p.Genre)
                .HasForeignKey(p => p.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
