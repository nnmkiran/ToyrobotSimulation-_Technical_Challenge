using ToyRobot.Core;
using ToyRobot.Handlers;
using ToyRobot.Services;

var helpText = @$"
----------------------------------------------------------------------         
                  TOY ROBOT SIMULATOR             
----------------------------------------------------------------------

Instructions:

1. The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 x 5 of dimentions
    using the following command:

    PLACE X,Y,DIRECTION 
      -  where X and Y are integers that indicate a location on the tabletop and DIRECTION is a string indicating 
         which direction the robot should face (must be either NORTH, SOUTH, EAST or WEST)
    Example: PLACE 0,0,NORTH

2. When the toy robot is placed, you can enter the following commands:
    LEFT   – Rotate the toy 90 degrees left.
    RIGHT  – Rotate the toy 90 degrees right.
    MOVE   – Moves the toy Robot one unit forward in the direction it is currently facing
    REPORT – Shows the current status of the toy(X,Y and Direction of the robot) 
   
 3. EXIT  – to exit the Toy Robot Simulator.
-------------------------------------------------------------------------
ENTER A COMMAND:";

ITableTop tableSurface = new TableTop(5, 5);
IRobot robot = new Robot();
ICommandHandler commandHandler = new CommandHandler(robot, tableSurface);

var stopApplication = false;
Console.WriteLine(helpText);

while (!stopApplication)
{
    var command = Console.ReadLine();
    if (String.IsNullOrEmpty(command)) continue;

    if (command.ToLower() == "exit")
    {
        stopApplication = true;
    }
    else
    {
        try
        {
            var result = commandHandler.Execute(command);
            if (!String.IsNullOrEmpty(result))
                Console.WriteLine(result);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

