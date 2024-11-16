using LibraryUoW.Models;
using LibraryUoW.UnitOfWork;

namespace LibraryUoW.Services
{
    public class LibraryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibraryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddBook(string title, int authorId, int genreId, int publishedYear)
        {
            _unitOfWork.Books.Add(new Book
            {
                Title = title,
                AuthorId = authorId,
                GenreId = genreId,
                PublishedYear = publishedYear
            });
            _unitOfWork.Commit();
        }

        public void UpdateBook(int id, string title, int authorId, int genreId, int publishedYear)
        {
            var book = _unitOfWork.Books.GetById(id);
            if (book != null)
            {
                book.Title = title;
                book.AuthorId = authorId;
                book.GenreId = genreId;
                book.PublishedYear = publishedYear;
                _unitOfWork.Books.Update(book);
                _unitOfWork.Commit();
            }
        }

        public void DeleteBook(int id)
        {
            var book = _unitOfWork.Books.GetById(id);
            if (book != null)
            {
                _unitOfWork.Books.Delete(book);
                _unitOfWork.Commit();
            }
        }

        public IEnumerable<Book> GetBooksByGenre(int genreId) =>
            _unitOfWork.Books.GetAll().Where(b => b.GenreId == genreId);

        public IEnumerable<Book> GetBooksByAuthor(int authorId) =>
            _unitOfWork.Books.GetAll().Where(b => b.AuthorId == authorId);
    }
}
