
using System;

namespace MinesweeperKata
{
    public class HintFieldCalculator : IHintFieldCalculator
    {


        public CellType[,] ConvertToArray(Field inputField)
        {
            var hintField = inputField;
            var row = hintField.NumberOfRows;
            var col = hintField.NumberOfCols;

            var hintArray = new CellType[row, col];
            LineParser lineParser = new LineParser();

            //for size of row, col
            //if hintField 
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    hintArray[i, j] = hintField.GetRow(i)[j];
                }
            }

            return hintArray ;
        }
        
        //first method to calculate one field's hints from array
        public Field CalculateDistances(string[] inputArray)
        {
            throw new System.NotImplementedException();
        }

        //second method for every field
        
    }
}