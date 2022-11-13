using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace _6.Models;

public partial class PrnProjectCuoiKy2Context : DbContext
{
    public PrnProjectCuoiKy2Context()
    {
    }

    public PrnProjectCuoiKy2Context(DbContextOptions<PrnProjectCuoiKy2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<ListSong> ListSongs { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer((new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()).GetConnectionString("DbConnection"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.ListNumber).HasName("PK__Lists__3391415746428A17");

            entity.Property(e => e.ListNumber).HasColumnName("listNumber");
            entity.Property(e => e.Author)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("author");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("title");

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.Lists)
                .HasForeignKey(d => d.Author)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lists__author__29572725");
        });

        modelBuilder.Entity<ListSong>(entity =>
        {
            entity.HasKey(e => new { e.ListNumber, e.SongNumber }).HasName("PK__List_Son__1E3827224C4AF74A");

            entity.ToTable("List_Song");

            entity.Property(e => e.ListNumber).HasColumnName("listNumber");
            entity.Property(e => e.SongNumber).HasColumnName("songNumber");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("dateAdded");

            entity.HasOne(d => d.ListNumberNavigation).WithMany(p => p.ListSongs)
                .HasForeignKey(d => d.ListNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__List_Song__listN__2C3393D0");

            entity.HasOne(d => d.SongNumberNavigation).WithMany(p => p.ListSongs)
                .HasForeignKey(d => d.SongNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__List_Song__songN__2D27B809");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.SongNumber).HasName("PK__Songs__DA9667532E80E21F");

            entity.Property(e => e.SongNumber).HasColumnName("songNumber");
            entity.Property(e => e.AudioPath)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("audioPath");
            entity.Property(e => e.Author)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("author");
            entity.Property(e => e.ImgPath)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("imgPath");
            entity.Property(e => e.IsHide).HasColumnName("isHide");
            entity.Property(e => e.Lyric)
                .HasMaxLength(1000)
                .HasColumnName("lyric");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.Songs)
                .HasForeignKey(d => d.Author)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Songs__author__267ABA7A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK__Users__66DCF95D33641D29");

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
