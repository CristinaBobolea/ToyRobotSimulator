
namespace ToyRobotSimulator.nsPosition
{
    public class SouthDirection : Direction
    {
        public override Direction FaceLeft()
        {
            return new EastDirection();
        }

        public override Direction FaceRight()
        {
            return new WestDirection();
        }

        public override string ToString()
        {
            return "SOUTH";
        }
    }
}
