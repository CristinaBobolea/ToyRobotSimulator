using System;
using System.Collections.Generic;
using ToyRobotSimulator.nsGrid;
using ToyRobotSimulator.nsRobot;
using ToyRobotSimulator.nsPosition;

namespace ToyRobotSimulator.nsHandlers
{
    // CommandsHandler class maps the commands that can be received from the command line
    // It uses the InputParser and OutputHandler to interact with the console
    // Checks with the Grid(if needed) if a command is valid for the current position of the robot
    // Sends to the robot the needed command
    public class CommandsHandler
    {
        #region Fields

        private Robot _robot;
        private Grid _grid;
        private bool _isRobotInitialized;
        private InputParser _inputParser;
        private OutputHandler _outputHandler;
        private Dictionary<String, HandleCommand> _commandsDictionary;

        #endregion Fields

        #region Delegates

        private delegate void HandleCommand(string[] input);

        #endregion Delegates

        #region Constructors

        public CommandsHandler(Robot robot, Grid grid)
        {
            _robot = robot;
            _robot.OnReport += OnRobotReport;

            _grid = grid;
            _isRobotInitialized = false;

            _inputParser = new InputParser();
            _outputHandler = new OutputHandler();

            _commandsDictionary = new Dictionary<String, HandleCommand>();

            _commandsDictionary["place"] = HandlePlace;
            _commandsDictionary["move"] = HandleMove;
            _commandsDictionary["left"] = HandleLeft;
            _commandsDictionary["right"] = HandleRight;
            _commandsDictionary["report"] = HandleReport;
        }

        #endregion Constructors

        #region PublicMethods

        public void HandleInput(string input)
        {
            string[] arguments = input.Split(' ', 2);

            if (arguments.Length < 0 || !_commandsDictionary.ContainsKey(arguments[0].ToLower()))
            {
                _outputHandler.PrintMessage("Please enter a valid command!");
                return;
            }

            _commandsDictionary[arguments[0].ToLower()](arguments);
        }

        #endregion PublicMethods

        #region PrivateMethods

        private void HandleMove(string[] input)
        {
            if (!_isRobotInitialized)
            {
                ReportNotInitializedRobot();
                return;
            }

            if (!_grid.IsMovePossible(_robot.CurrentPosition))
            {
                _outputHandler.PrintMessage("Move not possible!");
                return;
            }

            _robot.Move();
        }

        private void HandlePlace(string[] input)
        {
            Position position = new Position(-1, -1, new NorthDirection());
            int x = 0;
            int y = 0;
            string direction;

            if (!_inputParser.ParsePlaceCommand(input[1], out x, out y, out direction))
            {
                _outputHandler.PrintMessage("Please enter a valid format for PLACE command!");
                return;
            }

            if (!GetPosition(x, y, direction, ref position))
            {
                _outputHandler.PrintMessage("Please enter a valid format for PLACE command!");
                return;
            }

            if (!_grid.IsPlacingValid(position))
            {
                _outputHandler.PrintMessage("Please enter a valid position!");
                return;
            }
            
            _robot.Place(position);
            _isRobotInitialized = true;
        }

        private void HandleLeft(string[] input)
        {
            if (!_isRobotInitialized)
            {
                ReportNotInitializedRobot();
                return;
            }

            _robot.Left();

        }

        private void HandleRight(string[] input)
        {
            if (!_isRobotInitialized)
            {
                ReportNotInitializedRobot();
                return;
            }

            _robot.Right();
        }

        private void HandleReport(string[] input)
        {
            if (!_isRobotInitialized)
            {
                ReportNotInitializedRobot();
                return;
            }

            _robot.Report();
        }

        private void OnRobotReport(string output)
        {
            _outputHandler.PrintMessage(output);
        }

        private void ReportNotInitializedRobot()
        {
            _outputHandler.PrintMessage("Robot not initialized! Please insert a place command!");
        }

        private bool GetPosition(int x, int y, string direction, ref Position position)
        {
            bool isPositionCreated = true;
            switch (direction)
            {
                case "north":
                    position = new Position(x, y, new NorthDirection());
                    break;
                case "south":
                    position = new Position(x, y, new SouthDirection());
                    break;
                case "west":
                    position = new Position(x, y, new WestDirection());
                    break;
                case "east":
                    position = new Position(x, y, new EastDirection());
                    break;
                default:
                    isPositionCreated = false;
                    break;
            }
            return isPositionCreated;
        }
        #endregion PrivateMethods
    }
}
