using ElibraryParserWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ElibraryParserWeb.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Publication> Publications { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publication>(entity =>
            {
                entity.ToTable("Publications");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Title).IsRequired().HasMaxLength(500);
                entity.Property(p => p.Authors).IsRequired().HasMaxLength(1000);
                entity.Property(p => p.Link).HasMaxLength(1000);
                entity.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}