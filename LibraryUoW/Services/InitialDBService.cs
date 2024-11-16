using LibraryUoW.Models;
using LibraryUoW.UnitOfWork;

namespace LibraryUoW.Services
{
    public class InitialDBService
    {
        public static void Seed(IUnitOfWork unitOfWork)
        {
            if (unitOfWork.Authors.GetAll().Any() ||
                unitOfWork.Genres.GetAll().Any() ||
                unitOfWork.Books.GetAll().Any())
                return;

            var genres = new[]
            {
                new Genre { Name = "Science Fiction" },
                new Genre { Name = "Fantasy" },
                new Genre { Name = "Mystery" }
            };

            foreach (var genre in genres)
            {
                unitOfWork.Genres.Add(genre);
            }

            var authors = new[]
            {
                new Author { Name = "Isaac Asimov", DateOfBirth = new DateTime(1920, 1, 2) },
                new Author { Name = "J.K. Rowling", DateOfBirth = new DateTime(1965, 7, 31) },
                new Author { Name = "Agatha Christie", DateOfBirth = new DateTime(1890, 9, 15) }
            };

            foreach (var author in authors)
            {
                unitOfWork.Authors.Add(author);
            }

            var books = new[]
            {
                new Book { Title = "Foundation", Author = authors[0], Genre = genres[0], PublishedYear = 1951 },
                new Book { Title = "Harry Potter and the Philosopher's Stone", Author = authors[1], Genre = genres[1], PublishedYear = 1997 },
                new Book { Title = "Murder on the Orient Express", Author = authors[2], Genre = genres[2], PublishedYear = 1934 }
            };

            foreach (var book in books)
            {
                unitOfWork.Books.Add(book);
            }

            unitOfWork.Commit();

            Console.WriteLine("Initial data are successfully added to the database.");
        }
    }
}
