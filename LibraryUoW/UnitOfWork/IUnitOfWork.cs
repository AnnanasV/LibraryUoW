using LibraryUoW.Models;
using LibraryUoW.Repositories;

namespace LibraryUoW.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Book> Books { get; }
        IRepository<Author> Authors { get; }
        IRepository<Genre> Genres { get; }
        void Commit();
    }
}
