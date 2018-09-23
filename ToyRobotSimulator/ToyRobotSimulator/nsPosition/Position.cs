
namespace ToyRobotSimulator.nsPosition
{
    // Position class represents the position that a robot can take
    // It holds x, y and direction/facing
    public class Position
    {
        #region Fields

        private int _x;
        private int _y;
        private Direction _direction;

        #endregion Fields

        #region Constructors

        public Position(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        #endregion Constructors

        #region Properties

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public Direction Direction
        {
            get => _direction;
            set => _direction = value;
        }

        #endregion Properties

        #region Methods

        public void Advance()
        {
            if (Direction is EastDirection)
            {
                X = X - 1;
            }

            if (Direction is WestDirection)
            {
                X = X + 1;
            }

            if (Direction is SouthDirection)
            {
                Y = Y - 1;
            }

            if (Direction is NorthDirection)
            {
                Y = Y + 1;
            }
        }

        #endregion Methods
    }
}
