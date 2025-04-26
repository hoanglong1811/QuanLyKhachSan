using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data;

public partial class LtbackendLocalContext : DbContext
{
    public LtbackendLocalContext()
    {
    }

    public LtbackendLocalContext(DbContextOptions<LtbackendLocalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingRoomType> BookingRoomTypes { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryDetail> CategoryDetails { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<RevenueReport> RevenueReports { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceUsage> ServiceUsages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-HOANGLON\\MSSQLSERVERHL;Initial Catalog=LTBackendLocal;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.Property(e => e.Adults).HasDefaultValue((byte)0);
            entity.Property(e => e.ArrivalTime)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BookingCode).HasMaxLength(255);
            entity.Property(e => e.Children).HasDefaultValue((byte)0);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Bookings_Users");
        });

        modelBuilder.Entity<BookingRoomType>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(150);

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingRoomTypes)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingRoomTypes_Bookings");

            entity.HasOne(d => d.RoomType).WithMany(p => p.BookingRoomTypes)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingRoomTypes_RoomTypes");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC076538518A");

            entity.ToTable("Category");

            entity.Property(e => e.Icon).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Category_Parent");
        });

        modelBuilder.Entity<CategoryDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceD__3214EC07AAF57DEC");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Icon).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryDetails)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryDetails_Category");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CheckinTime).HasMaxLength(100);
            entity.Property(e => e.CheckoutTime).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasMany(d => d.CategoryDetails).WithMany(p => p.Hotels)
                .UsingEntity<Dictionary<string, object>>(
                    "HotelCategoryDetail",
                    r => r.HasOne<CategoryDetail>().WithMany()
                        .HasForeignKey("CategoryDetailId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HotelCategoryDetails_CategoryDetails"),
                    l => l.HasOne<Hotel>().WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HotelCategoryDetails_Hotels"),
                    j =>
                    {
                        j.HasKey("HotelId", "CategoryDetailId").IsClustered(false);
                        j.ToTable("HotelCategoryDetails");
                        j.HasIndex(new[] { "HotelId", "CategoryDetailId" }, "IX_HotelCategoryDetails")
                            .IsUnique()
                            .IsClustered();
                        j.IndexerProperty<int>("CategoryDetailId").HasColumnName("CategoryDetailID");
                    });
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DueAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ExcessAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InvoiceCode).HasMaxLength(100);
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Booking).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK_Invoices_Bookings");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PaymentDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Invoice).WithMany(p => p.Payments)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_Invoices");
        });

        modelBuilder.Entity<RevenueReport>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TotalRevenue).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.Comment).HasMaxLength(500);

            entity.HasOne(d => d.Booking).WithMany(p => p.Reviews).HasForeignKey(d => d.BookingId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.RoomNumber).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rooms_RoomTypes");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PricePerHour).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PricePerNight).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Hotel).WithMany(p => p.RoomTypes)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomTypes_Hotels");

            entity.HasMany(d => d.CategoryDetails).WithMany(p => p.RoomTypes)
                .UsingEntity<Dictionary<string, object>>(
                    "RoomTypeCategoryDetail",
                    r => r.HasOne<CategoryDetail>().WithMany()
                        .HasForeignKey("CategoryDetailId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RoomTypeCategoryDetails_CategoryDetails"),
                    l => l.HasOne<RoomType>().WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RoomTypeCategoryDetails_RoomTypes"),
                    j =>
                    {
                        j.HasKey("RoomTypeId", "CategoryDetailId").IsClustered(false);
                        j.ToTable("RoomTypeCategoryDetails");
                        j.HasIndex(new[] { "RoomTypeId", "CategoryDetailId" }, "IX_RoomTypeCategoryDetails")
                            .IsUnique()
                            .IsClustered();
                        j.IndexerProperty<int>("CategoryDetailId").HasColumnName("CategoryDetailID");
                    });
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ServiceUsage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ServiceUsage");

            entity.Property(e => e.Quantity).HasDefaultValue(1);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UsedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Booking).WithMany(p => p.ServiceUsages)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK_ServiceUsage_Bookings");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceUsages)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_ServiceUsage_Services");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsDisabled).HasDefaultValue(false);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Users).HasForeignKey(d => d.HotelId);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");

            entity.HasMany(d => d.Roles).WithMany(p => p.UsersNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("UserRoles");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
