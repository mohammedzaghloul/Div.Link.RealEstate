using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Model.ApplicationUser;
using Microsoft.AspNetCore.Identity;

namespace Div.Link.RealEstate.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
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

            // إعادة تسمية جداول Identity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            // تكوين علاقة User -> Properties
            builder.Entity<User>()
                .HasMany(u => u.OwnedProperties)
                .WithOne(p => p.Seller)
                .HasForeignKey(p => p.SellerID)
                .OnDelete(DeleteBehavior.Restrict);

            // تكوين علاقة User -> Favorites
            builder.Entity<User>()
                .HasMany(u => u.FavoriteProperties)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // تكوين علاقة User -> Payments
            builder.Entity<User>()
                .HasMany(u => u.Payments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // تكوين علاقة User -> Appointments (كمشتري)
            builder.Entity<User>()
                .HasMany(u => u.BuyerAppointments)
                .WithOne(a => a.Buyer)
                .HasForeignKey(a => a.BuyerID)
                .OnDelete(DeleteBehavior.Restrict);

            // تكوين علاقة User -> Appointments (كبائع)
            builder.Entity<User>()
                .HasMany(u => u.SellerAppointments)
                .WithOne(a => a.Seller)
                .HasForeignKey(a => a.SellerID)
                .OnDelete(DeleteBehavior.Restrict);

            // تكوين علاقة Property -> Images
            builder.Entity<Property>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Property)
                .HasForeignKey(i => i.PropertyID)
                .OnDelete(DeleteBehavior.Cascade);

            // تكوين علاقة Property -> Favorites
            builder.Entity<Property>()
                .HasMany(p => p.Favorites)
                .WithOne(f => f.Property)
                .HasForeignKey(f => f.PropertyID)
                .OnDelete(DeleteBehavior.Cascade);

            // تكوين علاقة Property -> Payments
            builder.Entity<Property>()
                .HasMany(p => p.Payments)
                .WithOne(p => p.Property)
                .HasForeignKey(p => p.PropertyID)
                .OnDelete(DeleteBehavior.Restrict);

            // تكوين علاقة Property -> Appointments
            builder.Entity<Property>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Property)
                .HasForeignKey(a => a.PropertyID)
                .OnDelete(DeleteBehavior.Cascade);

            // تعريف مفاتيح مركبة وفهارس
            builder.Entity<Favorite>()
                .HasIndex(f => new { f.UserID, f.PropertyID })
                .IsUnique();

            builder.Entity<Appointment>()
                .HasIndex(a => new { a.PropertyID, a.AppointmentDateTime })
                .IsUnique();

            builder.Entity<Payment>()
                .HasIndex(p => p.TransactionId)
                .IsUnique();

            // تحديد أنواع البيانات للمفاتيح الأجنبية
            ConfigureForeignKeyTypes(builder);
        }

        private void ConfigureForeignKeyTypes(ModelBuilder builder)
        {
            // جميع المفاتيح الأجنبية التي تشير إلى User يجب أن تكون nvarchar(450)
            builder.Entity<Property>()
                .Property(p => p.SellerID)
                .HasColumnType("nvarchar(450)");

            builder.Entity<Favorite>()
                .Property(f => f.UserID)
                .HasColumnType("nvarchar(450)");

            builder.Entity<Payment>()
                .Property(p => p.UserID)
                .HasColumnType("nvarchar(450)");

            builder.Entity<Appointment>()
                .Property(a => a.BuyerID)
                .HasColumnType("nvarchar(450)");

            builder.Entity<Appointment>()
                .Property(a => a.SellerID)
                .HasColumnType("nvarchar(450)");
        }
    }
}