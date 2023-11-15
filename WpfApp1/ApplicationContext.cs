using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Models;

namespace WpfApp1
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;database=db;username=postgres;password=12345");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Post>()
                .Property(p => p.UpdatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
