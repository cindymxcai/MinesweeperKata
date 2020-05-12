using System;
using System.Collections.Generic;

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
            catch
            {
                throw new InvalidInputException("Invalid input for Size!");
            }
        }

        public List<CellType> GetFieldRow(string input)
        {
            var cellList = new List<CellType>();
            
            foreach (var cell in input)
            {
                switch (cell)
                {
                    case '*':
                        cellList.Add(CellType.Mine);
                        break;
                    case '.':
                        cellList.Add(CellType.Empty);
                        break;
                }
            }
            return cellList;
        }        
    }
}