using System;
using System.Collections.Generic;

namespace MinesweeperKata
{
    public class LineParser
    {
        public (int,int) GetSize(string sizeLine)
        {
            try
            {
                var x = int.Parse(sizeLine.Substring(0, 1));
                var y = int.Parse(sizeLine.Substring(1, 1));
                return (x, y);
            }
            catch (Exception e)
            {
                throw new LineParserException("Invalid Input to get size", e);
            }
        }

        public List<CellType> GetFieldRow(string fieldLine)
        {
            var cellList = new List<CellType>();
            foreach (var c in fieldLine)
            {
                switch (c)
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

    public class LineParserException : Exception
    {
        public LineParserException(string message, Exception exception): base(message,exception)
        {
            
        }
    }
}