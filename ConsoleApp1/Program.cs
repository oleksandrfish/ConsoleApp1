using System;
using System.Linq;
using db_controller;
using db_controller.DAL;
using db_controller.Models;

namespace LibraryApp
{
    class Program
    {
        static void Main()
        {
            using (var context = new ApplicationDbContext())
            {
                var bookRepository = new BookRepository(context);
                var saleRepository = new SaleRepository(context);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Книжкова бібліотека");
                    Console.WriteLine("1. Додати книгу");
                    Console.WriteLine("2. Оновити книгу");
                    Console.WriteLine("3. Видалити книгу");
                    Console.WriteLine("4. Пошук книг");
                    Console.WriteLine("5. Показати всі книги");
                    Console.WriteLine("6. Записати продаж");
                    Console.WriteLine("7. Вийти");
                    Console.Write("Оберіть опцію: ");

                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            AddBook(bookRepository);
                            break;
                        case "2":
                            UpdateBook(bookRepository);
                            break;
                        case "3":
                            DeleteBook(bookRepository);
                            break;
                        case "4":
                            SearchBooks(bookRepository);
                            break;
                        case "5":
                            ShowAllBooks(bookRepository);
                            break;
                        case "6":
                            RecordSale(bookRepository, saleRepository);
                            break;
                        case "7":
                            return;
                        default:
                            Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                            break;
                    }
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                    Console.ReadKey();
                }
            }
        }

        static void AddBook(BookRepository bookRepository)
        {
            Console.Write("Введіть назву книги: ");
            string title = Console.ReadLine();
            Console.Write("Введіть автора: ");
            string author = Console.ReadLine();
            Console.Write("Введіть жанр: ");
            string genre = Console.ReadLine();
            Console.Write("Введіть ціну: ");
            decimal price = decimal.Parse(Console.ReadLine());

            var book = new Book { Title = title, Author = author, Genre = genre, Price = price, CreatedAt = DateTime.Now };
            bookRepository.AddBook(book);
            Console.WriteLine("Книга додана успішно!");
        }

        static void UpdateBook(BookRepository bookRepository)
        {
            Console.Write("Введіть ID книги для оновлення: ");
            int id = int.Parse(Console.ReadLine());
            var book = bookRepository.GetAllBooks().FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                Console.WriteLine("Книгу не знайдено!");
                return;
            }
            Console.Write("Введіть нову назву книги: ");
            book.Title = Console.ReadLine();
            bookRepository.UpdateBook(book);
            Console.WriteLine("Книга оновлена успішно!");
        }

        static void DeleteBook(BookRepository bookRepository)
        {
            Console.Write("Введіть ID книги для видалення: ");
            int id = int.Parse(Console.ReadLine());
            bookRepository.DeleteBook(id);
            Console.WriteLine("Книга видалена успішно!");
        }

        static void SearchBooks(BookRepository bookRepository)
        {
            Console.Write("Введіть пошуковий запит: ");
            string searchTerm = Console.ReadLine();
            var books = bookRepository.SearchBooks(searchTerm);
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Назва: {book.Title}, Автор: {book.Author}, Ціна: {book.Price}");
            }
        }

        static void ShowAllBooks(BookRepository bookRepository)
        {
            var books = bookRepository.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Назва: {book.Title}, Автор: {book.Author}, Ціна: {book.Price}");
            }
        }

        static void RecordSale(BookRepository bookRepository, SaleRepository saleRepository)
        {
            Console.Write("Введіть ID книги, яку продано: ");
            int bookId = int.Parse(Console.ReadLine());
            var book = bookRepository.GetAllBooks().FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                Console.WriteLine("Книгу не знайдено!");
                return;
            }
            var sale = new Sale { BookId = book.Id, SaleDate = DateTime.Now, SalePrice = book.Price };
            saleRepository.RecordSale(sale);
            Console.WriteLine("Продаж записано успішно!");
        }
    }
}
