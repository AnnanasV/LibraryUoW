using LibraryUoW.Models;
using LibraryUoW.Repositories;

namespace LibraryUoW.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BooksContext _context;

        public IRepository<Book> Books { get; }
        public IRepository<Author> Authors { get; }
        public IRepository<Genre> Genres { get; }

        public UnitOfWork(BooksContext context)
        {
            _context = context;
            Books = new Repository<Book>(_context);
            Authors = new Repository<Author>(_context);
            Genres = new Repository<Genre>(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
