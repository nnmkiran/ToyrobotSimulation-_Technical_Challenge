using ToyRobot.Enums;

namespace ToyRobot.Models
{
    public class Placement
    {
        public Location Location { get; set; }
        public Direction Direction { get; set; }

        public Placement(Location location, Direction direction)
        {
            Location = location;
            Direction = direction;
        }
    }
}
