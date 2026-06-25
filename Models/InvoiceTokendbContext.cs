using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SecureInventoryWebApiUsingToken.Models;

public partial class InvoiceTokendbContext : DbContext
{
    public InvoiceTokendbContext()
    {
    }

    public InvoiceTokendbContext(DbContextOptions<InvoiceTokendbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblInvoiceDetail> TblInvoiceDetails { get; set; }

    public virtual DbSet<TblInvoicePayment> TblInvoicePayments { get; set; }

    public virtual DbSet<TblInvoiceProduct> TblInvoiceProducts { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-0U87C844;Database=InvoiceTokendb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__TblCusto__A4AE64D8DFD03098");

            entity.Property(e => e.City)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__TblEmplo__7AD04F11A5599A7A");

            entity.HasIndex(e => e.EmployeeCode, "UQ__TblEmplo__1F642548D52AA1F4").IsUnique();

            entity.Property(e => e.Designation)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblInvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__TblInvoi__D796AAB5CDC647A5");

            entity.Property(e => e.Status).IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.TblInvoiceDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("ckid");
        });

        modelBuilder.Entity<TblInvoicePayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__TblInvoi__9B556A386C4D3C8E");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Invoice).WithMany(p => p.TblInvoicePayments)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("icid");
        });

        modelBuilder.Entity<TblInvoiceProduct>(entity =>
        {
            entity.HasKey(e => e.InvoiceProductId).HasName("PK__TblInvoi__D032D0C9CFD86AB5");

            entity.HasOne(d => d.Invoice).WithMany(p => p.TblInvoiceProducts)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("inid");

            entity.HasOne(d => d.Product).WithMany(p => p.TblInvoiceProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("pdid");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__TblProdu__B40CC6CD188A1CF7");

            entity.Property(e => e.ProductName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
