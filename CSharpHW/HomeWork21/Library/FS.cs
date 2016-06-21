using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Compression;

namespace Library
{
    public partial class BookLibrary
    {
        private const string DataFileName = "BooksInfo.dat";
        private const string ZipFileName = "BooksInfo.zip";

        public BookLibrary()
        {
            IFormatter formatter = new BinaryFormatter();
            Deserialize(formatter);
        }

        public void Compress()
        {
            IFormatter formatter = new BinaryFormatter();
            Serialize(formatter);
            var archive = ZipFile.Open(ZipFileName, ZipArchiveMode.Create);
            archive.CreateEntryFromFile(DataFileName, "data");
            archive.Dispose();
        }

        public void Decompress()
        {
            var archive = ZipFile.Open(ZipFileName, ZipArchiveMode.Read);
            archive.Entries.First().ExtractToFile(DataFileName, true);
            IFormatter formatter = new BinaryFormatter();
            Deserialize(formatter);
        }
    }

}