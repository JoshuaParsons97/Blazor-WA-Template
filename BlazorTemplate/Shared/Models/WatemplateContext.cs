using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorTemplate.Shared.Models;

public partial class WatemplateContext : DbContext
{
    public WatemplateContext()
    {
    }

    public WatemplateContext(DbContextOptions<WatemplateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LinkUserRole> LinkUserRoles { get; set; }

    public virtual DbSet<PasswordRecovery> PasswordRecoveries { get; set; }

    public virtual DbSet<ReferenceUserAccessType> ReferenceUserAccessTypes { get; set; }

    public virtual DbSet<ReferenceUserRole> ReferenceUserRoles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=WATemplate;Trusted_Connection=true;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LinkUserRole>(entity =>
        {
            entity.HasKey(e => e.LinkUserRoleId).HasName("PK__LinkUser__AADAFBAF02E24889");

            entity.ToTable("LinkUserRole");

            entity.Property(e => e.LinkUserRoleId).HasColumnName("LinkUserRole_ID");
            entity.Property(e => e.AccessTypeId).HasColumnName("AccessType_ID");
            entity.Property(e => e.RoleId).HasColumnName("Role_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.AccessType).WithMany(p => p.LinkUserRoles)
                .HasForeignKey(d => d.AccessTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LinkUserR__Acces__534D60F1");

            entity.HasOne(d => d.Role).WithMany(p => p.LinkUserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LinkUserR__Role___52593CB8");

            entity.HasOne(d => d.User).WithMany(p => p.LinkUserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LinkUserR__User___5165187F");
        });

        modelBuilder.Entity<PasswordRecovery>(entity =>
        {
            entity.HasKey(e => e.PasswordRecoveryId).HasName("PK__Password__A20878A5CDBA78E2");

            entity.ToTable("PasswordRecovery");

            entity.Property(e => e.PasswordRecoveryId).HasColumnName("PasswordRecovery_ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Expiry).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.PasswordRecoveries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PasswordR__User___5629CD9C");
        });

        modelBuilder.Entity<ReferenceUserAccessType>(entity =>
        {
            entity.HasKey(e => e.AccessTypeId).HasName("PK__Referenc__D621E23F59234B46");

            entity.ToTable("ReferenceUserAccessType");

            entity.Property(e => e.AccessTypeId)
                .ValueGeneratedNever()
                .HasColumnName("AccessType_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReferenceUserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Referenc__D80AB49BDEBAF98A");

            entity.ToTable("ReferenceUserRole");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("Role_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__206D919040F2A5C6");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastActive)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
