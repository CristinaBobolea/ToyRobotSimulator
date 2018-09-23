using ToyRobotSimulator.nsPosition;

namespace ToyRobotSimulator.nsGrid
{
    // Grid class represents the grid on which the robot can move
    // Holds the x and y axis maximum units and the origin
    // It has methods to check whether a move or a place is possible
    public class Grid
    {
        #region Fields

        private const uint _origin = 0;
        private readonly uint _unitsOnXAxis;
        private readonly uint _unitsOnYAxis;

        #endregion Fields

        #region Constructors

        public Grid(uint xUnits, uint yUnits)
        {
            _unitsOnXAxis = xUnits;
            _unitsOnYAxis = yUnits;
        }

        #endregion Constructors

        #region Methods

        public bool IsMovePossible(Position position)
        {
            bool isPossible = false;

            if (position.Direction is EastDirection)
            {
                isPossible = position.X - 1 >= _origin ? true : false;
            }

            if (position.Direction is WestDirection)
            {
                isPossible = position.X + 1 <= (_unitsOnXAxis - 1) ? true : false;
            }

            if (position.Direction is SouthDirection)
            {
                isPossible = position.Y - 1 >= _origin ? true : false;
            }

            if (position.Direction is NorthDirection)
            {
                isPossible = position.Y + 1 <= (_unitsOnYAxis - 1)? true : false;
            }

            return isPossible;
        }

        public bool IsPlacingValid(Position position)
        {
            return (position.X >= _origin && position.X < _unitsOnXAxis) &&
                (position.Y >= _origin && position.Y < _unitsOnYAxis) ? true : false;
        }

        #endregion Methods

    }
}
