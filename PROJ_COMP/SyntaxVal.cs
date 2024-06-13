using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PROJ_COMP.ShapesExceptions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PROJ_COMP
{
    /// <summary>
    /// class to check and validate the syntax 
    /// </summary>
    public class SyntaxVal
    {
        private int count = 0;

        private static System.Windows.Forms.RichTextBox richTbConsole;

        /// <summary>
        /// adding keywords using constructor
        /// </summary> 
        /// <param name="richTbConsole"></param>
        public SyntaxVal(System.Windows.Forms.RichTextBox richTbConsole)
        {
            SyntaxVal.richTbConsole = richTbConsole;
        }

        /// <summary>
        /// method to validate the syntax or command 
        /// </summary>
        /// <returns></returns>
        public void checkCommand(string inputCommand)
        {
            count++;
            string[] command = inputCommand.Trim().ToLower().Replace("\r", "").Split(new[] { ',', ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            if (command[0].Equals("moveto"))
            {
                if (command.Length != 3) richTbConsole.Text = $"Invalid moveto on line number {count}!";
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("drawto"))
            {
                if (command.Length != 3) richTbConsole.Text = ($"Invalid drawto on line number {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("circle"))
            {
                if (command.Length != 2) richTbConsole.Text = $"Invalid circle on line number {count}!";
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("rectangle"))
            {
                if (command.Length != 3) richTbConsole.Text = ($"Invalid rectangle on line number {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("triangle"))
            {
                if (command.Length != 3) richTbConsole.Text = ($"Invalid triangle on line number {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("reset"))
            {
                if (command.Length != 1) richTbConsole.Text = ($"Invalid reset on line number {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("clear"))
            {
                if (command.Length != 1) richTbConsole.Text = ($"Invalid clear on line number {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("pen"))
            {
                if (command.Length != 2) richTbConsole.Text = ($"Invalid pen on line number {count}!");

                if (!command[1].Equals("red") || !command[1].Equals("green") || !command[1].Equals("blue") || !command[1].Equals("black"))
                    richTbConsole.Text = ($"Invalid pen parameter on line {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("fill"))
            {
                if (command.Length != 2) throw new Exception($"Invalid fill on line number {count}!");

                if (!command[1].Equals("on") || !command[1].Equals("off"))
                    richTbConsole.Text = ($"Invalid pen parameter on line {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("if"))
            {
                if (command.Length != 4) richTbConsole.Text = ($"Invalid if parameter on line {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("endif"))
            {
                if (command.Length != 1) richTbConsole.Text = ($"Invalid endif parameter on line {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("while"))
            {
                if (command.Length != 4) richTbConsole.Text = ($"Invalid while parameter on line {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("endloop"))
            {
                if (command.Length != 1) richTbConsole.Text = ($"Invalid endloop parameter on line {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("method"))
            {
                if (command.Length < 2) richTbConsole.Text = ($"Invalid method parameter on line {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }
            else if (command[0].Equals("endmethod"))
            {
                if (command.Length != 1) richTbConsole.Text = ($"Invalid endmethod parameter on line {count}!");
                else
                    richTbConsole.Text = "Valid Syntax ";
            }

        }
  
      
    }
}

