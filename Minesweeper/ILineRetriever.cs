using System;

namespace Minesweeper
{
    public interface ILineRetriever
    {
        string GetNextLine();
    }

    public class LineRetriever : ILineRetriever
    {
        private readonly string[] _input;
        private int _index; 

        public LineRetriever(string[] input)
        {
            _input = input ?? throw new ArgumentException("Null argument passed to line retriever constructor!", nameof(input));
        }
        public string GetNextLine()
        {
            var line = _input[_index];
            _index++;
            return line;
        }
    }
    
}