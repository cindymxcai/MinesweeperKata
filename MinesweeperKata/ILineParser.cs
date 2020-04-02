using System.Collections.Generic;

namespace MinesweeperKata
{
    public interface ILineParser
    {
        (int,int) GetSize(string sizeLine);
        List<CellType> GetFieldRow(string fieldLine);
    }
}