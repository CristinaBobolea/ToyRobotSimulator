
namespace ToyRobotSimulator.nsPosition
{
    public class NorthDirection : Direction
    {
        public override Direction FaceLeft()
        {
            return new WestDirection();
        }

        public override Direction FaceRight()
        {
            return new EastDirection();
        }

        public override string ToString()
        {
            return "NORTH";
        }
    }
}