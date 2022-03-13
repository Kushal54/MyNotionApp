using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyNotionApp.Models
{
    public partial class MyNotionContext : DbContext
    {
        public MyNotionContext()
        {
        }

        public MyNotionContext(DbContextOptions<MyNotionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<BlogCategory> BlogCategories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DBConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("blog");

                entity.Property(e => e.BlogId).HasColumnName("blogId");

                entity.Property(e => e.BlogBody).HasColumnName("blogBody");

                entity.Property(e => e.BlogCategoryId).HasColumnName("blogCategoryId");

                entity.Property(e => e.BlogDescription).HasColumnName("blogDescription");

                entity.Property(e => e.BlogTitle)
                    .HasMaxLength(255)
                    .HasColumnName("blogTitle");

                entity.Property(e => e.Likes).HasColumnName("likes");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.ToTable("blogCategory");

                entity.Property(e => e.BlogCategoryId).HasColumnName("blogCategoryId");

                entity.Property(e => e.CategoryName).HasColumnName("categoryName");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
