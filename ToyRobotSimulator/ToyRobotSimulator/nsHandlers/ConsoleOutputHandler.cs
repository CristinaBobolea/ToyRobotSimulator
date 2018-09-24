using System;

namespace ToyRobotSimulator.nsHandlers
{
    // OutputHandler prints a message into the console
    public class ConsoleOutputHandler : IOutputHandler
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
