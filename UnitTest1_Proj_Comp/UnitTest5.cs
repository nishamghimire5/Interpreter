using PROJ_COMP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest1_PROJ_COMP
{
    [TestClass]
    public class Variable_test
    {
        Form1 fm = new Form1();

        /// <summary>
        /// test for the variables
        /// </summary>
        [TestMethod]
        public void Variable_command_and_operations_test()
        {
            string[] text = { "width = 10", "rectangle=50", "height= 5" };
            foreach (string check_text in text)
            {
                Assert.IsTrue(CommandParser.GetInstance.check_variable(check_text));
                Assert.IsTrue(Loop.GetInstance.run_variable_command(check_text));

            }
            string[] operation_text = { "width+10", "rectangle-20", "height*5", "height/5" };
            foreach (string check_text in operation_text)
            {
                Assert.IsTrue(CommandParser.GetInstance.check_variable_operation(check_text));
                Assert.IsTrue(Loop.GetInstance.runVariableOperation(check_text, fm));
            }
        }
    }
    }
