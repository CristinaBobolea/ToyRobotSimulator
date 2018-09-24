using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.nsHandlers
{
    public class FileOutputHandler : IOutputHandler
    {
        private FileHandler _fileHandler;

        public FileOutputHandler(FileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public void PrintMessage(string message)
        {
            _fileHandler.PrintToFile(message);
        }
    }
}
