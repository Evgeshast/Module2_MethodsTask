using System;
using System.Linq.Expressions;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input directory path");
            string path = Console.ReadLine();
            string filter = Console.ReadLine();
            if (string.IsNullOrEmpty(path))
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            FileSystemVisitor visitor = new FileSystemVisitor(file => file.EndsWith(filter));
            visitor.GetFilesAndFolders(path);
            visitor.ShowFiles();
        }
    }
}
