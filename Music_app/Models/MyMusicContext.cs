using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Music_app.Models;

public partial class MyMusicContext : DbContext
{
    public MyMusicContext()
    {
    }

    public MyMusicContext(DbContextOptions<MyMusicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<BaiHat> BaiHats { get; set; }

    public virtual DbSet<CamXuc> CamXucs { get; set; }

    public virtual DbSet<Ctalbum> Ctalbums { get; set; }

    public virtual DbSet<CtdsdgoiY> CtdsdgoiYs { get; set; }

    public virtual DbSet<Ctdsphat> Ctdsphats { get; set; }

    public virtual DbSet<DsgoiY> DsgoiYs { get; set; }

    public virtual DbSet<Dsphat> Dsphats { get; set; }

    public virtual DbSet<LichSu> LichSus { get; set; }

    public virtual DbSet<TacGium> TacGia { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    public virtual DbSet<User> Users { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Idalbum).HasName("PK__Album__683619A378A157B6");

            entity.ToTable("Album");

            entity.Property(e => e.Idalbum)
                .HasMaxLength(15)
                .HasColumnName("IDAlbum");
            entity.Property(e => e.IdtacGia)
                .HasMaxLength(15)
                .HasColumnName("IDTacGia");
            entity.Property(e => e.LinkAnh).HasMaxLength(255);
            entity.Property(e => e.TenAlbum).HasMaxLength(100);

            entity.HasOne(d => d.IdtacGiaNavigation).WithMany(p => p.Albums)
                .HasForeignKey(d => d.IdtacGia)
                .HasConstraintName("FK__Album__IDTacGia__4D94879B");
        });

        modelBuilder.Entity<BaiHat>(entity =>
        {
            entity.HasKey(e => e.IdbaiHat).HasName("PK__BaiHat__CE753E89285B9917");

            entity.ToTable("BaiHat");

            entity.Property(e => e.IdbaiHat)
                .HasMaxLength(15)
                .HasColumnName("IDBaiHat");
            entity.Property(e => e.IdtacGia)
                .HasMaxLength(15)
                .HasColumnName("IDTacGia");
            entity.Property(e => e.IdtheLoai)
                .HasMaxLength(15)
                .HasColumnName("IDTheLoai");
            entity.Property(e => e.LinkAnh).HasMaxLength(255);
            entity.Property(e => e.LinkNhac).HasMaxLength(255);
            entity.Property(e => e.TenBaiHat).HasMaxLength(100);

            entity.HasOne(d => d.IdtacGiaNavigation).WithMany(p => p.BaiHats)
                .HasForeignKey(d => d.IdtacGia)
                .HasConstraintName("FK__BaiHat__IDTacGia__5165187F");

            entity.HasOne(d => d.IdtheLoaiNavigation).WithMany(p => p.BaiHats)
                .HasForeignKey(d => d.IdtheLoai)
                .HasConstraintName("FK__BaiHat__IDTheLoa__5070F446");
        });

        modelBuilder.Entity<CamXuc>(entity =>
        {
            entity.HasKey(e => e.IdcamXuc).HasName("PK__CamXuc__F402D7625446C13A");

            entity.ToTable("CamXuc");

            entity.Property(e => e.IdcamXuc)
                .HasMaxLength(15)
                .HasColumnName("IDCamXuc");
            entity.Property(e => e.CamXuc1)
                .HasMaxLength(100)
                .HasColumnName("CamXuc");
            entity.Property(e => e.IdbaiHat)
                .HasMaxLength(15)
                .HasColumnName("IDBaiHat");
            entity.Property(e => e.Iduser)
                .HasMaxLength(15)
                .HasColumnName("IDUser");
            entity.Property(e => e.Thoigian).HasColumnType("datetime");

            entity.HasOne(d => d.IdbaiHatNavigation).WithMany(p => p.CamXucs)
                .HasForeignKey(d => d.IdbaiHat)
                .HasConstraintName("FK__CamXuc__IDBaiHat__5812160E");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.CamXucs)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK_CamXuc_User");
        });

        modelBuilder.Entity<Ctalbum>(entity =>
        {
            entity.HasKey(e => e.Idctalbum).HasName("PK__CTAlbum__CCBB71A97F64E0B4");

            entity.ToTable("CTAlbum");

            entity.Property(e => e.Idctalbum)
                .HasMaxLength(15)
                .HasColumnName("IDCTAlbum");
            entity.Property(e => e.Idalbum)
                .HasMaxLength(15)
                .HasColumnName("IDAlbum");
            entity.Property(e => e.IdbaiHat)
                .HasMaxLength(15)
                .HasColumnName("IDBaiHat");

            entity.HasOne(d => d.IdalbumNavigation).WithMany(p => p.Ctalbums)
                .HasForeignKey(d => d.Idalbum)
                .HasConstraintName("FK__CTAlbum__IDAlbum__5441852A");

            entity.HasOne(d => d.IdbaiHatNavigation).WithMany(p => p.Ctalbums)
                .HasForeignKey(d => d.IdbaiHat)
                .HasConstraintName("FK__CTAlbum__IDBaiHa__5535A963");
        });

        modelBuilder.Entity<CtdsdgoiY>(entity =>
        {
            entity.HasKey(e => e.IdctdsgoiY).HasName("PK__CTDSDGoi__75D172A68AD06B0F");

            entity.ToTable("CTDSDGoiY");

            entity.Property(e => e.IdctdsgoiY)
                .HasMaxLength(15)
                .HasColumnName("IDCTDSGoiY");
            entity.Property(e => e.IdbaiHat)
                .HasMaxLength(15)
                .HasColumnName("IDBaiHat");
            entity.Property(e => e.IddsgoiY)
                .HasMaxLength(15)
                .HasColumnName("IDDSGoiY");

            entity.HasOne(d => d.IdbaiHatNavigation).WithMany(p => p.CtdsdgoiYs)
                .HasForeignKey(d => d.IdbaiHat)
                .HasConstraintName("FK__CTDSDGoiY__IDBai__6754599E");

            entity.HasOne(d => d.IddsgoiYNavigation).WithMany(p => p.CtdsdgoiYs)
                .HasForeignKey(d => d.IddsgoiY)
                .HasConstraintName("FK__CTDSDGoiY__IDDSG__66603565");
        });

        modelBuilder.Entity<Ctdsphat>(entity =>
        {
            entity.HasKey(e => e.Idctdsphat).HasName("PK__CTDSPHAT__A8FB59A11BE360A2");

            entity.ToTable("CTDSPHAT");

            entity.Property(e => e.Idctdsphat)
                .HasMaxLength(15)
                .HasColumnName("IDCTDSPhat");
            entity.Property(e => e.IdbaiHat)
                .HasMaxLength(15)
                .HasColumnName("IDBaiHat");
            entity.Property(e => e.Iddsphat)
                .HasMaxLength(15)
                .HasColumnName("IDDSPhat");

            entity.HasOne(d => d.IdbaiHatNavigation).WithMany(p => p.Ctdsphats)
                .HasForeignKey(d => d.IdbaiHat)
                .HasConstraintName("FK__CTDSPHAT__IDBaiH__6383C8BA");

            entity.HasOne(d => d.IddsphatNavigation).WithMany(p => p.Ctdsphats)
                .HasForeignKey(d => d.Iddsphat)
                .HasConstraintName("FK__CTDSPHAT__IDDSPh__628FA481");
        });

        modelBuilder.Entity<DsgoiY>(entity =>
        {
            entity.HasKey(e => e.IddsgoiY).HasName("PK__DSGoiY__89E835CA85F13FF8");

            entity.ToTable("DSGoiY");

            entity.Property(e => e.IddsgoiY)
                .HasMaxLength(15)
                .HasColumnName("IDDSGoiY");
            entity.Property(e => e.Iduser)
                .HasMaxLength(15)
                .HasColumnName("IDUser");
            entity.Property(e => e.TenDsgoiY)
                .HasMaxLength(100)
                .HasColumnName("TenDSGoiY");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.DsgoiYs)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK__DSGoiY__IDUser__5FB337D6");
        });

        modelBuilder.Entity<Dsphat>(entity =>
        {
            entity.HasKey(e => e.Iddsphat).HasName("PK__DSPhat__7416152C2BA774BA");

            entity.ToTable("DSPhat");

            entity.Property(e => e.Iddsphat)
                .HasMaxLength(15)
                .HasColumnName("IDDSPHAT");
            entity.Property(e => e.Iduser)
                .HasMaxLength(15)
                .HasColumnName("IDUser");
            entity.Property(e => e.TenDsphat)
                .HasMaxLength(100)
                .HasColumnName("TenDSPhat");
            entity.Property(e => e.ThoiGian).HasColumnType("datetime");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Dsphats)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK__DSPhat__IDUser__5CD6CB2B");
        });

        modelBuilder.Entity<LichSu>(entity =>
        {
            entity.HasKey(e => e.Idls).HasName("PK__LichSu__B87DF98D78D003DE");

            entity.ToTable("LichSu");

            entity.Property(e => e.Idls)
                .HasMaxLength(15)
                .HasColumnName("IDLS");
            entity.Property(e => e.IdbaiHat)
                .HasMaxLength(15)
                .HasColumnName("IDBaiHat");
            entity.Property(e => e.Iduser)
                .HasMaxLength(15)
                .HasColumnName("IDUser");
            entity.Property(e => e.Thoigian).HasColumnType("datetime");

            entity.HasOne(d => d.IdbaiHatNavigation).WithMany(p => p.LichSus)
                .HasForeignKey(d => d.IdbaiHat)
                .HasConstraintName("FK__LichSu__IDBaiHat__17036CC0");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.LichSus)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK__LichSu__IDUser__160F4887");
        });

        modelBuilder.Entity<TacGium>(entity =>
        {
            entity.HasKey(e => e.IdtacGia).HasName("PK__TacGia__3A8B6FF7A5234CE5");

            entity.Property(e => e.IdtacGia)
                .HasMaxLength(15)
                .HasColumnName("IDTacGia");
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.LinkAnh).HasMaxLength(255);
            entity.Property(e => e.Ns).HasColumnName("NS");
            entity.Property(e => e.QueQuan).HasMaxLength(100);
            entity.Property(e => e.TenTg)
                .HasMaxLength(100)
                .HasColumnName("TenTG");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.TenTk).HasName("PK__TaiKhoan__4CF9E776A6701178");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.TenTk)
                .HasMaxLength(30)
                .HasColumnName("TenTK");
            entity.Property(e => e.Iduser)
                .HasMaxLength(15)
                .HasColumnName("IDUser");
            entity.Property(e => e.MatKhau).HasMaxLength(30);

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK__TaiKhoan__IDUser__6A30C649");
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.IdtheLoai).HasName("PK__TheLoai__B353B8744D45767F");

            entity.ToTable("TheLoai");

            entity.Property(e => e.IdtheLoai)
                .HasMaxLength(15)
                .HasColumnName("IDTheLoai");
            entity.Property(e => e.TenTl)
                .HasMaxLength(100)
                .HasColumnName("TenTL");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__User__EAE6D9DF848B71CF");

            entity.ToTable("User");

            entity.Property(e => e.Iduser)
                .HasMaxLength(15)
                .HasColumnName("IDUser");
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.QuocTich).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
            entity.Property(e => e.TenUser).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
