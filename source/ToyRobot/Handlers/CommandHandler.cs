using ToyRobot.Enums;
using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot.Handlers
{
    public class CommandHandler : ICommandHandler
    {
        private const int PLACE_COMMAND_COUNT = 2;
        private const int PLACE_PARAMS_COUNT = 3;

        private readonly IRobot _robot;
        private readonly ITableTop _tableTop;
        public CommandHandler(IRobot robot, ITableTop tableTop)
        {
            _robot = robot;
            _tableTop = tableTop;
        }

        public string Execute(string cmd)
        {
            var command = GetCommand(cmd.Split(' '));
            if (command != Command.PLACE && _robot.Location == null) return null;

            switch (command)
            {
                case Command.PLACE:
                    var placement = GetPlacement(cmd.Split(' '));
                    if (_tableTop.IsLocationValid(placement.Location))
                        _robot.Place(placement.Location, placement.Direction);
                    break;
                case Command.MOVE:
                    var newLocation = _robot.Move();
                    if (newLocation.X == _tableTop.Rows || newLocation.Y == _tableTop.Columns)
                        throw new ArgumentException($"Invalid location. Move command beyond the line will be discarded: ({_tableTop.Rows},{_tableTop.Columns})");
                    if (_tableTop.IsLocationValid(newLocation))
                        _robot.Location = newLocation;
                    break;
                case Command.LEFT:
                    _robot.RotateLeft();
                    break;
                case Command.RIGHT:
                    _robot.RotateRight();
                    break;
                case Command.REPORT:
                    return string.Format("Output: {0},{1},{2}", _robot.Location.X, _robot.Location.Y, _robot.Direction.ToString().ToUpper());
            }

            return string.Empty;

        }

        private Command GetCommand(string[] cmd)
        {
            if (!Enum.TryParse(cmd[0], true, out Command command))
                throw new ArgumentException("Invalid command.  Please try again. Valid formats: PLACE X,Y,DIRECTION|MOVE|LEFT|RIGHT|REPORT");
            return command;
        }

        private Placement GetPlacement(string[] cmd)
        {
            if (cmd.Length != PLACE_COMMAND_COUNT)
                throw new ArgumentException("Invalid PLACE command parameters. Valid format: PLACE X,Y,DIRECTION");

            string[] cmdParameters = cmd[1].Split(',');

            if (cmdParameters.Length != PLACE_PARAMS_COUNT)
                throw new ArgumentException("Invalid PLACE command parameters. Valid format: PLACE X,Y,DIRECTION");

            if (!int.TryParse(cmdParameters[0], out int x) || !int.TryParse(cmdParameters[1], out int y))
                throw new ArgumentException("Invalid location. X and Y must be a number. Example: PLACE 1,2,NORTH");

            if (!Enum.TryParse(cmdParameters[cmdParameters.Length - 1], true, out Direction direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");
            if(x>= _tableTop.Rows || y >= _tableTop.Columns)
                throw new ArgumentException($"Invalid location. X and Y must be in({_tableTop.Rows},{_tableTop.Columns})");

            return new Placement(new Location(x, y), direction);

        }

    }
}
