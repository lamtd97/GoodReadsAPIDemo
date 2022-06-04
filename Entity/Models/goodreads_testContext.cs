using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity.Models
{
    public partial class goodreads_testContext : DbContext
    {
        public goodreads_testContext()
        {
        }

        public goodreads_testContext(DbContextOptions<goodreads_testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserBook> UserBooks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=192.168.31.104;user=root;password=12345678@Abc;database=goodreads_test", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookId)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.DatePublication).HasMaxLength(6);

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.DateCreated).HasMaxLength(6);
            });

            modelBuilder.Entity<UserBook>(entity =>
            {
                entity.ToTable("user_book");

                entity.HasIndex(e => e.BookId, "IX_user_book_BookId");

                entity.HasIndex(e => e.UserId, "IX_user_book_UserId");

                entity.Property(e => e.BookId)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.UserId)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.UserBooks)
                    .HasForeignKey(d => d.BookId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBooks)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
