using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;


namespace Library
{
    public partial class BookLibrary
    {
        public void XmlSerialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookLibrary));
            using (StreamWriter streamWriter = File.CreateText("BookLib.xml"))
            {
                xmlSerializer.Serialize(streamWriter, this);
            }
        }

        public void XmlDeserialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookLibrary));
            using (var streamReader = File.Open("BookLib.xml", FileMode.Open))
            {
                var lib = xmlSerializer.Deserialize(streamReader) as BookLibrary;
                this.Books = lib.Books;
                this.Users = lib.Users;
            }
        }

        public void GetLibraryInfo_XML()
        {
            XDocument doc = XDocument.Load("BookLib.xml");

            foreach (var objectType in Enum.GetValues(typeof(BookTypes)))
            {
                var bookType = (BookTypes)objectType;
                var count = doc.Descendants("Book").Where(b => b.Elements("BookType").Any(n => (string)n == bookType.ToString())).Count();
                if (count > 0)
                    Console.WriteLine($"{bookType.ToString("g")}:".PadRight(20) + count.ToString());
            }

            Console.ReadLine();
        }

        public void FindBooks_XML(string bookName, string authorName)
        {
            if (bookName == null)
                bookName = "";
            if (authorName == null)
                authorName = "";

            XDocument doc = XDocument.Load("BookLib.xml");

            var filteredBooks = doc.Descendants("Book").Where(b => b.Elements("BookName").Any(n => n.ToString().Contains(bookName)) &&
                                                                   b.Elements("AuthorName").Any(n => n.ToString().Contains(authorName)));

            foreach (var book in filteredBooks)
            {
                Console.WriteLine();
                Console.WriteLine(book.ToString());

            }
        }


    }

}