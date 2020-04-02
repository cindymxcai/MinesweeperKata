using System;
using System.IO;

namespace MinesweeperKata
{
    public interface IFileReader
    {
        string[] ReadFile(string fileName);
    }

    public class FileReader : IFileReader
    {
        public string[] ReadFile(string fileName)
        {
            var readValues = File.ReadAllLines("input2.txt");
            
            foreach (var line in readValues)
            {
                Console.WriteLine(line);
                
            }
            return readValues;

        }
    }
}