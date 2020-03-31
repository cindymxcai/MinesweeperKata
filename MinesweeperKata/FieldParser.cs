using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MinesweeperKata
{
    public class FieldParser
    {
        private readonly StreamReader _streamReader;
        private readonly int _rows;
        private readonly int _cols;
        private readonly string _inputString = "";
        private readonly char[,] _inputField;


        public FieldParser(StreamReader streamReader)
        {
            _streamReader = streamReader;
            _rows = streamReader.Read();
            _cols = streamReader.Read();
            while (streamReader.Peek() >= 0)
            {
                _inputString += streamReader.ReadLine() + "\n";
            }

            _inputString.Trim();
            _inputField = new char[_rows, _cols];


        }

        public int GetRows()
        {
            return _rows - 48;
        }

        public int GetCols()
        {
            return _cols - 48;
        }


        public void CreateInputField()
        {
            StreamReader streamReader = new StreamReader("input.txt");
            streamReader.ReadLine();

            for(var row = 0;  streamReader.Peek() != -1; row++ )
            {
                var rowInput = streamReader.ReadLine() ;

               for(var col = 0; streamReader.Peek() != -1; col++)
               {
                   _inputField[row-48, col-48] =  rowInput[col];

                   foreach (var item in _inputField)
                   {
                       Console.Write(item);
                   }

               }
            }
            streamReader.Close();
        }

        public string GetInputField()
        {
            var strInputGrid = "";
            
            for (var row = 0; row < _rows-48; row++)
            {
                for (var col = 0; col < _cols-48; col++)
                {
                    //strInputGrid += ".";
                    strInputGrid += _inputField[row, col];
                }

                strInputGrid += "\n";
            }

            strInputGrid.Trim();
            return strInputGrid;
        }
    }
}