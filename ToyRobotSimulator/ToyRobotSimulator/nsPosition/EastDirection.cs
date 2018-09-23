
namespace ToyRobotSimulator.nsPosition
{
    public class EastDirection : Direction
    {
        public override Direction FaceLeft()
        {
            return new NorthDirection();
        }

        public override Direction FaceRight()
        {
            return new SouthDirection();
        }

        public override string ToString()
        {
            return "EAST";
        }
    }
}
