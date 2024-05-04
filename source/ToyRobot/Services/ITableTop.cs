using ToyRobot.Models;

namespace ToyRobot.Services
{
    public interface ITableTop
    {
        public int Rows { set; get; }
        public int Columns { set; get; }
        bool IsLocationValid(Location location);
    }
}
