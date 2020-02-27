using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task2
{
    public class FileSystemVisitor
    {
        public FileSystemVisitor(){}

        FileSystemVisitor(object filter) { }
        public delegate void FileHandler(string message);
        public event FileHandler Notify;
        public delegate string ActionHandler();
        public event ActionHandler Act;
        private List<string> files = new List<string>();

        public void GetFiles(string path)
        {
            var filesInDir = Directory.GetFiles(path);
            var subDirs = Directory.GetDirectories(path);
            Notify += DisplayMessage;
            Act += ReadMessage;
            if (filesInDir != null)
            {
                foreach (var item in filesInDir)
                {
                    Notify?.Invoke($"File {item} found");
                    files.Add(item);
                    //var action = Act?.Invoke();
                    //switch (action)
                    //{
                    //    case "*":
                    //        break;
                    //    case "$":
                    //        continue;
                    //}
                }
            }
            if (subDirs != null)
            {
                foreach (var subDir in subDirs)
                {
                    Notify?.Invoke($"Directory {subDir} found");
                    GetFiles(subDir);
                }
            }
        }

        public void ShowFiles()
        {
            foreach (var file in new FileIterator(files))
            {
                Console.WriteLine(file);
            }
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static string ReadMessage()
        {
            return Console.ReadLine();
        }
    }
}
