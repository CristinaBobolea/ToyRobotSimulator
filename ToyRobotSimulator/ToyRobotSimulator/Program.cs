using System;
using ToyRobotSimulator.nsHandlers;
using ToyRobotSimulator.nsGrid;
using ToyRobotSimulator.nsRobot;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
           
            String command;
            bool quitNow = false;

            Grid grid = new Grid(5, 5);
            Robot robot = new Robot();
            CommandsHandler commandHandler = new CommandsHandler(robot, grid);
            ConsoleOutputHandler consoleOutputHandler = new ConsoleOutputHandler();

            Console.WriteLine("Please insert a command(file filename.txt|place x,y,f|move|left|right|report) or /quit to exit!");

            bool isEndOfFile = false;
            while (!quitNow)
            {
                if (commandHandler.IsFileInput && !isEndOfFile)
                {
                    command = commandHandler.FileHandler.ReadLineFromFile(out isEndOfFile);
                }
                else
                {
                    if (isEndOfFile)
                    {
                        consoleOutputHandler.PrintMessage("File parsing finished! You can find the output in output.txt file.");
                    }
                    command = Console.ReadLine();
                }

                if (command == "/quit")
                {
                    quitNow = true;
                    continue;
                }

                commandHandler.HandleInput(command);
            }
        }

        
    }
}
