using System;
using ParseString;

namespace ExceptionHandlingModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input string");
            var line = Console.ReadLine();
            try
            {
                WriteFirstStringSymbol(line);
            }
            catch (EmptyStringException ex)
            {
            }
        }

        public static void WriteFirstStringSymbol(string line)
        {
            if (line == string.Empty)
            {
                throw new EmptyStringException();
            }
            else
            {
                Console.WriteLine(line[0]);
            }
        }
    }
}
