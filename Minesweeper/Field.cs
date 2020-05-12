using System.Collections.Generic;

namespace Minesweeper
{
    public class Field
    {
        public readonly int Row;
        public readonly int Col; 
        private CellType[,] MinesweeperField { get;  }
        
        public Field(int row, int col)
        {
            Row = row;
            Col = col;
            MinesweeperField = new CellType[row, col];
            for (var r = 0; r < row; r++)
            {
                for (var c = 0; c < col; c++)
                {
                    MinesweeperField[r, c] = CellType.Empty;
                }
            }
        }

        public void SetRow(int currentRow, IEnumerable<CellType> fieldRow)
        {
            var index = 0;
            foreach (var cell in fieldRow)
            {
                MinesweeperField[currentRow, index] = cell;
                index++;
            }
        }

        public List<CellType> GetRow(int rowNumberToGet)
        {
            var row = new List<CellType>();

            for (var currentCol = 0; currentCol < Col; currentCol++)
            {
                row.Add(MinesweeperField[rowNumberToGet, currentCol]);
            }

            return row;
        }
    }
}