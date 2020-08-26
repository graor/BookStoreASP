using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasIndex(x => x.GroupName).IsUnique();
            builder.Property(x => x.GroupName).IsRequired().HasMaxLength(20);
            builder.HasMany(g => g.Users)
                .WithOne(u => u.Group)
                .HasForeignKey(u => u.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
