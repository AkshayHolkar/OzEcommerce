using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OzEcommerceV14.Models;

namespace OzEcommerceV14.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Colour> Colour { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrdersDetail { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<SlideShow> SlideShow { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<ComboRecommendation> ComboRecommendation { get; set; }
        public virtual DbSet<LifeStyleCategory> LifeStyleCategory { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<ShippingDetail> ShippingDetail { get; set; }
        public virtual DbSet<ShippingTracker> ShippingTrackers { get; set; }
        public virtual DbSet<ProductVideo> ProductVideo { get; set; }
        public virtual DbSet<ProductWarranty> ProductWarranty { get; set; }
        public virtual DbSet<ProductSize> ProductSize { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<ComboProduct> ComboProduct { get; set; }
        public virtual DbSet<ComboCategory> ComboCategory { get; set; }
        public virtual DbSet<TopSelling> TopSelling { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => new { e.UserId });

                entity.HasOne(d => d.User)
                   .WithMany(p => p.Account)
                   .HasForeignKey(d => d.UserId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_User_Account");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(d => d.User)
                   .WithMany(p => p.Address)
                   .HasForeignKey(d => d.UserId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_User_Address");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParents)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Category_Category");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Body).HasColumnType("ntext");

                entity.Property(e => e.DateCreation).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Customer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Vendor");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Order");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DateCreation).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Account");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_OrderStatus");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Orders_Payment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Vendor");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersDetail_Orders");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Vendor");

                entity.HasOne(d => d.Discount)
                   .WithOne(p => p.Product)
                   .HasForeignKey<Discount>(d => d.ProductId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Product_Discount");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.DatePost).HasColumnType("date");

                entity.Property(e => e.Detail).HasColumnType("ntext");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Customer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Vendor");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => new { e.VendorId });

                entity.HasOne(d => d.User)
                   .WithMany(p => p.Vendor)
                   .HasForeignKey(d => d.VendorId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Vendor_User");

                entity.Property(e => e.Banner)
                .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .IsUnicode(false);

                entity.Property(e => e.TagLine)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComboRecommendation>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.ComboRecommendation)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vendor_Recommendation");

                entity.HasOne(d => d.LifeStyleCategory)
              .WithMany(p => p.ComboRecommendations)
              .HasForeignKey(d => d.LifeStyleCategoryId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_ComboRecommendation_LifeStyle");

                entity.HasOne(d => d.ComboCategory)
              .WithMany(p => p.ComboRecommendations)
              .HasForeignKey(d => d.ComboCategoryId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_ComboRecommendation_Category");
            });

            modelBuilder.Entity<ComboProduct>(entity =>
            {
                entity.HasOne(d => d.ComboRecommendation)
                    .WithMany(p => p.ComboProduct)
                    .HasForeignKey(d => d.RecommendationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComboProduct_Recommendation");

                entity.HasOne(d => d.Product)
                .WithMany(p => p.ComboProduct)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComboProduct_Product");
            });

            modelBuilder.Entity<LifeStyleCategory>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComboCategory>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Discount)
                    .HasForeignKey<Discount>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Discount");
            });

            modelBuilder.Entity<ShippingDetail>(entity =>
            {
                entity.HasKey(e => new { e.ProductId });

                entity.HasOne(d => d.Product)
                   .WithOne(p => p.ShippingDetail)
                   .HasForeignKey<ShippingDetail>(d => d.ProductId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Product_Shipping");
            });

            modelBuilder.Entity<ShippingTracker>(entity =>
            {
                entity.HasKey(e => new { e.OrderId });

                entity.HasOne(d => d.Order)
                   .WithOne(p => p.ShippingTracker)
                   .HasForeignKey<ShippingTracker>(d => d.OrderId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Order_Shipping");
            });

            modelBuilder.Entity<ProductVideo>(entity =>
            {
                entity.HasKey(e => new { e.ProductId });

                entity.HasOne(d => d.Product)
                   .WithOne(p => p.ProductVideo)
                   .HasForeignKey<ProductVideo>(d => d.ProductId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Video_Product");
            });

            modelBuilder.Entity<ProductWarranty>(entity =>
            {
                entity.HasKey(e => new { e.ProductId });

                entity.HasOne(d => d.Product)
                   .WithOne(p => p.ProductWarranty)
                   .HasForeignKey<ProductWarranty>(d => d.ProductId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Warranty_Product");
            });

            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSize)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Size_Product");
            });

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Colour)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Color_Product");
            });
        }
    }
}
