namespace MinesweeperKata
{
    public interface IFileReader
    {
        string[] ReadFile(string fileName);
    }

    public class FileReader : IFileReader
    {
        //read fields until 00

        public string[] ReadFile(string fileName)
        {
            var readValues = new string[] { };

            return null;

        }
    }
}