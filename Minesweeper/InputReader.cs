using System;
using System.IO;
using MinesweeperTest;

namespace Minesweeper
{
    public class InputReader : IInputReader
    {
        public string[] ReadFile(string fileName)
        {
            var readValues = File.ReadAllLines(fileName);
            return readValues;
        }
    }
}