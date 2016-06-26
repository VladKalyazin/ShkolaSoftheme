using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace HomeWork25
{
    public static class TaskArchiver
    {
        public static void Archive(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                if (file.Extension != ".zip")
                {
                    Task.Factory.StartNew(() =>
                    {
                        string archiveName = file.DirectoryName + '\\' + file.Name.Replace(file.Extension, file.Extension.Replace('.', '_')) + ".zip";
                        using (ZipArchive archiver = ZipFile.Open(archiveName, ZipArchiveMode.Create))
                        {
                            Console.WriteLine($"Start achiving file \"{file.FullName}\"");
                            archiver.CreateEntryFromFile(file.FullName, file.Name);
                            //archiver.ExtractToDirectory(file.DirectoryName);
                            Console.WriteLine($"End achiving file \"{file.FullName}\"");
                        }
                    });
                }
            }

            foreach (var subDir in dir.GetDirectories())
            {
                Archive(subDir.FullName);
            }

        }

        public static void Extract(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                if (file.Extension == ".zip")
                {
                    Task.Factory.StartNew(() =>
                    {
                        using (ZipArchive archiver = ZipFile.Open(file.FullName, ZipArchiveMode.Read))
                        {
                            Console.WriteLine($"Start extracting file \"{file.FullName}\"");
                            archiver.ExtractToDirectory(file.DirectoryName);
                            Console.WriteLine($"End extracting file \"{file.FullName}\"");
                        }
                    });
                }
            }

            foreach (var subDir in dir.GetDirectories())
            {
                Extract(subDir.FullName);
            }

        }

    }

}
