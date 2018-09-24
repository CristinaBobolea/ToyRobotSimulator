using System;
using System.IO;
using System.Linq;

namespace ToyRobotSimulator.nsHandlers
{
    // FileHandler class is used to read/write a line from/to a file
    public class FileHandler
    {
        private int _lineIndex = 0;
        private string _inputFileName;
        private const string _outputFileName = "output.txt";

        public FileHandler(string fileName)
        {
            _inputFileName = fileName;
        }

        public string ReadLineFromFile(out bool isFileFinished)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _inputFileName);

            string text = File.ReadLines(path).Skip(_lineIndex).First();
            PrintToFile(text);

            _lineIndex++;
            isFileFinished = false;

            try
            {
                File.ReadLines(path).Skip(_lineIndex).First();
            }
            catch (InvalidOperationException e)
            {
                isFileFinished = true;
            }

            return text;
        }

        public void PrintToFile(string message)
        {
            using (StreamWriter file = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _outputFileName), true))
            {
                file.WriteLine(message);
            }
        }
    }
}
