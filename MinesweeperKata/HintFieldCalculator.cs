
using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Util;

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
                    
                    if (inputArray[i, j] == CellType.Empty)
                    {
                        int counter = 0;
                        var listOfSurroundingCells = FindSurroundingInBoundCells(i, j, inputField.NumberOfRows, inputField.NumberOfCols);
                        foreach (var (item1, item2) in listOfSurroundingCells)
                        {
                            if (inputArray[item1, item2] == CellType.Mine)
                            {
                                counter++;
                            }
                        }

                        calculatedArray[i, j] = counter.ToString();
                    }
                    else
                    {
                        calculatedArray[i, j] = "*";
                    }
                }
            }

            return calculatedArray;

        }

        public List<(int,int)> FindSurroundingInBoundCells(int currentRow, int currentCol, int rows, int cols)
        {
            var validCells = new List<(int, int)>();

            for (var i = currentCol-1; i <= currentCol+1; i++)
            {
                for (var j = currentRow-1; j <= currentCol+1; j++)
                {
                    if (i < 0 || i > cols || j<0 || j > rows)
                    { 
                        Console.WriteLine("invalid");
                    }
                    else
                    {
                        if ((i, j) != (currentRow, currentCol))
                        {
                            validCells.Add((i,j));

                        }
                    }
                }
                
            }
            return validCells;
        }

        //second method for every field
        
    }
}