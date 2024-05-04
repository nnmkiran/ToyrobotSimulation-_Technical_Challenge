using ToyRobot.Enums;
using ToyRobot.Models;

namespace ToyRobot.Services
{
    public interface IRobot
    {
        public Location Location { get; set; }
        public Direction Direction { get; set; }
        void Place(Location location, Direction direction);
        Location Move();
        void RotateLeft();
        void RotateRight();
        void Rotate(int rotationNumber);

    }
}
