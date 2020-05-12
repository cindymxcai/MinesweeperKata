using System.Collections.Generic;

namespace Minesweeper
{
    public class HintFieldCalculator
    {
        public CellType[,] ConvertToArray(Field readField)
        {
            var numberOfRows = readField.Row;
            var numberOfCols = readField.Col;
            var hintArray = new CellType[ numberOfRows, numberOfCols];
            for (var currentRow = 0; currentRow < numberOfRows; currentRow++)
            {

                for (var currentCol = 0; currentCol < numberOfCols; currentCol++)
                {
                    hintArray[currentRow, currentCol] = readField.GetRow(currentRow)[currentCol];
                }
            }
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