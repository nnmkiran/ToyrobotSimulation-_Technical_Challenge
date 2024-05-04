using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot.Core
{
    public class TableTop: ITableTop
    {
        public int Rows { set; get; }
        public int Columns { set; get; }

        public TableTop(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        // Validate if location specified is within the table surface.
        public bool IsLocationValid(Location location)
        {
            return location.X < Columns && location.X >= 0 &&
                   location.Y < Rows && location.Y >= 0;
        }
    }
}
