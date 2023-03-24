using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRN221_Project_Cinema.Models
{
    public partial class PRN221_Project_CinemaContext : DbContext
    {
        public PRN221_Project_CinemaContext()
        {
        }

        public PRN221_Project_CinemaContext(DbContextOptions<PRN221_Project_CinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<Rate> Rates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;database=PRN221_Project_Cinema;uid=sa;password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Description).HasMaxLength(200);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_Movies_Genres");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname).HasMaxLength(200);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.PersonId });

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rates_Movies");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rates_Persons");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
