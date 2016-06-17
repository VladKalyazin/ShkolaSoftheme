using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public partial class BookLibrary
    {
        private void GetLibraryInfo_LINQ()
        {
            foreach (var objectType in Enum.GetValues(typeof(BookTypes)))
            {
                var bookType = (BookTypes)objectType;
                var count = (from book in Books
                             where book.BookType == bookType
                             select book).Count();
                if (count > 0)
                    Console.WriteLine($"{bookType.ToString("g")}:".PadRight(20) + count.ToString());
            }

            var LatestBook = Books.Find((book) => book.DateOfCreating == Books.Max((b) => b.DateOfCreating));
            var OldestBook = Books.Find((book) => book.DateOfCreating == Books.Min((b) => b.DateOfCreating));
            var PopularBook = Books.Find((book) => book.IndexOfPopularity == Books.Max((b) => b.IndexOfPopularity));

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

        private void FindBooks_LINQ(string bookName, string authorName)
        {
            if (bookName == null)
                bookName = "";
            if (authorName == null)
                authorName = "";

            var filteredBooks = Books.Where((b) => b.BookName.Contains(bookName) && b.AuthorName.Contains(authorName)).ToArray();

            foreach (var book in filteredBooks)
            {
                Console.WriteLine();
                Console.WriteLine(book.ToString());

            }
        }

    }
}
