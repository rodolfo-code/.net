using Blog.Models;
using FluentBlog.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        // public DbSet<PostTag> PostTags { get; set; }
        // public DbSet<Role> Roles { get; set; }
        // public DbSet<Tag> Tags { get; set; }
        // public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
            .UseSqlServer("Server=[::1],1433;Database=FluentBlog;User ID=sa;Password=Nj0q4$Fr1fa7@9aksedQUOp;Trusted_Connection=False; TrustServerCertificate=True;");
            options.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }
    }
}