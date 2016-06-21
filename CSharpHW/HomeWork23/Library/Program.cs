using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;


namespace Library
{
    class Program
    {

        static void Main(string[] args)
        {
            BookLibrary BookLib = new BookLibrary();

            BookLib.Authorize();
            BookLib.Interact();
        }
    }
}
