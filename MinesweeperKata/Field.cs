using System;
using System.Collections.Generic;

namespace MinesweeperKata
{
    public class Field
    {
        private readonly int _cols;
        private readonly int _rows;
        private CellType[,] _minesweeperField;
        private readonly LineParser _lineParser = new LineParser();

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
            
            

        public void SetRow( int rowNumber,List<CellType> row)
        {
            var item = 0;

            foreach (var c in row)
            {
                _minesweeperField[rowNumber, item] = c;
                item++;
            }
        }

        public List<CellType> GetRow(int rowNumber)
        {
            var rowList = new List<CellType>();
            for (var i = 0; i < _cols; i++)
            {
               rowList.Add(_minesweeperField[rowNumber, i]);
            }

            return rowList;
        }
    }
}
