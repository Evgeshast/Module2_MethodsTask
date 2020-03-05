using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task2
{
    public class FileSystemVisitor
    {
        private List<string> files = new List<string>();
        private Func<string, bool> _filter;

        public event FileHandler Notify;
        public event ActionHandler Act;

        public delegate string ActionHandler();
        public delegate void FileHandler(string message);

        public FileSystemVisitor() {}

        public FileSystemVisitor(Func<string, bool> filter)
        {
            Notify += DisplayMessage;
            Act += ReadMessage;
            _filter = filter;
        }

        public IEnumerable<string> GetFiles(string path)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(path))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        files.Add(f);
                        Notify?.Invoke($"File {f} found");
                        var action = Act?.Invoke();
                        switch (action)
                        {
                            case "*":
                                return files;
                            case "$":
                                continue;
                            default:
                                continue;
                        }
                    } 
                    GetFiles(d);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return files;
        }

        public void ShowFiles()
        {
            foreach (var file in new FileIterator(files.Where(_filter).ToList()))
            {
                Console.WriteLine(file);
            }
        }

        private void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        private string ReadMessage()
        {
            return Console.ReadLine();
        }
    }
}
