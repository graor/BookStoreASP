using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BookStore.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            
            builder.Property(x => x.Username).IsRequired().HasMaxLength(30);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);

            builder.HasMany(u => u.UserUseCases)
                .WithOne(uuc => uuc.User)
                .HasForeignKey(uuc => uuc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
