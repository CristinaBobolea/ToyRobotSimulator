using System;
using ToyRobotSimulator.nsPosition;

namespace ToyRobotSimulator.nsHandlers
{
    // InputParser class is used to parse the arguments given to a command
    public class InputParser
    {
        public bool ParsePlaceCommand(string input, out int x, out int y, out string direction)
        {
            string[] arguments = input.Trim().Split(',');
            
            bool xParsed = Int32.TryParse(arguments[0].Trim(), out x);
            bool yParsed = Int32.TryParse(arguments[1].Trim(), out y);
            direction = arguments[2].Trim().ToLower();

            if (!xParsed || !yParsed)
            {
                return false;
            }

            return true;
        }
    }
}
