using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {

        static void Main(string[] args)
        {
            BookLibrary BookLib = new BookLibrary();
            BookLib.Users.Add(new User("login", "123"));
            BookLib.Books.Add(new Book("name0", "aut0", BookLibrary.BookTypes.Type1, DateTime.Now, 100, 5));
            BookLib.Books.Add(new Book("name1", "aut1", BookLibrary.BookTypes.Type2, DateTime.Now.AddYears(-1), 100, 1));
            BookLib.Books.Add(new Book("name2", "aut1", BookLibrary.BookTypes.Type3, DateTime.Now.AddYears(-2), 100, 2));
            BookLib.Books.Add(new Book("name3", "aut1", BookLibrary.BookTypes.Type1, DateTime.Now.AddYears(-3), 100, 3));
            BookLib.Books.Add(new Book("name4", "aut1", BookLibrary.BookTypes.Type2, DateTime.Now.AddYears(-4), 100, 10));
            BookLib.Books.Add(new Book("name5", "aut1", BookLibrary.BookTypes.Type1, DateTime.Now.AddYears(-5), 100, 5));
            BookLib.Books.Add(new Book("name6", "aut1", BookLibrary.BookTypes.Type1, DateTime.Now.AddYears(-6), 100, 5));

            BookLib.Authorize();
            BookLib.Interact();
        }
    }
}
