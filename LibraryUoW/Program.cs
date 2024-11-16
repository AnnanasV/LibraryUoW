using LibraryUoW.Migrations;
using LibraryUoW.Models;
using LibraryUoW.Services;

namespace LibraryUoW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new BooksContext();
            var unitOfWork = new UnitOfWork.UnitOfWork(context);
            var libraryService = new LibraryService(unitOfWork);

            InitialDBService.Seed(unitOfWork);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n1. Add Book\n2. Update Book\n3. Delete Book\n4. List Books by Genre\n5. List Books by Author\n6. List all books\n0. Exit");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter title: ");
                        var title = Console.ReadLine();
                        Console.Write("Enter author ID: ");
                        var authorId = int.Parse(Console.ReadLine());
                        Console.Write("Enter genre ID: ");
                        var genreId = int.Parse(Console.ReadLine());
                        Console.Write("Enter published year: ");
                        var year = int.Parse(Console.ReadLine());
                        libraryService.AddBook(title, authorId, genreId, year);
                        break;

                    case "2":
                        Console.Write("Enter book ID to update: ");
                        var bookId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new title: ");
                        title = Console.ReadLine();
                        Console.Write("Enter new author ID: ");
                        authorId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new genre ID: ");
                        genreId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new published year: ");
                        year = int.Parse(Console.ReadLine());
                        libraryService.UpdateBook(bookId, title, authorId, genreId, year);
                        break;

                    case "3":
                        Console.Write("Enter book ID to delete: ");
                        bookId = int.Parse(Console.ReadLine());
                        libraryService.DeleteBook(bookId);
                        break;

                    case "4":
                        Console.Write("Enter genre ID: ");
                        genreId = int.Parse(Console.ReadLine());
                        foreach (var book in libraryService.GetBooksByGenre(genreId))
                        {
                            Console.WriteLine($"{book.Id}. {book.Title} - {book.Author.Name}");
                        }
                        break;

                    case "5":
                        Console.Write("Enter author ID: ");
                        authorId = int.Parse(Console.ReadLine());
                        foreach (var book in libraryService.GetBooksByAuthor(authorId))
                        {
                            Console.WriteLine($"{book.Id}. {book.Title} - {book.Author.Name}");
                        }
                        break;

                    case "6":
                        foreach (var book in libraryService.GetBooks())
                        {
                            Console.WriteLine($"{book.Id}. {book.Title} - {book.Author.Name}");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}