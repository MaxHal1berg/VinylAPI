using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VinylAPI.Models;

public partial class VinylDatabaseContext : DbContext
{

    public VinylDatabaseContext(DbContextOptions<VinylDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Record> Records { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__Record__BFCFB4DD2111C369");

            entity.ToTable("Record");

            entity.Property(e => e.RecordId)
                .ValueGeneratedNever()
                .HasColumnName("record_id");
            entity.Property(e => e.AlbumName)
                .IsUnicode(false)
                .HasColumnName("album_name");
            entity.Property(e => e.AlbumSongs)
                .IsUnicode(false)
                .HasColumnName("album_songs");
            entity.Property(e => e.ArtistName)
                .IsUnicode(false)
                .HasColumnName("artist_name");
            entity.Property(e => e.MyRating).HasColumnName("my_rating");
            entity.Property(e => e.RecordPictureUrl)
                .IsUnicode(false)
                .HasColumnName("record_picture_url");
            entity.Property(e => e.ReleaseYear).HasColumnName("release_year");
            entity.Property(e => e.WhatCollection)
                .IsUnicode(false)
                .HasColumnName("what_collection");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
