using System;
using System.Collections.Generic;

namespace mybookapp
{
    /// <summary>
    /// manages the book inventory and operations
    /// </summary>
    public class Bookmanagerservice
    {
        private List<Book> books;

        /// <summary>
        /// constructor that adds a couple of books for testing
        /// </summary>
        public Bookmanagerservice()
        {
            books = new List<Book>();
            // add some test books
            books.Add(new Book { id = "1", title = "le petit prince", author = "french dude", genre = "adventure" });
            books.Add(new Book { id = "2", title = "the road", author = "cormac mccarthy", genre = "horror" });
        }

        /// <summary>
        /// starts the service and runs the menu loop
        /// </summary>
        public void start()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("\nwelcome to the book system");
                Console.WriteLine("1: display books");
                Console.WriteLine("2: display book by id");
                Console.WriteLine("3: add new book");
                Console.WriteLine("4: remove book by id");
                Console.WriteLine("5: exit");
                Console.Write("your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        displayBooks();
                        break;
                    case "2":
                        displayBookById();
                        break;
                    case "3":
                        addBook();
                        break;
                    case "4":
                        removeBook();
                        break;
                    case "5":
                        keepGoing = false;
                        Console.WriteLine("bye");
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            }
        }

        private void displayBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("no books in the system");
                return;
            }
            foreach (var b in books)
            {
                Console.WriteLine("id: " + b.id);
                Console.WriteLine("title: " + b.title);
                Console.WriteLine("author: " + b.author);
                Console.WriteLine("genre: " + b.genre);
                Console.WriteLine("-----");
            }
        }

        private void displayBookById()
        {
            Console.Write("enter book id: ");
            string id = Console.ReadLine();
            var b = books.Find(x => x.id == id);
            if (b != null)
            {
                Console.WriteLine("id: " + b.id);
                Console.WriteLine("title: " + b.title);
                Console.WriteLine("author: " + b.author);
                Console.WriteLine("genre: " + b.genre);
            }
            else
            {
                Console.WriteLine("book not found");
            }
        }

        private void addBook()
        {
            Console.Write("enter title: ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("invalid title");
                return;
            }
            Console.Write("enter author: ");
            string author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("invalid author");
                return;
            }
            Console.Write("enter genre: ");
            string genre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(genre))
            {
                Console.WriteLine("invalid genre");
                return;
            }
            Console.Write("enter id: ");
            string id = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(id) || books.Exists(x => x.id == id))
            {
                Console.WriteLine("invalid or duplicate id");
                return;
            }
            books.Add(new Book { id = id, title = title, author = author, genre = genre });
            Console.WriteLine("book added");
        }

        private void removeBook()
        {
            Console.Write("enter id to remove: ");
            string id = Console.ReadLine();
            var b = books.Find(x => x.id == id);
            if (b != null)
            {
                books.Remove(b);
                Console.WriteLine("book removed");
            }
            else
            {
                Console.WriteLine("book not found");
            }
        }
    }
}
