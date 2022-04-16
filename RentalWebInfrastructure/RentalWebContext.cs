using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RentalWebInfrastructure.Entities;

namespace RentalWebInfrastructure.Infrastructure
{
    public partial class RentalWebContext : DbContext
    {

        public RentalWebContext()
        {
        }

        public RentalWebContext(DbContextOptions<RentalWebContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("workstation id=RentApp.mssql.somee.com;packet size=4096;user id=nurseryu_SQLLogin_1;pwd=96ta8w1wld;data source=RentApp.mssql.somee.com;persist security info=False;initial catalog=RentApp;");
            }
        }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<IpAddress> IpAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PhysicalAddress> PhysicalAddresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(50);
                entity.Property(e => e.Description)
                .HasMaxLength(250);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(50);
                entity.Property(e => e.Description)
                .HasMaxLength(250);
                entity.HasOne(e => e.Store)
                .WithMany(e => e.Categories)
                .HasForeignKey(e => e.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(50);
                entity.Property(e => e.Description)
                .HasMaxLength(250);
                entity.HasOne(e => e.Category)
                .WithMany(e => e.SubCategories)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(50);
                entity.Property(e => e.Email)
                .HasMaxLength(100);
                entity.Property(e => e.Password)
               .HasMaxLength(100);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(50);
                entity.Property(e => e.Description)
                .HasMaxLength(250);
                entity.HasOne(e => e.Category)
                .WithMany(e => e.Brands)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Total).HasColumnType("decimal(18,8)");
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Discount).HasColumnType("decimal(5,2)");
                entity.Property(e => e.Total).HasColumnType("decimal(18,8)");
                entity.HasOne(e => e.Cart)
                .WithMany(e => e.CartItems)
                .HasForeignKey(e => e.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.Product)
               .WithMany(e => e.CartItems)
               .HasForeignKey(e => e.ProductId)
               .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ArrivalDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ReturnDate).HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<IpAddress>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                .WithMany(e => e.IpAddresses)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cost).HasColumnType("decimal(18,8)");
                entity.Property(e => e.Total).HasColumnType("decimal(18,8)");
                entity.Property(e => e.Currency)
                .HasMaxLength(15);
                entity.HasOne(e => e.User)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.Cart)
                .WithOne(e => e.Orders).HasForeignKey<Order>(e=> e.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PaymentType)
                .HasMaxLength(20);
                entity.Property(e => e.Token)
                .HasMaxLength(250);
                entity.Property(e => e.Currency)
                .HasMaxLength(15);
                entity.HasOne(e => e.User)
                .WithMany(e => e.Payments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.Order)
                .WithOne(e => e.Payment)
                .HasForeignKey<Payment>(e => e.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<PhysicalAddress>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName)
                .HasMaxLength(50);
                entity.Property(e => e.LastName)
                .HasMaxLength(50);
                entity.Property(e => e.BillingAddress);
                entity.Property(e => e.City)
                .HasMaxLength(50);
                entity.Property(e => e.State)
                .HasMaxLength(50);
                entity.Property(e => e.ZipCode)
                .HasMaxLength(50);
                entity.Property(e => e.Mobile)
                .HasMaxLength(30);
                entity.HasOne(e => e.User)
                .WithMany(e => e.PhysicalAddress)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(50);
                entity.Property(e => e.SKU)
                .HasMaxLength(50);
                entity.Property(e => e.Description);
                entity.Property(e => e.Notes);
                entity.Property(e => e.Specifications);
                entity.Property(e => e.ProductIncludes);
                entity.Property(e => e.ShortDescription)
                .HasMaxLength(1000);
                entity.Property(e => e.Image)
                .HasMaxLength(500);
                entity.Property(e => e.Status)
                .HasMaxLength(50);
                entity.Property(e => e.Types)
              .HasMaxLength(50);
                entity.Property(e => e.Tags)
              .HasMaxLength(1000);
                entity.Property(e => e.Price).HasColumnType("decimal(18,8)");
                entity.HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.Brand)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.SubCategory)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title)
                .HasMaxLength(50);
                entity.Property(e => e.Comment)
                .HasMaxLength(1000);
                entity.Property(e => e.ReviewBy)
                .HasMaxLength(100);
                entity.Property(e => e.Address)
                .HasMaxLength(100);
                entity.HasOne(e => e.Product)
                .WithMany(e => e.ProductReviews)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.User)
                .WithMany(e => e.ProductReviews)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<ProductImages>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title)
                .HasMaxLength(100);
                entity.Property(e => e.Tags)
                .HasMaxLength(100);
                entity.HasOne(e => e.Product)
                .WithMany(e => e.ProductImages)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(50);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ShippingMethod)
                .HasMaxLength(100);
                entity.Property(e => e.Status)
                .HasMaxLength(50);
                entity.HasOne(e => e.Order)
                .WithOne(e => e.Shipping)
                .HasForeignKey<Shipping>(e => e.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.PhysicalAddress)
                .WithOne(e => e.Shipping)
                .HasForeignKey<Shipping>(e => e.ShippingAddress)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(50);
                entity.Property(e => e.Description)
                .HasMaxLength(250);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(50);
                entity.Property(e => e.Email)
                .HasMaxLength(50);
                entity.Property(e => e.Password)
                .HasMaxLength(50);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.AdminUser)
                .WithMany(e => e.UserRole)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.Role)
                .WithMany(e => e.UserRole)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
