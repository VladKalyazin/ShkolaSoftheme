using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandle
{
    [Flags]
    public enum FileAccessEnum
    {
        None = 0x00,
        Read = 0x01,
        Write = 0x02
    }

    public struct FileHandle
    {
        public int FileSize { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public FileAccessEnum FileAccess { get; set; }
    }

    public static class OpenFile
    {
        public static FileHandle ForRead(string filename)
        {
            FileHandle fh = ParseFileName(filename);
            fh.FileAccess = FileAccessEnum.Read;
            return fh;
        }

        public static FileHandle ForWrite(string filename)
        {
            FileHandle fh = ParseFileName(filename);
            fh.FileAccess = FileAccessEnum.Write;
            return fh;
        }

        public static FileHandle SetAccess(string filename, FileAccessEnum access)
        {
            FileHandle fh = ParseFileName(filename);
            fh.FileAccess = access;
            return fh;
        }

        private static FileHandle ParseFileName(string filename)
        {
            FileHandle fh = new FileHandle();
            fh.FileSize = 0;
            fh.FileName = filename.Substring(filename.LastIndexOf("\\") + 1);
            fh.FilePath = filename.Substring(0, filename.LastIndexOf("\\") + 1);
            fh.FileAccess = FileAccessEnum.None;

            return fh;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var handle = OpenFile.SetAccess("\\123.txt", FileAccessEnum.Write | FileAccessEnum.Read);
            Console.WriteLine(handle.FileAccess);

            Console.ReadKey();
        }
    }
}
