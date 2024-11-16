using Microsoft.EntityFrameworkCore;

namespace LibraryUoW.Models
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Users\\user\\Documents\\LibraryUoW.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Author>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId);
        }
    }
}
