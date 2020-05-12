using System.Collections.Generic;

namespace Minesweeper
{
    public class HintFieldCalculator
    {
        public CellType[,] ConvertToArray(Field readField)
        {
            var row = readField.Row;
            var col = readField.Col;
            var hintArray = new CellType[row, col];
            return hintArray;
        }

        public IEnumerable<(int, int)> FindSurroundingInBoundCells(int currentRow, int currentCol, int rows, int cols)
        {
            var inBoundCells = new List<(int, int)>();
            for (var i = currentRow - 1; i <= currentRow + 1; i++)
            {
                for (var j = currentCol - 1; j <= currentCol + 1; j++)
                {
                    if (i < 0 || i >= rows || j < 0 || j >= cols)
                    {
                    }
                    else
                    {
                        if ((i, j) != (currentRow, currentCol))
                        {
                            inBoundCells.Add((i, j));
                        }
                    }
                }
            }

            return inBoundCells;
        }
    }
}