using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace entity_framework.Modelcls;

public partial class QuanLyLopContext : DbContext
{
    public QuanLyLopContext()
    {
    }

    public QuanLyLopContext(DbContextOptions<QuanLyLopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lsh> Lshes { get; set; }

    public virtual DbSet<Sv> Svs { get; set; }
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-IPDB6V8\\SQLEXPRESS2022;Database=QuanLyLop;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lsh>(entity =>
        {
            entity.HasKey(e => e.IdLop).HasName("PK__LSH__2DBF33AC733251CB");

            entity.ToTable("LSH");

            entity.Property(e => e.IdLop)
                .ValueGeneratedNever()
                .HasColumnName("ID_Lop");
            entity.Property(e => e.NameLop).HasMaxLength(50);
        });

        modelBuilder.Entity<Sv>(entity =>
        {
            entity.HasKey(e => e.Mssv).HasName("PK__SV__6CB3B7F96BA0B28E");

            entity.ToTable("SV");

            entity.Property(e => e.Mssv)
                .HasMaxLength(9)
                .HasColumnName("MSSV");
            entity.Property(e => e.Dtb).HasColumnName("DTB");
            entity.Property(e => e.IdLop).HasColumnName("ID_Lop");
            entity.Property(e => e.NameSv)
                .HasMaxLength(100)
                .HasColumnName("NameSV");
            entity.Property(e => e.Ns)
                .HasColumnType("date")
                .HasColumnName("NS");

            entity.HasOne(d => d.IdLopNavigation).WithMany(p => p.Svs)
                .HasForeignKey(d => d.IdLop)
                .HasConstraintName("FK__SV__ID_Lop__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
