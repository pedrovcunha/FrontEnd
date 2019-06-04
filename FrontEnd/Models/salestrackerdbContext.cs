using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FrontEnd.Models
{
    public partial class salestrackerdbContext : DbContext
    {
        public salestrackerdbContext()
        {
        }

        public salestrackerdbContext(DbContextOptions<salestrackerdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<BrandCategory> BrandCategory { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<OrderProducts> OrderProducts { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Postcodes> Postcodes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<PromotionalAgencies> PromotionalAgencies { get; set; }
        public virtual DbSet<RetailStores> RetailStores { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesRepresentatives> SalesRepresentatives { get; set; }
        public virtual DbSet<States> States { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=salestrackerdbinstance.caqbw1dpdyst.ap-southeast-2.rds.amazonaws.com; Initial Catalog=salestrackerdb; User ID = salesTrackerdb; Password = tEh2GktSeoh2; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Adresses_Countries");

                entity.HasOne(d => d.PostCode)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PostCodeId)
                    .HasConstraintName("FK_Adresses_Postcodes");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Adresses_States");
            });

            modelBuilder.Entity<BrandCategory>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.BrandManager)
                    .WithMany(p => p.BrandCategory)
                    .HasForeignKey(d => d.BrandManagerId)
                    .HasConstraintName("FK_BrandCategory_People");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ThreeCharCountryCode).HasMaxLength(3);

                entity.Property(e => e.TwoCharCountryCode).HasMaxLength(2);
            });

            modelBuilder.Entity<OrderProducts>(entity =>
            {
                entity.HasKey(e => new { e.OrderOrderId, e.ProductProductId });

                entity.HasIndex(e => new { e.OrderOrderId, e.ProductProductId })
                    .HasName("IX_OrderItems");

                entity.Property(e => e.OrderOrderId).HasColumnName("Order_OrderId");

                entity.Property(e => e.ProductProductId).HasColumnName("Product_ProductId");

                entity.HasOne(d => d.OrderOrder)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProducts_Orders");

                entity.HasOne(d => d.ProductProduct)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProducts_Products");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Commission).HasColumnType("decimal(5, 4)");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.RetailStore)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RetailStoreId)
                    .HasConstraintName("FK_Orders_RetailStore");

                entity.HasOne(d => d.SalesRepresentative)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SalesRepresentativeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_SalesRepresentatives");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_People_Adresses");
            });

            modelBuilder.Entity<Postcodes>(entity =>
            {
                entity.Property(e => e.Latitude).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.Suburb).HasMaxLength(50);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Postcodes)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Postcodes_States");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.BrandCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandCategoryId)
                    .HasConstraintName("FK_Products_BrandCategory");
            });

            modelBuilder.Entity<PromotionalAgencies>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.PromotionalAgencies)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_PromotionAgencies_Adresses");
            });

            modelBuilder.Entity<RetailStores>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.RetailStores)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_RetailStore_Adresses");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.Property(e => e.Comission).HasColumnType("decimal(5, 4)");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Sales_Products");

                entity.HasOne(d => d.RetailStore)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.RetailStoreId)
                    .HasConstraintName("FK_Sales_RetailStores");

                entity.HasOne(d => d.SalesRepresentative)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.SalesRepresentativeId)
                    .HasConstraintName("FK_Sales_SalesRepresentatives");
            });

            modelBuilder.Entity<SalesRepresentatives>(entity =>
            {
                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.HasOne(d => d.PromotionAgency)
                    .WithMany(p => p.SalesRepresentatives)
                    .HasForeignKey(d => d.PromotionAgencyId)
                    .HasConstraintName("FK_SalesRepresentatives_PromotionAgencies");

                entity.HasOne(d => d.RetailStore)
                    .WithMany(p => p.SalesRepresentatives)
                    .HasForeignKey(d => d.RetailStoreId)
                    .HasConstraintName("FK_SalesRepresentatives_RetailStores");
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Capital).HasMaxLength(30);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_States_Countries");
            });
        }
    }
}
