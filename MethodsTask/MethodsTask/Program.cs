using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input directory path");
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); //Console.ReadLine();
            if (path == "")
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            FileSystemVisitor visitor = new FileSystemVisitor();
            visitor.GetFiles(path);
            visitor.ShowFiles();
        }
    }
}
