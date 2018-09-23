using ToyRobotSimulator.nsPosition;

namespace ToyRobotSimulator.nsRobot
{
    // Robot class implements IMovable and IStatusReporter interfaces
    // It has methods to map all the possible moves of the robot and to report the current possition 
    public class Robot : IMovable, IStatusReporter
    {
        #region Fields

        private Position _currentPosition;

        #endregion Fields

        #region DelegatesAndEvents

        public delegate void OnReportDelegate(string output);
        public event OnReportDelegate OnReport;

        #endregion DelegatesAndEvents

        #region Properties

        public Position CurrentPosition
        {
            get => _currentPosition;
            set => _currentPosition = value;
        }

        #endregion Properties

        #region Methods

        public void Left()
        {
            CurrentPosition.Direction = CurrentPosition.Direction.FaceLeft();
        }

        public void Move()
        {
            CurrentPosition.Advance();
        }

        public void Place(Position position)
        {
            CurrentPosition = position;
        }

        public void Report()
        {
            OnReport($"Output: {CurrentPosition.X}, {CurrentPosition.Y}, {CurrentPosition.Direction.ToString()}");
        }

        public void Right()
        {
            CurrentPosition.Direction = CurrentPosition.Direction.FaceRight();
        }

        #endregion Methods

    }
}
