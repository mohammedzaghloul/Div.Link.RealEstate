using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Div.Link.RealEstate.DAL.Model;

using Microsoft.AspNetCore.Identity;
using Div.Link.RealEstate.DAL.Model.ApplicationUsers;

namespace Div.Link.RealEstate.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // الجداول
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // BuyerAppointments
            builder.Entity<Appointment>()
                .HasOne(a => a.Buyer)
                .WithMany(u => u.BuyerAppointments)
                .HasForeignKey(a => a.BuyerID)
                .OnDelete(DeleteBehavior.NoAction); // منع مشكلة cascade

            // SellerAppointments
            builder.Entity<Appointment>()
                .HasOne(a => a.Seller)
                .WithMany(u => u.SellerAppointments)
                .HasForeignKey(a => a.SellerID)
                .OnDelete(DeleteBehavior.NoAction); // منع مشكلة cascade

            //    // Rename Identity tables
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    // Rename Identity tables
        //    builder.Entity<ApplicationUser>().ToTable("Users");
        //    builder.Entity<IdentityRole>().ToTable("Roles");
        //    builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        //    builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        //    builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        //    builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        //    builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

        //    // Appointment relationships
        //    builder.Entity<Appointment>()
        //        .HasOne(a => a.Buyer)
        //        .WithMany(u => u.BuyerAppointments)
        //        .HasForeignKey(a => a.BuyerID)
        //        .OnDelete(DeleteBehavior.NoAction);

        //    builder.Entity<Appointment>()
        //        .HasOne(a => a.Seller)
        //        .WithMany(u => u.SellerAppointments)
        //        .HasForeignKey(a => a.SellerID)
        //        .OnDelete(DeleteBehavior.NoAction);

        //    // Decimal precision
        //    builder.Entity<Property>()
        //        .Property(p => p.Price)
        //        .HasPrecision(18, 2);

        //    builder.Entity<Property>()
        //        .Property(p => p.Latitude)
        //        .HasPrecision(18, 8);

        //    builder.Entity<Property>()
        //        .Property(p => p.Longitude)
        //        .HasPrecision(18, 8);

        //    builder.Entity<Payment>()
        //        .Property(p => p.Amount)
        //        .HasPrecision(18, 2);

        //    // Favorite relationships لتجنب multiple cascade paths
        //    builder.Entity<Favorite>()
        //   .HasOne(f => f.User)
        //   .WithMany(u => u.FavoriteProperties)
        //   .HasForeignKey(f => f.UserID)
        //   .OnDelete(DeleteBehavior.Restrict); // منع الحذف المتسلسل


        //    builder.Entity<Favorite>()
        //        .HasOne(f => f.Property)
        //        .WithMany(p => p.Favorites)
        //        .HasForeignKey(f => f.PropertyID)
        //        .OnDelete(DeleteBehavior.Cascade); // ممكن تخلي Cascade على Property فقط
        //}

    }
}