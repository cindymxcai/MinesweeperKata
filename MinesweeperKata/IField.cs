using System.Collections.Generic;

namespace MinesweeperKata
{
    public interface IField
    {
        void SetRow(int rowNumber, IEnumerable<CellType> row);
        List<CellType> GetRow(int rowNumber);
    }
}