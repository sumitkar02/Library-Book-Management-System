using System;
using System.Collections.Generic;
using System.Linq;
class Staff
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public Staff(string name, int age, string position)
    {
        Name = name;
        Age = age;
        Position = position;
    }
}


class Program
{
    static List<Book> books = new List<Book>();

    static void Main()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nAdd a book to the library system");
            Console.WriteLine("1. Borrow Book");
            Console.WriteLine("2. Returned Book");
            Console.WriteLine("3. Display all books");
            Console.WriteLine("4. Search book by ID");
            Console.WriteLine("5. Delete a book");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    BorrowBook();
                    break;
                case "2":
                    ReturnBook();
                    break;
                case "3":
                    ViewBooks();
                    break;
                case "4":
                    SearchBookById();
                    break;
                case "5":
                    DeleteBook();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Exiting... Bye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void BorrowBook()
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Enter Book Title: ");
        string title = Console.ReadLine() ?? "";
        books.Add(new Book { Id = id, Title = title, IsBorrowed = true });
        Console.WriteLine("Book borrowed successfully.");
    }

    static void ReturnBook()
    {
        Console.Write("Enter Book ID to return: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        var book = books.Find(b => b.Id == id && b.IsBorrowed);
        if (book != null)
        {
            book.IsBorrowed = false;
            Console.WriteLine("Book returned successfully.");
        }
        else
        {
            Console.WriteLine("Book not found or already returned.");
        }
    }

    static void ViewBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
            return;
        }
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Borrowed: {book.IsBorrowed}");
        }
    }

    static void SearchBookById()
    {
        Console.Write("Enter Book ID to search: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        var book = books.Find(b => b.Id == id);
        if (book != null)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Borrowed: {book.IsBorrowed}");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void DeleteBook()
    {
        Console.Write("Enter Book ID to delete: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        var book = books.Find(b => b.Id == id);
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine("Book deleted successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
}
    
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public bool IsBorrowed { get; set; }
    }
