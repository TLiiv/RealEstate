using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;




namespace RealEstate.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<UserPost> UserPost { get; set; }

        public DbSet<UserPostDetails> UserPostDetails { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<County> County { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserPost>()
        .HasOne(up => up.User)
        .WithMany(u => u.UserPosts)
        .HasForeignKey(up => up.UserId)
        .OnDelete(DeleteBehavior.Cascade);

            // Configure other relationships (City, County, District)
            builder.Entity<UserPost>()
                .HasOne(up => up.City)
                .WithMany()
                .HasForeignKey(up => up.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserPost>()
                .HasOne(up => up.County)
                .WithMany()
                .HasForeignKey(up => up.CountyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserPost>()
                .HasOne(up => up.District)
                .WithMany()
                .HasForeignKey(up => up.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        
    }
}

