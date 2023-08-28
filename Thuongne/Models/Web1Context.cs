using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Thuongne.Models;

public partial class Web1Context : DbContext
{
    public Web1Context()
    {
    }

    public Web1Context(DbContextOptions<Web1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ColorProduct> ColorProducts { get; set; }

    public virtual DbSet<Method> Methods { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Thumbnail> Thumbnails { get; set; }

    public virtual DbSet<TransactStatus> TransactStatuses { get; set; }

    public virtual DbSet<TuyenDung> TuyenDungs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-HHSJ7V0\\SQLEXPRESS;Initial Catalog=Web1;\nIntegrated Security=True;TrustServerCertificate=True;\n");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accounts__3214EC27B74A841F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Avatar)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(20);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Salt)
                .HasMaxLength(6)
                .IsFixedLength();

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Accounts__RoleID__412EB0B6");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3214EC270F231776");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .HasColumnName("Address");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC2752C9C53D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Avatar)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CatName).HasMaxLength(250);
            entity.Property(e => e.Description).HasColumnType("text");
        });

        modelBuilder.Entity<ColorProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ColorPro__3214EC2776D7369C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameColor).HasMaxLength(100);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.ColorProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ColorProd__Produ__70DDC3D8");
        });

        modelBuilder.Entity<Method>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Methods__3214EC27BEA355BE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MetName).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3214EC273BE76113");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CatId).HasColumnName("CatID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Link)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC271DD3F0F1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.Note).HasMaxLength(250);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.TransactStatusId).HasColumnName("TransactStatusID");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Orders_Accounts");

            entity.HasOne(d => d.Address).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Orders_Addresses");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Orders_Payments");

            entity.HasOne(d => d.TransactStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TransactStatusId)
                .HasConstraintName("FK_Orders_TransactStatus");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC2777B6806B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProducId).HasColumnName("ProducID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__693CA210");

            entity.HasOne(d => d.Produc).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProducId)
                .HasConstraintName("FK__OrderDeta__Produ__6A30C649");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3214EC27AE235825");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.PayName).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC27C97767E0");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BatteryCapacity).HasMaxLength(100);
            entity.Property(e => e.CatId).HasColumnName("CatID");
            entity.Property(e => e.Cpu)
                .HasMaxLength(100)
                .HasColumnName("CPU");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.FrontCam).HasMaxLength(100);
            entity.Property(e => e.MemoryStick).HasMaxLength(100);
            entity.Property(e => e.MethodId).HasColumnName("MethodID");
            entity.Property(e => e.OperatingSystem).HasMaxLength(100);
            entity.Property(e => e.ProName).HasMaxLength(250);
            entity.Property(e => e.Ram).HasMaxLength(100);
            entity.Property(e => e.RearCam).HasMaxLength(100);
            entity.Property(e => e.Rom).HasMaxLength(100);
            entity.Property(e => e.Screen).HasMaxLength(250);
            entity.Property(e => e.ShortDesc).HasMaxLength(100);

            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK__Products__CatID__440B1D61");

            entity.HasOne(d => d.Method).WithMany(p => p.Products)
                .HasForeignKey(d => d.MethodId)
                .HasConstraintName("FK__Products__Method__44FF419A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC27BDF98B51");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Thumbnail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Thumbnai__3214EC27E7B57A9F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProId).HasColumnName("ProID");
            entity.Property(e => e.Thumb)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Pro).WithMany(p => p.Thumbnails)
                .HasForeignKey(d => d.ProId)
                .HasConstraintName("FK__Thumbnail__ProID__47DBAE45");
        });

        modelBuilder.Entity<TransactStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC27E9190A57");

            entity.ToTable("TransactStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.TranName).HasMaxLength(100);
        });

        modelBuilder.Entity<TuyenDung>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TuyenDun__3214EC271098DF7C");

            entity.ToTable("TuyenDung");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adress).HasMaxLength(250);
            entity.Property(e => e.Benefit).HasColumnType("text");
            entity.Property(e => e.Contact).HasColumnType("text");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Require).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.WorkTime).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
