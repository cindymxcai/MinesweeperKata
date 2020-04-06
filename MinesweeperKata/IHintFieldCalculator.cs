using System;
using System.Collections.Generic;

namespace MinesweeperKata
{
    public interface IHintFieldCalculator
    {
        CellType[,] ConvertToArray(Field inputField);
        string[,] CalculateNumberOfSurroundingMines(CellType[,] inputArray, Field inputField);
        List<(int,int)> FindSurroundingInBoundCells(int currentRow, int currentCol, int rows, int cols);
    }
}