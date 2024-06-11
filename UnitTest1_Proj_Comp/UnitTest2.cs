using PROJ_COMP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest1_Assignment
{
    [TestClass]
    public class UnitTest2
    {
        Form1 fm = new Form1();

        /// <summary>
        /// Unit testinf for IF command
        /// </summary>
        [TestMethod]
        public void check_if_command()
        {
            //set variables
            string var = "radius = 10";
            Assert.IsTrue(CommandParser.GetInstance.check_variable(var));
            Assert.IsTrue(Loop.GetInstance.run_variable_command(var));

            string[] text = { "if (radius==10)\nthen\ncircle (radius)", "if (radius==10)\ncircle (radius)\nendif" };
            foreach (string if_type in text)
            {
                string[] list_commands = if_type.Split('\n');
                string if_command = "if (radius==10)";
                int line_found_in = 1;
                //check if command is If command or not
                Assert.IsTrue(CommandParser.GetInstance.check_if_command(if_command));
                //check if command run properly or not
                Assert.IsTrue(Loop.GetInstance.run_if_command(if_command, list_commands, line_found_in, fm));
            }
        }
    }

}
