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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne(category => category.ParentCategory)
                .WithMany(category => category.SubCategories)
                .HasForeignKey(category => category.ParentCategoryId);

            modelBuilder.Entity<CategoriesClassifications>()
                .HasKey(cc => new { cc.CategoryId, cc.ClassificationId });
            modelBuilder.Entity<CategoriesClassifications>()
                .HasOne(cc => cc.Category)
                .WithMany(c => c.Classifications);
            modelBuilder.Entity<CategoriesClassifications>()
                .HasOne(cc => cc.Classification)
                .WithMany(c => c.Categories);
        }
    }
}
