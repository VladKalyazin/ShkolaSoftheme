﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class Book
    {
        [Required(ErrorMessage = "Book name doesn't specified.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Wrong name length")]
        public string BookName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Wrong name length")]
        public string AuthorName { get; set; }

        [Required]
        public BookLibrary.BookTypes BookType { get; set; }

        [Required]
        public DateTime DateOfCreating { get; set; }

        [Required]
        public int PageCount { get; set; }

        [Required]
        public int IndexOfPopularity { get; set; }

        public override string ToString() =>
            String.Format("Name: {0}\nAuthor: {1}\nType: {2}\nDate: {3}\nPage count: {4}\nPopularity: {5}",
                            BookName, AuthorName, BookType.ToString("g"), DateOfCreating.ToString("dd.MM.yyyy"),PageCount, IndexOfPopularity);

        public Book()
        {

        }

        public Book(string name, string author, BookLibrary.BookTypes type, DateTime date, int pages, int popularity)
        {
            BookName = name;
            AuthorName = author;
            BookType = type;
            DateOfCreating = date;
            PageCount = pages;
            IndexOfPopularity = popularity;
        }
    }
}
