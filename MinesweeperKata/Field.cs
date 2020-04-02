using System;
using System.Collections.Generic;

namespace MinesweeperKata
{
    public class Field
    {
        private readonly int _cols;
        private readonly int _rows;
        private readonly CellType[,] _minesweeperField;

        public Field(int col, int row)
        {
            _cols = col;
            _rows = row;
            _minesweeperField = new CellType[_rows, _cols];
            for (var r = 0; r < _rows; r++)
            {
                for (var c = 0; c < _cols; c++)
                {
                    _minesweeperField[r, c] = CellType.Empty;
                }
            }
        }

        //add mines to minesweeperfield from line parser
        //getfieldrow from lineparser and set first row 
        //line parser gets next line from input
        //set rows...until x size

        //loop through file and set rows 

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
        

        /*public CellType[,] SetField(IEnumerable<CellType> rowList)
        {
            var field = new char[,]{};
            
            return field;
        }*/
    }
    
    //calculate hint field method
    

    public class RowSetterException : Exception
    {
        public RowSetterException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}