using PROJ_COMP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest1_PROJ_COMP
{
    [TestClass]
    public class Method_tests
    {
        Form1 fm = new Form1();
        /// <summary>
        /// testing for methods
        /// </summary>
        [TestMethod]
        public void check_method_command()
        {
            string[] method_text = { "method test ()\ncircle (100)\nendmethod", "method test1 (radius, width, height)" +
                    "\ncircle (radius)\nrectangle (width, height)\nendmethod" };
            string method_line = "";
            int method_found_in = 1;
            for (int i = 0; i < method_text.Length; i++)
            {
                if (i == 0)
                {
                    //without parameter
                    method_line = "method test ()";
                }
                else
                {
                    //with parameter
                    method_line = "method test1 (radius, width, height)";
                }
                string[] commands = method_text[i].Split('\n');
                Assert.IsTrue(CommandParser.GetInstance.check_method(method_line));
                Assert.IsTrue(Loop.GetInstance.run_method_command(method_line, commands, method_found_in, fm));
            }

            //method call
            string[] method_call = { "test ()", "test1 (10,20,30)" };
            foreach (string cmd in method_call)
            {
                Assert.IsTrue(CommandParser.GetInstance.check_methodcall(cmd));
                Assert.IsTrue(Loop.GetInstance.run_method_call(cmd, fm));
            }

        }
    }
    }
