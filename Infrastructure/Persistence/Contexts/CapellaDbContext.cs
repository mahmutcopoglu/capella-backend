using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class CapellaDbContext : DbContext
    {
        public CapellaDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ClassificationAttribute> ClassificationAttributes { get; set; }
        public DbSet<ClassificationAttributeValue> ClassificationAttributeValues { get; set; }
        public DbSet<Media> Medias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .HasOne(category => category.ParentCategory)
                .WithMany(category => category.SubCategories)
                .HasForeignKey(category => category.ParentCategoryId);

            modelBuilder
                .Entity<Product>()
                .HasMany(product=> product.Categories)
                .WithMany(category => category.Products)
                .UsingEntity(j => j.ToTable("ProductsCategories"));

            modelBuilder
                .Entity<Classification>()
                .HasMany(p => p.Categories)
                .WithMany(p => p.Classifications)
                .UsingEntity(j => j.ToTable("CategoriesClassifications"));

            modelBuilder
                .Entity<Classification>()
                .HasMany(p => p.ClassificationAttributes)
                .WithMany(p => p.Classifications)
                .UsingEntity(j => j.ToTable("ClassificationClassificationAttributes"));

            modelBuilder
                .Entity<Product>()
                .HasMany(product => product.ClassificationAttributeValues)
                .WithMany(classificationAttributeValues => classificationAttributeValues.Products)
                .UsingEntity(j => j.ToTable("ProductClassificationAttributeValues"));




        }
    }
}
