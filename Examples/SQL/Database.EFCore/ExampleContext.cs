using System;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.EFCore
{
    public partial class ExampleContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<BlogEntity> Blogs { get; set; }
        
        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;User ID=postgres;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<BlogEntity>(entity =>
            {
                entity.ToTable("Blog");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(d => d.Category);
            });

            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
            });
            
            modelBuilder.Entity<CategoryEntity>().HasData(new CategoryEntity { Id = 1, Title = "Freezing" });
            modelBuilder.Entity<CategoryEntity>().HasData(new CategoryEntity { Id = 2, Title = "Bracing" });
            modelBuilder.Entity<CategoryEntity>().HasData(new CategoryEntity { Id = 3, Title = "Chilly" });
            modelBuilder.Entity<CategoryEntity>().HasData(new CategoryEntity { Id = 4, Title = "Cool" });
            modelBuilder.Entity<CategoryEntity>().HasData(new CategoryEntity { Id = 5, Title = "Mild" });
            modelBuilder.Entity<CategoryEntity>().HasData(new CategoryEntity { Id = 6, Title = "Warm" });
            modelBuilder.Entity<CategoryEntity>().HasData(new CategoryEntity { Id = 7, Title = "Balmy" });
            modelBuilder.Entity<CategoryEntity>().HasData(new CategoryEntity { Id = 8, Title = "Hot" });
            modelBuilder.Entity<CategoryEntity>().HasData(new CategoryEntity { Id = 9, Title = "Sweltering" });
            modelBuilder.Entity<CategoryEntity>().HasData(new CategoryEntity { Id = 10, Title = "Scorching" });
            
            modelBuilder.Entity<BlogEntity>().HasData(new
            {
                Id = 1, 
                TimeStamp = new DateTime(2020, 1, 1),
                Title = "Russian news",
                CategoryId = 3
            });
            
            modelBuilder.Entity<BlogEntity>().HasData(new
            {
                Id = 2, 
                TimeStamp = new DateTime(2020, 1, 2),
                Title = "Europe news",
                CategoryId = 5
            });
            
            modelBuilder.Entity<BlogEntity>().HasData(new
            {
                Id = 3, 
                TimeStamp = new DateTime(2020, 1, 3),
                Title = "Japan news",
                CategoryId = 1
            });
            
            //modelBuilder.Entity<BlogEntity>().OwnsOne(p => p.Category).HasData(new { Date = new DateTime(2020, 1, 1), Temperature = -1, Title = "Chill" });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
