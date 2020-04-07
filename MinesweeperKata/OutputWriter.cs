using System;

namespace MinesweeperKata
{
    public class OutputWriter
    {
        public void WriteOutput(string[,] calculatedArray)
        {
            foreach (var value in calculatedArray)
            {
                Console.WriteLine(value);
            }
        }
    }
}