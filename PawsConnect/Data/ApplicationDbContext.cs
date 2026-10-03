using Microsoft.EntityFrameworkCore;
using PawsConnect.Models;

namespace PawsConnect.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Dog> Dogs { get; set; }

        public DbSet<DogImage> DogImages { get; set; }

        public DbSet<AdoptionApplication> AdoptionApplications { get; set; }

        public DbSet<ForumPost> ForumPosts { get; set; }

        public DbSet<ForumReply> ForumReplies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // User email must be unique.
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();


            // User -> Adoption Applications
            modelBuilder.Entity<AdoptionApplication>()
                .HasOne(a => a.User)
                .WithMany(u => u.AdoptionApplications)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            // Dog -> Adoption Applications
            modelBuilder.Entity<AdoptionApplication>()
                .HasOne(a => a.Dog)
                .WithMany(d => d.AdoptionApplications)
                .HasForeignKey(a => a.DogId)
                .OnDelete(DeleteBehavior.Restrict);


            // Dog -> Dog Images
            modelBuilder.Entity<DogImage>()
                .HasOne(i => i.Dog)
                .WithMany(d => d.Images)
                .HasForeignKey(i => i.DogId)
                .OnDelete(DeleteBehavior.Cascade);


            // User -> Forum Posts
            modelBuilder.Entity<ForumPost>()
                .HasOne(p => p.User)
                .WithMany(u => u.ForumPosts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            // Forum Post -> Forum Replies
            modelBuilder.Entity<ForumReply>()
                .HasOne(r => r.Post)
                .WithMany(p => p.Replies)
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.Cascade);


            // User -> Forum Replies
            modelBuilder.Entity<ForumReply>()
                .HasOne(r => r.User)
                .WithMany(u => u.ForumReplies)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}