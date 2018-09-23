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
            Boolean quitNow = false;

            Grid grid = new Grid(5, 5);
            Robot robot = new Robot();
            CommandsHandler commandHandler = new CommandsHandler(robot, grid);

            Console.WriteLine("Please insert a command(place x,y,f|move|left|right|report) or /quit to exit!");

            while (!quitNow)
            {
                command = Console.ReadLine();
                
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
