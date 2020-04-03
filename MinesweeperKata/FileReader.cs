using System;
using System.IO;

namespace MinesweeperKata
{
    public class FileReader : IFileReader
    {
        public string[] ReadFile(string fileName)
        {
            var readValues = File.ReadAllLines(fileName);
            
            foreach (var line in readValues)
            {
                Console.WriteLine(line);
                
            }
            return readValues;

        }
    }
}