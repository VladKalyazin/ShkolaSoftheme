using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
    public partial class BookLibrary 
    {
        public enum BookTypes
        {
            Type0,
            Type1,
            Type2,
            Type3,
            Type4,
            Type5,
        }

        private User _CurrentUser { get; set; }

        public List<User> Users { get; set; } = new List<User>();

        public List<Book> Books { get; set; } = new List<Book>();

        private Dictionary<Book, User> Logger = new Dictionary<Book, User>();

        public void Authorize()
        {
            Console.WriteLine("Library authorization (y/n).");
            string answer = Console.ReadLine();
            if (answer == "n")
                return;
            if (answer != "y")
            {
                Console.WriteLine("Incorrect answer. Try again.");
                Authorize();
                return;
            }

            Console.WriteLine("Username?");
            string userName = Console.ReadLine();
            Console.WriteLine("Password?");
            string userPassword = Console.ReadLine();

            var user = Users.Find( (u) => u.Name == userName && u.Password == userPassword);

            if (user != null)
            {
                _CurrentUser = user;
            }
            else
            {
                Console.WriteLine("Authorization error. Try again.");
                Authorize();
                return;
            }
        }

        public void Interact()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("You can use next functions:");
            Console.WriteLine("1. See library info.");
            Console.WriteLine("2. Search book.");
            Console.WriteLine("3. See most popular book by type.");
            if (_CurrentUser != null)
            {
                Console.WriteLine("4. Get book.");
                Console.WriteLine("5. Add/return book.");
            }
            Console.WriteLine("Print \"exit\" to finish.");

            string answer = Console.ReadLine();
            if (answer == "exit")
            {
                IFormatter formatter = new BinaryFormatter();
                Serialize(formatter);
                return;
            }
            if (answer == "1")
            {
                //GetLibraryInfo();
                GetLibraryInfo_LINQ();
                Interact();
                return;
            }
            if (answer == "2")
            {
                Console.WriteLine("Book name?");
                string bookName = Console.ReadLine();
                Console.WriteLine("Author name?");
                string authorName = Console.ReadLine();
                FindBooks(bookName, authorName);
                FindBooks_LINQ(bookName, authorName);
                Interact();
                return;
            }
            if (answer == "3")
            {
                foreach (var bookType in Enum.GetValues(typeof(BookTypes)))
                {
                    GetPopularBookInfo((BookTypes)bookType);
                }
            }
            if (_CurrentUser != null)
            {
                if (answer == "4")
                {
                    Console.WriteLine("Enter book name:");
                    string bookName = Console.ReadLine();
                    var book = Books.Find((b) => b.BookName == bookName);
                    if (book != null)
                        _CurrentUser.AddBook(book);
                    else
                        Console.WriteLine("Invalid book name.");
                    Interact();
                    return;
                }
                if (answer == "5")
                {
                    Console.WriteLine("Enter book name:");
                    string bookName = Console.ReadLine();
                    var book = _CurrentUser.Books.Find((b) => b.BookName == bookName);
                    if (book != null)
                        _CurrentUser.ReturnBook(book);
                    else
                        Console.WriteLine("Invalid book name.");
                    Interact();
                    return;
                }
            }

            Console.WriteLine("Error. Try again.");
            Interact();
        }

        private void GetLibraryInfo()
        {
            Dictionary<BookTypes, int> CountOfBooks = new Dictionary<BookTypes, int>();
            Book LatestBook = null, OldestBook = null, PopularBook = null;
            foreach (var book in Books)
            {
                if (!CountOfBooks.ContainsKey(book.BookType))
                    CountOfBooks.Add(book.BookType, 0);
                CountOfBooks[book.BookType]++;

                if (LatestBook == null)
                    LatestBook = book;
                if (OldestBook == null)
                    OldestBook = book;
                if (LatestBook.DateOfCreating < book.DateOfCreating)
                    LatestBook = book;
                if (OldestBook.DateOfCreating > book.DateOfCreating)
                    OldestBook = book;

                if (PopularBook == null)
                    PopularBook = book;
                if (PopularBook.IndexOfPopularity < book.IndexOfPopularity)
                    PopularBook = book;
            }

            foreach (var CountOfBookInfo in CountOfBooks)
            {
                Console.WriteLine($"{CountOfBookInfo.Key.ToString("g")}:".PadRight(20) + CountOfBookInfo.Value.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Latest book:");
            Console.WriteLine(LatestBook.ToString());
            Console.WriteLine();
            Console.WriteLine("Oldest book:");
            Console.WriteLine(OldestBook.ToString());
            Console.WriteLine();
            Console.WriteLine("Popular book:");
            Console.WriteLine(PopularBook.ToString());
        }

        private void FindBooks(string bookName, string authorName)
        {
            if (bookName == null)
                bookName = "";
            if (authorName == null)
                authorName = "";
            foreach (var book in Books)
            {
                if (book.BookName.Contains(bookName) && book.AuthorName.Contains(authorName))
                {
                    Console.WriteLine();
                    Console.WriteLine(book.ToString());
                }
            }
        }

        private void GetPopularBookInfo(BookTypes bookType)
        {
            Book PopularBook;
            var popularBooks = Books.Where((bookT) => bookT.BookType == bookType)?.
                                     Where((book) => book.IndexOfPopularity == Books.Max((b) => b.IndexOfPopularity));
            if (popularBooks.Count() > 0)
                PopularBook = popularBooks.First();
            else
                return;

            if (PopularBook != null)
            {
                Console.WriteLine();
                Console.WriteLine(("Type:" + bookType.ToString("g")).PadLeft(20));
                Console.WriteLine(PopularBook.ToString());
            }
        }

        private void GetBookToUser(Book book)
        {
            _CurrentUser.AddBook(book);
        }

        private void GetBookFromUser(Book book)
        {
            _CurrentUser.ReturnBook(book);
            if (!Books.Contains(book))
                Books.Add(book);
            if (!Logger.ContainsKey(book))
                Logger.Add(book, _CurrentUser);
            else
                Logger[book] = _CurrentUser;
        }

    }
}
