namespace ToyRobot.Services
{
    public interface ICommandHandler
    {
        string Execute(string command);
    }
}
