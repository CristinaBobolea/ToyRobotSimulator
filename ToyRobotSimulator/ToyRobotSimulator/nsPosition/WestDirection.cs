
namespace ToyRobotSimulator.nsPosition
{
    public class WestDirection : Direction
    {
        public override Direction FaceLeft()
        {
            return new SouthDirection();
        }

        public override Direction FaceRight()
        {
            return new NorthDirection();
        }

        public override string ToString()
        {
            return "WEST";
        }
    }
}
