using BookStore.DataAccess.Configurations;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess
{
    public class BookStoreContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPicConfiguration());

            modelBuilder.Entity<Group>().HasQueryFilter(x => !x.IsDeleted);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Test1;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines{ get; set; }       
        public DbSet<Group> Groups { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<ProductPic> ProductPics { get; set; }
    }
}
