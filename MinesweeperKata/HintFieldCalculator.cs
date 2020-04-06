
using System;
using System.Linq;

namespace MinesweeperKata
{
    public class HintFieldCalculator : IHintFieldCalculator
    {
       
        
        public CellType[,] ConvertToArray(Field inputField)
        {
            var row = inputField.NumberOfRows;
            var col = inputField.NumberOfCols;

            var hintArray = new CellType[row, col];
            LineParser lineParser = new LineParser();

            //for size of row, col
            //if hintField 
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    hintArray[i, j] = inputField.GetRow(i)[j];
                }
            }

            return hintArray;
        }
        
        //first method to calculate one field's hints from array
        public string[,] CalculateNumberOfSurroundingMines(CellType[,] inputArray, Field inputField)
        {
            var calculatedArray = new string[inputField.NumberOfRows,inputField.NumberOfCols];
            
            for (var i = 0; i < inputField.NumberOfRows; i++)
            {
                for (var j = 0; j < inputField.NumberOfCols; j++)
                {
                    
                    if (inputArray[i, j] == CellType.Mine)
                    {
                        calculatedArray[i, j] = "*";
                    }
                }
            }

            return calculatedArray;

        }

        //second method for every field
        
    }
}