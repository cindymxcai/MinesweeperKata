using System;
using System.Collections.Generic;

namespace MinesweeperKata
{
    public class Field : IField
    {
        private readonly int _cols;
        private readonly CellType[,] _minesweeperField;

        public Field(int col, int row)
        {
            _cols = col;
            var rows = row;
            _minesweeperField = new CellType[rows, _cols];
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < _cols; c++)
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
                throw new RowSetterException("Invalid Row Input", e);
            }
        }

        public List<CellType> GetRow(int rowNumber)
        {
            var rowList = new List<CellType>();

            try
            {
                for (var i = 0; i < _cols; i++)
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