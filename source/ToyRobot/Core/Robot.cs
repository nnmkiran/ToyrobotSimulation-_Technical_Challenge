using ToyRobot.Enums;
using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot.Core
{
    public class Robot : IRobot
    {
        public Location Location { get; set; }
        public Direction Direction { get; set; }


        public void Place(Location location, Direction direction)
        {
            Location = location;
            Direction = direction;
        }

        public Location Move()
        {
            var newLocation = new Location(Location.X, Location.Y);
            switch (Direction)
            {
                case Direction.NORTH:
                    newLocation.Y = Location.Y + 1;
                    break;
                case Direction.EAST:
                    newLocation.X = Location.X + 1;
                    break;
                case Direction.SOUTH:
                    newLocation.Y = Location.Y - 1;
                    break;
                case Direction.WEST:
                    newLocation.X = Location.X - 1;
                    break;
            }

            return newLocation;
        }

        //Instructs the robot to rotate 90° anticlockwise/counterclockwise.
        public void RotateLeft()
        {
            Rotate(-1);
        }

        //Instructs the robot to rotate 90° clockwise.
        public void RotateRight()
        {
            Rotate(1);

        }
        public void Rotate(int rotationNumber)
        {
            var directions = (Direction[])Enum.GetValues(typeof(Direction));
            Direction newDirection;
            if (Direction + rotationNumber < 0)
                newDirection = directions[directions.Length - 1];
            else
            {
                var index = (int)(Direction + rotationNumber) % directions.Length;
                newDirection = directions[index];
            }
            Direction = newDirection;
        }

    }
}
