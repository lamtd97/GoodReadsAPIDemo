using DBFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Book>? Books { get; set; }
        public DbSet<User>? Users { get; set; }

        public DbSet<UserBook> UserBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBook>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.UserBooks)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<UserBook>()
              .HasOne(b => b.User)
              .WithMany(ba => ba.UserBooks)
              .HasForeignKey(bi => bi.UserId);
            base.OnModelCreating(modelBuilder);

        }
    }
}
