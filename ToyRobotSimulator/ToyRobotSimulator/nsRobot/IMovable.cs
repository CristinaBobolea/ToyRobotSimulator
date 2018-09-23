using ToyRobotSimulator.nsPosition;

namespace ToyRobotSimulator.nsRobot
{
    public interface IMovable
    {
        void Place(Position position);
        void Move();
        void Left();
        void Right();
    }
}
