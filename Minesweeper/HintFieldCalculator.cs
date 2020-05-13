using System.Collections.Generic;

namespace Minesweeper
{
    public class HintFieldCalculator
    {
        
        public List<string[,]> AllFieldsHints { get; }

        public HintFieldCalculator()
        {
            AllFieldsHints = new List<string[,]>();
        }
        
        

        public static CellType[,] ConvertToArray(Field readField)
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

        public static IEnumerable<(int, int)> FindSurroundingInBoundCells(int currentRow, int currentCol, int rows, int cols)
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

        public static string[,] CalculateHints(Field inputField, CellType[,] inputArray)
        {
            var hintArray = new string[inputField.Row, inputField.Col];
            
            for (var currentRow = 0; currentRow < inputField.Row; currentRow++)
            {
                for (var currentCol = 0; currentCol < inputField.Col; currentCol++)
                {

                    if (inputArray[currentRow, currentCol] == CellType.Empty)
                    {
                        var counter = 0;
                        var inBoundCells = FindSurroundingInBoundCells(currentRow, currentCol, inputField.Row, inputField.Col);
                        foreach (var (x, y) in inBoundCells)
                        {
                            if (inputArray[x, y] == CellType.Mine)
                            {
                                counter++;
                            }

                        }
                        
                        hintArray[currentRow, currentCol] = counter.ToString();
                    }
                    else
                    {
                        hintArray[currentRow, currentCol] = "*";
                    }
                }
            }

            return hintArray;
        }

        public void CalculateAllFieldsHints(List<Field> fields)
        {
            foreach (var field in fields)
            {
                var calculatedArray = CalculateHints(field, ConvertToArray(field));
                AllFieldsHints.Add(calculatedArray);
            }        
        }

    }
}