using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public List<Book> Books { get; private set; } = new List<Book>();

        public User() : this("", "")
        {

        }

        public User(string name, string pass)
        {
            Name = name;
            Password = pass;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            book.IndexOfPopularity++;
        }

        public void ReturnBook(Book book)
        {
            Books.Remove(book);
        }

    }
}
