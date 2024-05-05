using ToyRobot.Core;
using ToyRobot.Handlers;

namespace ToyRobotSimulatorTest.Test
{
    [TestClass]
    public class ToyRobotSimulatorTest
    {
        [TestMethod]
        public void Send_ValidCommands_To_ToyRobot()
        {
            // Set table top dimentions
            var tableTop = new TableTop(5, 5);
            var robot = new Robot();
            var commandHanlder = new CommandHandler(robot, tableTop);
            var actualValue = "Output: 0,3,NORTH";

            //Commands
            commandHanlder.Execute("PLACE 0,1,NORTH");
            commandHanlder.Execute("MOVE");
            commandHanlder.Execute("LEFT");
            commandHanlder.Execute("MOVE");
            commandHanlder.Execute("RIGHT");
            commandHanlder.Execute("MOVE");
            

            var expectedValue = commandHanlder.Execute("REPORT");
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("x y z")]
        [DataRow("PLACE x,y,EAST")]
        public void Send_InValidCommands_To_ToyRobot(string cmd)
        {
            // Set table top dimentions
            var tableTop = new TableTop(5, 5);
            var robot = new Robot();
            var commandHanlder = new CommandHandler(robot, tableTop);
            
            var argumentException = Assert.ThrowsException<ArgumentException>(() => commandHanlder.Execute(cmd));            
            Assert.IsInstanceOfType<ArgumentException>(argumentException);
        }

        [TestMethod]
        public void ToyLocation_With_ValidPlaceCommand()
        {
            var tableTop = new TableTop(5, 5);
            var robot = new Robot();
            var commandHanlder = new CommandHandler(robot, tableTop);

            commandHanlder.Execute("PLACE 1,4,NORTH");

            Assert.IsNotNull(robot.Location);
        }

        [TestMethod]
        public void ToyLocation_With_InValidPlaceCommand()
        {
            var tableTop = new TableTop(5, 5);
            var robot = new Robot();
            var commandHanlder = new CommandHandler(robot, tableTop);

            var argumentException = Assert.ThrowsException<ArgumentException>(() => commandHanlder.Execute("PLACE 2,5,EAST"));
            Assert.IsInstanceOfType<ArgumentException>(argumentException);
        }
        
    }
}
