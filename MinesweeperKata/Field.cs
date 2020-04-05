using System;
using System.Collections.Generic;

namespace MinesweeperKata
{
    public class Field : IField
    {
        public int NumberOfRows { get; }
        public int NumberOfCols { get; }
        private readonly CellType[,] _minesweeperField;

        public Field(int col, int row)
        {
            NumberOfRows = row;
            NumberOfCols = col;
            var rows = row;
            var cols = col;
            _minesweeperField = new CellType[rows, cols];
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    _minesweeperField[r, c] = CellType.Empty;
                }
            }
        }

      
        public void SetRow(int rowNumber, IEnumerable<CellType> row)
        {
            try
            {
                var item = 0;
                foreach (var c in row)
                {
                    _minesweeperField[rowNumber, item] = c;
                    item++;
                }
            }
            catch (Exception e)
            {
                throw new RowSetterException("Invalid numberOfRows Input", e);
            }
        }

        public List<CellType> GetRow(int rowNumber)
        {
            var rowList = new List<CellType>();

            try
            {
                for (var i = 0; i < NumberOfCols; i++)
                {
                    rowList.Add(_minesweeperField[rowNumber, i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
                
            
            return rowList;
        }
        
    }

    public class RowSetterException : Exception
    {
        public RowSetterException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}