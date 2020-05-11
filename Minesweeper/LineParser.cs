using System;

namespace Minesweeper
{
    public class LineParser
    {
        public (int,int) GetSize(string input)
        {
            try
            {
                var x = int.Parse(input.Substring(0, 1));
                var y = int.Parse(input.Substring(1, 1));
                return (x, y);
            }
            catch (Exception)
            {
                throw new InvalidInputException("Invalid input for Size!");
            }
        }
    }
}