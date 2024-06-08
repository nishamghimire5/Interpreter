using PROJ_COMP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest1_Assignment
{
    [TestClass]
    public class UnitTest3
    {
        Form1 fm = new Form1();

        /// <summary>
        /// Unit Testing for while loop command
        /// </summary>
        [TestMethod]
        public void Check_loop_command()
        {
            //set variable
            string[] variable = { "count = 1", "radius = 20" };
            foreach (string var in variable)
            {
                Assert.IsTrue(CommandParser.GetInstance.check_variable(var));
                Assert.IsTrue(Loop.GetInstance.run_variable_command(var));
            }

            string text = "while (count <=5)\ncircle (radius)\nradius+10\ncount+1\nendloop";
            string[] list_commands = text.Split('\n');
            string loop_command = "while (count <=5)";
            int line_found_in = 1;
            //check if loop command is valid or not
            Assert.IsTrue(CommandParser.GetInstance.check_loop(loop_command));
            //check if command run properly or not
            Assert.IsTrue(Loop.GetInstance.run_loop_command(loop_command, list_commands, line_found_in, fm));

        }

    }
}
