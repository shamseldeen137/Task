using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Task.Models
{
    public partial class HDdeliveryContext : DbContext
    {
        public HDdeliveryContext()
        {
        }

        public HDdeliveryContext(DbContextOptions<HDdeliveryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddOnsCategory> AddOnsCategories { get; set; }
        public virtual DbSet<Addon> Addons { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<CartItemAddon> CartItemAddons { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ChargeAddress> ChargeAddresses { get; set; }
        public virtual DbSet<ContactU> ContactUs { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<DeliveryMan> DeliveryMen { get; set; }
        public virtual DbSet<DriverOrderCheck> DriverOrderChecks { get; set; }
        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<GeneralAddOn> GeneralAddOns { get; set; }
        public virtual DbSet<GeneralAddOnsCategory> GeneralAddOnsCategories { get; set; }
        public virtual DbSet<GeneralCart> GeneralCarts { get; set; }
        public virtual DbSet<GeneralCartItem> GeneralCartItems { get; set; }
        public virtual DbSet<GeneralCartItemAddon> GeneralCartItemAddons { get; set; }
        public virtual DbSet<GeneralCategory> GeneralCategories { get; set; }
        public virtual DbSet<GeneralItem> GeneralItems { get; set; }
        public virtual DbSet<GeneralStore> GeneralStores { get; set; }
        public virtual DbSet<GeneralStoreType> GeneralStoreTypes { get; set; }
        public virtual DbSet<GeneralSubCategory> GeneralSubCategories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<MailConfigration> MailConfigrations { get; set; }
        public virtual DbSet<MarketCategory> MarketCategories { get; set; }
        public virtual DbSet<MarketSubCategory> MarketSubCategories { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<MedicineCategory> MedicineCategories { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderImage> OrderImages { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderItemAddon> OrderItemAddons { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageProduct> PackageProducts { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Pharmacy> Pharmacies { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<QuickMarket> QuickMarkets { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantType> RestaurantTypes { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreCategory> StoreCategories { get; set; }
        public virtual DbSet<StoreItem> StoreItems { get; set; }
        public virtual DbSet<StoreType> StoreTypes { get; set; }
        public virtual DbSet<T> Ts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCoupon> UserCoupons { get; set; }
        public virtual DbSet<UserNotification> UserNotifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=HDdelivery;MultipleActiveResultSets=true;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<AddOnsCategory>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NameAr).HasMaxLength(150);

                entity.Property(e => e.NameEn).HasMaxLength(150);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AddOnsCategories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_AddOnsCategories_Products");
            });

            modelBuilder.Entity<Addon>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AddonsCategory)
                    .WithMany(p => p.Addons)
                    .HasForeignKey(d => d.AddonsCategoryId)
                    .HasConstraintName("FK_Addons_AddOnsCategories");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Cart_Users");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItem");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_Table_1_Cart");

                entity.HasOne(d => d.MarketItem)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.MarketItemId)
                    .HasConstraintName("FK_CartItem_Items");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK_CartItem_Medicine");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_CartItem_Products");

                entity.HasOne(d => d.StoreItem)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.StoreItemId)
                    .HasConstraintName("FK_CartItem_StoreItem");
            });

            modelBuilder.Entity<CartItemAddon>(entity =>
            {
                entity.ToTable("CartItemAddon");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CartItem)
                    .WithMany(p => p.CartItemAddons)
                    .HasForeignKey(d => d.CartItemId)
                    .HasConstraintName("FK_CartItemAddon_CartItem");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Categories_Restaurant");
            });

            modelBuilder.Entity<ChargeAddress>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_ChargeAddresses_UserId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDefault)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ChargeAddresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(150);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValueType).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<DeliveryMan>(entity =>
            {
                entity.ToTable("DeliveryMan");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CarBackPhoto).HasMaxLength(150);

                entity.Property(e => e.CarNumber).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FristName).HasMaxLength(150);

                entity.Property(e => e.IdbackImage).HasColumnName("IDBackImage");

                entity.Property(e => e.IdfrontImage).HasColumnName("IDFrontImage");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsOnline).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(150);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.StatusDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DeliveryMen)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_DeleveryMan_Users");
            });

            modelBuilder.Entity<DriverOrderCheck>(entity =>
            {
                entity.ToTable("Driver_Order_Check");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AcceptRefuse).HasColumnName("Accept_Refuse");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.DriverOrderChecks)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK_Driver_Order_Check_DeliveryMan");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.DriverOrderChecks)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Driver_Order_Check_Orders");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.DriverOrderChecks)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_Driver_Order_Check_Package");
            });

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("FAQ");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<GeneralAddOn>(entity =>
            {
                entity.ToTable("GeneralAddOn");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.GeneralAddOnCategory)
                    .WithMany(p => p.GeneralAddOns)
                    .HasForeignKey(d => d.GeneralAddOnCategoryId)
                    .HasConstraintName("FK_GeneralAddOn_GeneralAddOnCategory");
            });

            modelBuilder.Entity<GeneralAddOnsCategory>(entity =>
            {
                entity.ToTable("GeneralAddOnsCategory");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NameAr).HasMaxLength(150);

                entity.Property(e => e.NameEn).HasMaxLength(150);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.GeneralAddOnsCategories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_GeneralAddOnsCategory_Products");
            });

            modelBuilder.Entity<GeneralCart>(entity =>
            {
                entity.ToTable("GeneralCart");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.GeneralStore)
                    .WithMany(p => p.GeneralCarts)
                    .HasForeignKey(d => d.GeneralStoreId)
                    .HasConstraintName("FK_GeneralCart_GeneralStore");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GeneralCarts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_GeneralCart_Users");
            });

            modelBuilder.Entity<GeneralCartItem>(entity =>
            {
                entity.ToTable("GeneralCartItem");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.GeneralCart)
                    .WithMany(p => p.GeneralCartItems)
                    .HasForeignKey(d => d.GeneralCartId)
                    .HasConstraintName("FK_GeneralCartItem_GeneralCart");

                entity.HasOne(d => d.GeneralItem)
                    .WithMany(p => p.GeneralCartItems)
                    .HasForeignKey(d => d.GeneralItemId)
                    .HasConstraintName("FK_GeneralCartItem_GeneralItem");
            });

            modelBuilder.Entity<GeneralCartItemAddon>(entity =>
            {
                entity.ToTable("GeneralCartItemAddon");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.GeneralAddon)
                    .WithMany(p => p.GeneralCartItemAddons)
                    .HasForeignKey(d => d.GeneralAddonId)
                    .HasConstraintName("FK_GeneralCartItemAddon_GeneralAddOn");

                entity.HasOne(d => d.GeneralCartItem)
                    .WithMany(p => p.GeneralCartItemAddons)
                    .HasForeignKey(d => d.GeneralCartItemId)
                    .HasConstraintName("FK_GeneralCartItemAddon_GeneralCartItem");
            });

            modelBuilder.Entity<GeneralCategory>(entity =>
            {
                entity.ToTable("GeneralCategory");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.GeneralStore)
                    .WithMany(p => p.GeneralCategories)
                    .HasForeignKey(d => d.GeneralStoreId)
                    .HasConstraintName("FK_Table1_GeneralStore");
            });

            modelBuilder.Entity<GeneralItem>(entity =>
            {
                entity.ToTable("GeneralItem");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Kcal).HasColumnName("KCal");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.GeneralCategory)
                    .WithMany(p => p.GeneralItems)
                    .HasForeignKey(d => d.GeneralCategoryId)
                    .HasConstraintName("FK_GeneralItem_GeneralCategory");

                entity.HasOne(d => d.GeneralSubCategory)
                    .WithMany(p => p.GeneralItems)
                    .HasForeignKey(d => d.GeneralSubCategoryId)
                    .HasConstraintName("FK_GeneralItem_GeneralSubCategory");
            });

            modelBuilder.Entity<GeneralStore>(entity =>
            {
                entity.ToTable("GeneralStore");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Logo).HasMaxLength(150);

                entity.HasOne(d => d.GeneralStoreType)
                    .WithMany(p => p.GeneralStores)
                    .HasForeignKey(d => d.GeneralStoreTypeId)
                    .HasConstraintName("FK_GeneralStore_GeneralStoreType");
            });

            modelBuilder.Entity<GeneralStoreType>(entity =>
            {
                entity.ToTable("GeneralStoreType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<GeneralSubCategory>(entity =>
            {
                entity.ToTable("GeneralSubCategory");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.GeneralCategory)
                    .WithMany(p => p.GeneralSubCategories)
                    .HasForeignKey(d => d.GeneralCategoryId)
                    .HasConstraintName("FKGeneralSubCategoryGeneralCategories");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Kcal).HasColumnName("KCal");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Items_Market_SubCategory");
            });

            modelBuilder.Entity<MailConfigration>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EnableSsl).HasColumnName("EnableSSL");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Smtpemail).HasColumnName("SMTPEmail");

                entity.Property(e => e.Smtppassword).HasColumnName("SMTPPassword");
            });

            modelBuilder.Entity<MarketCategory>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MarketSubCategory>(entity =>
            {
                entity.ToTable("Market_SubCategory");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.MarketSubCategories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Market_SubCategory_MarketCategories");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.HasIndex(e => e.CategoryId, "IX_Medicine_PharmacyId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Medicine_Pharmacy");
            });

            modelBuilder.Entity<MedicineCategory>(entity =>
            {
                entity.ToTable("MedicineCategory");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.MedicineCategories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_MedicineCategory_Pharmacy");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NavigationUrl).HasColumnName("NavigationURL");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.ChargeAddressId, "IX_Orders_ChargeAddressId");

                entity.HasIndex(e => e.PaymentMethodId, "IX_Orders_PaymentMethodId");

                entity.HasIndex(e => e.UserId, "IX_Orders_UserId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.HasOne(d => d.ChargeAddress)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ChargeAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderImage>(entity =>
            {
                entity.ToTable("OrderImage");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderImages)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderImage_Orders");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.OrderImages)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_OrderImage_Package");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasIndex(e => e.OrderId, "IX_OrderItems_OrderId");

                entity.HasIndex(e => e.ProductId, "IX_OrderItems_ProductId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.MarketItem)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.MarketItemId)
                    .HasConstraintName("FK_OrderItems_Items");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK_OrderItems_Medicine");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.StoreItem)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.StoreItemId)
                    .HasConstraintName("FK_OrderItems_StoreItem");
            });

            modelBuilder.Entity<OrderItemAddon>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.OrderItemAddons)
                    .HasForeignKey(d => d.OrderItemId)
                    .HasConstraintName("FK_OrderItemAddons_OrderItems");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Package");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EstimatedCost).HasMaxLength(250);

                entity.Property(e => e.EstimatedDeleveryTime).HasMaxLength(250);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.OrderNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_Package_PaymentMethods");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Package_Users");
            });

            modelBuilder.Entity<PackageProduct>(entity =>
            {
                entity.ToTable("PackageProduct");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageProducts)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_PackageProduct_Package");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Pharmacy>(entity =>
            {
                entity.ToTable("Pharmacy");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Logo).HasMaxLength(150);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

                entity.HasIndex(e => e.UserId, "IX_Products_UserId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsOffer).HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories_CategoryId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<QuickMarket>(entity =>
            {
                entity.ToTable("QuickMarket");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Logo).HasMaxLength(150);

                entity.Property(e => e.Type).HasMaxLength(150);

                entity.HasOne(d => d.RestaurantType)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.RestaurantTypeId)
                    .HasConstraintName("FK_Restaurant_RestaurantTypes");
            });

            modelBuilder.Entity<RestaurantType>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Slider>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Logo).HasMaxLength(150);

                entity.Property(e => e.Type).HasMaxLength(150);

                entity.HasOne(d => d.StoreType)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.StoreTypeId)
                    .HasConstraintName("FK_Store_StoreType");
            });

            modelBuilder.Entity<StoreCategory>(entity =>
            {
                entity.ToTable("StoreCategory");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreCategories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreCategory_Store");
            });

            modelBuilder.Entity<StoreItem>(entity =>
            {
                entity.ToTable("StoreItem");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Kcal).HasColumnName("KCal");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.StoreItems)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_StoreItem_StoreCategory");
            });

            modelBuilder.Entity<StoreType>(entity =>
            {
                entity.ToTable("StoreType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<T>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ts");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsBlocked).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UserCoupon>(entity =>
            {
                entity.HasKey(e => new { e.UseId, e.VoucherId });

                entity.ToTable("UserCoupon");

                entity.Property(e => e.IsUsed).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Use)
                    .WithMany(p => p.UserCoupons)
                    .HasForeignKey(d => d.UseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCoupon_Users");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.UserCoupons)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCoupon_Coupons");
            });

            modelBuilder.Entity<UserNotification>(entity =>
            {
                entity.HasIndex(e => e.NotificationId, "IX_UserNotifications_NotificationId");

                entity.HasIndex(e => e.UserId, "IX_UserNotifications_UserId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.UserNotifications)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserNotifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
