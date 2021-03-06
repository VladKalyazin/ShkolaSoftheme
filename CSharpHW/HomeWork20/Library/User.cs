﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Library
{
    public class User
    {
        [Required(ErrorMessage = "User name doesn't specified.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Wrong name length")]
        public string Name { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Wrong name length")]
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
