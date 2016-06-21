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
            var Timer = new Stopwatch();
            double TimeForAlgorithm;


            BookLibrary BookLib = new BookLibrary();

            IFormatter formatter = new BinaryFormatter();
            Timer.Restart();
            BookLib.Serialize(formatter);
            Timer.Stop();
            TimeForAlgorithm = Timer.Elapsed.TotalMilliseconds;
            Console.WriteLine("Time for binary serialization (in ms):");
            Console.WriteLine(TimeForAlgorithm);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookLibrary));
            Timer.Restart();
            using (StreamWriter streamWriter = File.CreateText("BookLib.xml"))
            {
                xmlSerializer.Serialize(streamWriter, BookLib);
            }
            Timer.Stop();
            TimeForAlgorithm = Timer.Elapsed.TotalMilliseconds;
            Console.WriteLine("Time for xml serialization (in ms):");
            Console.WriteLine(TimeForAlgorithm);

            BookLib.Authorize();
            BookLib.Interact();
        }
    }
}
