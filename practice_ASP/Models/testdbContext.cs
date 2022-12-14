using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using practice_ASP.Models;

namespace practice_ASP.Models
{
    public partial class testdbContext : DbContext
    {
        public testdbContext()
        {
        }

        public testdbContext(DbContextOptions<testdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Testdb> Testdbs { get; set; } = null!;
        public virtual DbSet<Unext> Unexts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=D107-MKM30B4\\SQLEXPRESS01;Database=testdb; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Testdb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("testdb");

                entity.Property(e => e.Genre)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("genre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Who)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("who");
            });

            modelBuilder.Entity<Unext>(entity =>
            {
                entity.ToTable("unext");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Genre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("genre");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<practice_ASP.Models.Book> Book { get; set; }
    }
}
