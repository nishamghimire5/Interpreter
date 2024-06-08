using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PROJ_COMP.ShapesExceptions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PROJ_COMP
{
    /// <summary>
    /// creating form1 class with base class Form
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// assigning form from form1
        /// </summary>
        public Form1 form;
        private Graphics g;
        //store x-axis point
        int pen_x = 0;
        //store y-axis point
        int pen_y = 0;
        private ArrayList shapes;
        private Color fill_color;
        private Color pen_color;
        private bool flag_fill;

        //count line of commands
        int countL = 0; 

        //rotate degree
        static int rotate_degree = 0;

        //stores line drawing 
        ArrayList drawline = new ArrayList();

        //varible syntax assigned for class SyntaxVal
        private SyntaxVal syntax;

        /// <summary>
        /// Initialize and define attributes
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            g = panelOutput.CreateGraphics();
            shapes = new ArrayList();
            fill_color = Color.Transparent;
            pen_color = Color.Black;
            flag_fill = false;
            syntax = new SyntaxVal(richTbConsole);

        }

        /// <summary>
        /// Painting the Output Panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelOutput_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < shape_list.Count; i++)
            {
                s = (Shape)shape_list[i];
                s.draw(g);
            }

            if (drawline.Count != 0)
            {
                int no_of_draw = drawline.Count / 5;

                for (int i = 0; i < no_of_draw; i++)
                {
                    for (int j = 0; j < drawline.Count; j = j + 5)
                    {
                        g.DrawLine((Pen)drawline[j], (int)drawline[j + 1], (int)drawline[j + 2], (int)drawline[j + 3], (int)drawline[j + 4]);
                    }

                }
            }

        }

        //creating data dictionary
        IDictionary<string, int> var = new Dictionary<string, int>();

        /// <summary>
        /// for drwaing the shapes or commands
        /// </summary>
        /// <param name="Draw"></param>
        public void drawing_command(string Draw)
        {
            //get variables
            var = Loop.getVariables();
            //remove all whitespace
            Draw = Regex.Replace(Draw, @"\s+", "");
            string draw_cmd = Draw.Split('(')[0];
            if (draw_cmd.Equals("moveto"))
            {
                string positions = Draw.Split('(', ')')[1];

                if (!Regex.IsMatch(positions.Split(',')[0], @"^[0-9]+$"))
                {
                    var.TryGetValue(positions.Split(',')[0], out pen_x);
                }
                else
                {
                    pen_x = int.Parse(positions.Split(',')[0]);
                }
                if (!Regex.IsMatch(positions.Split(',')[1], @"^[0-9]+$"))
                {
                    var.TryGetValue(positions.Split(',')[1], out pen_y);
                }
                else
                {
                    pen_x = int.Parse(positions.Split(',')[1]);
                }
            }

            //condition checking for the drawto command
            if (draw_cmd.Equals("drawto"))
            {
                Pen p1 = new Pen(pen_color);
                string positions = (Draw.Split('(', ')')[1]);
                int pointX;
                int pointY;
                if (!Regex.IsMatch(positions.Split(',')[0], @"^[0-9]+$"))
                {
                    var.TryGetValue(positions.Split(',')[0], out pointX);
                }
                else
                {
                    pointX = int.Parse(positions.Split(',')[0]);
                }
                if (!Regex.IsMatch(positions.Split(',')[1], @"^[0-9]+$"))
                {
                    var.TryGetValue(positions.Split(',')[1], out pointY);
                }
                else
                {
                    pointY = int.Parse(positions.Split(',')[1]);
                }
                drawline.Add(p1);
                drawline.Add(pen_x);
                drawline.Add(pen_y);
                drawline.Add(pointX);
                drawline.Add(pointY);
                panelOutput.Refresh();
            }

            //condition checking for the rotate command
            if (draw_cmd.Equals("rotate"))
            {
                string positions = Draw.Split('(', ')')[1];

                if (!Regex.IsMatch(positions.Split(',')[0], @"^[0-9]+$"))
                {
                    var.TryGetValue(positions.Split(',')[0], out rotate_degree);
                }
                else
                {
                    rotate_degree = int.Parse(positions.Split(',')[0]);
                }
            }

            //condition checking for the pen command
            if (draw_cmd.Equals("pen"))
            {
                string pen_color_name = (Draw.Split('(', ')')[1]);
                if (pen_color_name.Contains("red"))
                {
                    pen_color = Color.Red;
                }
                else if (pen_color_name.Contains("green"))
                {
                    pen_color = Color.Green;
                }
                else if (pen_color_name.Contains("blue"))
                {
                    pen_color = Color.Blue;
                }
                else if (pen_color_name.Contains("black"))
                {
                    pen_color = Color.Black;
                }
                else if (pen_color_name.Contains("orange"))
                {
                    pen_color = Color.Orange;
                }

            }

            //condition checking for the pen command
            if (draw_cmd.Equals("pen"))
            {
                string fill_color_name = (Draw.Split('(', ')')[1]);
                if (fill_color_name.Contains("red"))
                {
                    fill_color = Color.Red;
                }
                else if (fill_color_name.Contains("green"))
                {
                    fill_color = Color.Green;
                }
                else if (fill_color_name.Contains("blue"))
                {
                    fill_color = Color.Blue;
                }
                else if (fill_color_name.Contains("black"))
                {
                    fill_color = Color.Black;
                }
                else if (fill_color_name.Contains("orange"))
                {
                    fill_color = Color.Orange;
                }

            }

            //condition checking for the fill command
            if (draw_cmd.Equals("fill"))
            {
                string fillstring = (Draw.Split('(', ')')[1]);
                if (fillstring.Equals("on"))
                {
                    flag_fill = true;
                }
                else if (fillstring.Equals("off"))
                {
                    flag_fill = false;
                }
            }

            //For refreshing the panel after drawing
            if (draw_cmd.Equals("circle") || draw_cmd.Equals("triangle") || draw_cmd.Equals("rectangle") || draw_cmd.Equals("polygon"))
            {
                SetDrawing(Draw, pen_color, fill_color, flag_fill, pen_x, pen_y);
                panelOutput.Refresh();
            }
        }

        /// <summary>
        /// method to rotate the shape
        /// </summary>
        /// <returns></returns>
        public static int RotateShape()
        {
            return rotate_degree;
        }

        //data dictionary used
        IDictionary<string, int> variable = new Dictionary<string, int>();

        //Object of class Shape
        Shape s;

        //Object of class ShapeFactory
        Factory factory = new Factory();

        /// <summary>
        /// store list of objects.
        /// </summary>
        public static ArrayList shape_list = new ArrayList();

        /// <summary>
        /// method to set all the drawings
        /// </summary>
        /// <param name="Draw"></param>
        /// <param name="pen_color"></param>
        /// <param name="fill_color"></param>
        /// <param name="flag_fill"></param>
        /// <param name="num"></param>
        public void SetDrawing(string Draw, Color pen_color, Color fill_color, bool flag_fill, params int[] num)
        {
            variable = Loop.getVariables();
            int initX = num[0];
            int initY = num[1];

            string Drawing_command = Draw.Split('(')[0];

            //circle (abc)
            //start circle command 
            if (Drawing_command.Equals("circle"))
            {
                string size = (Draw.Split('(', ')')[1]);
                int radius = 0;
                //checks if parameter is number.
                //if false then checks for variable used
                if (!Regex.IsMatch(size, @"^[0-9]+$"))
                {
                    variable.TryGetValue(size, out radius);
                }
                //else stores size passed directly
                else
                {
                    radius = int.Parse(size);
                }

                s = factory.GetShape("circle");
                s.set_properties(pen_color, fill_color, flag_fill, pen_x, pen_y, radius);
                shape_list.Add(s);
            }
            //end circle command

            // start Rectangle
            if (Drawing_command.Equals("rectangle"))
            {
                string size = (Draw.Split('(', ')')[1]);
                string[] param = size.Split(',');
                int height = 0;
                int width = 0;

                if (!Regex.IsMatch(param[0], @"^[0-9]+$"))
                {
                    variable.TryGetValue(param[0], out width);
                }
                else
                {
                    width = int.Parse(param[0]);
                }

                if (!Regex.IsMatch(param[1], @"^[0-9]+$"))
                {
                    variable.TryGetValue(param[1], out height);
                }
                else
                {
                    height = int.Parse(param[1]);
                }

                s = factory.GetShape("rectangle");
                s.set_properties(pen_color, fill_color, flag_fill, pen_x, pen_y, width, height);
                shape_list.Add(s);
            }
            //End Rectangle

            //Start Triangle
            if (Drawing_command.Equals("triangle"))
            {
                string size = (Draw.Split('(', ')')[1]);
                string[] param = size.Split(',');
                int side1 = 0;
                int side2 = 0;
                int side3 = 0;

                if (!Regex.IsMatch(param[0], @"^[0-9]+$"))
                {
                    variable.TryGetValue(param[0], out side1);
                }
                else
                {
                    side1 = int.Parse(param[0]);
                }
                if (!Regex.IsMatch(param[1], @"^[0-9]+$"))
                {
                    variable.TryGetValue(param[1], out side2);
                }
                else
                {
                    side2 = int.Parse(param[1]);
                }

                if (!Regex.IsMatch(param[2], @"^[0-9]+$"))
                {
                    variable.TryGetValue(param[2], out side3);
                }
                else
                {
                    side3 = int.Parse(param[2]);
                }
                s = factory.GetShape("triangle");
                s.set_properties(pen_color, fill_color, flag_fill, pen_x, pen_y, side1, side2, side3);
                shape_list.Add(s);

            }

            //End Triangle

            //Start Polygon
            if (Drawing_command.Equals("polygon"))
            {
                string param = initX + "," + initY + "," + (Draw.Split('(', ')')[1]);
                string[] p = param.Split(',');
                int[] points = new int[p.Length];
                for (int i = 0; i < p.Length; i++)
                {
                    if (!Regex.IsMatch(p[i], @"^[0-9]+$"))
                    {
                        variable.TryGetValue(p[i], out points[i]);
                    }
                    else
                    {
                        points[i] = int.Parse(p[i]);
                    }
                }
                s = factory.GetShape("polygon");
                s.set_properties(pen_color, fill_color, flag_fill, pen_x, pen_y, points);
                shape_list.Add(s);

            }
            //End Polygon
        }

        /// <summary>
        /// not used 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTbAction_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Load the presaved commands 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "TXT(*.TXT) | *.txt";

            if (of.ShowDialog() == DialogResult.OK)
            {
                string s = File.ReadAllText(of.FileName);
                richTbCommand.Text = s;
            }

        }

        /// <summary>
        /// save the commands for furture references
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "TXT(*.TXT) | *.txt";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sf.FileName, richTbCommand.Text);
            }
        }

        /// <summary>
        /// Menustrip to tell about the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// exits out of the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// checks the syntax
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSyntax_Click(object sender, EventArgs e)
        {
            string[] commands = richTbCommand.Text.Split('\n');
            foreach (string command in commands)
            {
                if (!command.Trim().Equals(""))
                {
                    syntax.checkCommand(command);
                }

            }

        }

        /// <summary>
        /// to paint the background
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelBG_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// not used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void richTbConsole_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// for instruction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void instructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = " Run: Runs The Commands. \n Clear: Clear Painting Area \n Reset: Reset All settings \n \n" +
                "\n moveto(x-point,y-point) \n Drawto(x-point,y-point) \n pen(color) \n fill(on || off) \n circle(radius) \n rectangle(length, breadth) \n traingle(side1, side2, side30 \n \n" +
                "\n IF: If <variable>=10 \n Line 1 \n Line 2 Endif \n " +
                "\n LOOP: radius = 10 \n count = 1 \n loop for count <= 5 \n circle(radius) \n radius + 10  \n count + 1 \n endloop \n \n" +
                "\n METHOD: \n Method myMethod(parameter list) \n Line 1 \n Etc \n Endmethod \n \n Call a method with: \n myMethod(< parameter list >) ";

            string title = "Command Syntax";
            System.Windows.Forms.MessageBox.Show(message, title);
        }

        /// <summary>
        /// to know about us
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("This application has been created as an environment for coders where they can create shapes using simple coding. \n @Auther: CS 2020", "About Us");
        }


        /// <summary>
        /// to check the command in richTbcommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTbCommand_KeyDown(object sender, KeyEventArgs e)
        {
        }


            
        /// <summary>
        /// richtbconsole keypress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTbConsole_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// count shape list
        /// </summary>
        public int Count
        {
            get { return shape_list.Count; }
        }

        /// <summary>
        /// to set and get shape
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Shape this[int index]
        {
            get { return (Shape)shape_list[index]; }
            set { shape_list.Add(value); }
        }

        private void richTbAction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //store number of errors
                int error = 0;
                //store executing command in lowercase
                string executing_command = richTbAction.Text.ToLower();

                //if executing command is valid
                if (CommandParser.GetInstance.Valid_execute_command(executing_command))
                {
                    //if executing command is clear
                    if (executing_command.Equals("clear"))
                    {
                        g.Clear(Color.White);
                        drawline.Clear();
                        shape_list.Clear();
                        richTbConsole.Text = "All shapes are cleared.";
                        if (Loop.getMethodSig().Count != 0 || Loop.getVariables().Count != 0)
                        {
                            string message = "Do you want to variables and methods also?";
                            string title = "Clear Data";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result = MessageBox.Show(message, title, buttons);
                            if (result == DialogResult.Yes)
                            {
                                CommandParser.GetInstance.clear_list();
                                Loop.GetInstance.Clear_list();
                                richTbConsole.Text = "All shapes, variable and methods are cleared.";
                            }
                        }
                    }

                    //if executing command is reset
                    if (executing_command.Equals("reset"))
                    {
                        flag_fill = false;
                        pen_color = Color.Black;
                        pen_x = 0;
                        pen_y = 0;
                        richTbConsole.Text = "Pen color set to Black" + Environment.NewLine + "Fill turned off" + Environment.NewLine + "Moved to 0,0";
                    }

                    //if executing command is run
                    if (executing_command.Equals("run"))
                    {
                        bool complex_command = false;              //count current line number
                        countL = 0;
                        //
                        int break_single_if_line = 0;
                        //

                        CommandParser.GetInstance.clear_error();
                        //clear console
                        richTbConsole.Text = null;
                        //get string from textbox separated by newline and store into array
                        String[] lines = richTbCommand.Text.Trim().ToLower().Split(new String[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        Console.Write(lines.Length);
                        ArrayList error_lines = new ArrayList();
                        error_lines.Clear();
                        //loop through commands
                        for (int i = 0; i < lines.Length; i++)
                        {
                            countL++;
                            if (lines[i].Length == 0)
                            {
                                continue;
                            }
                            string Draw = lines[i];
                            //check which command is currently active
                            string command_type = CommandParser.GetInstance.check_command_type(Draw);

                            //if endcommand is found before any command open
                            if (command_type.Equals("end_tag"))
                            {
                                if (!complex_command)
                                {
                                    error++;
                                    richTbConsole.AppendText(Environment.NewLine + "Error: Command " + Draw + " found. Command initiation doesnot exist.");
                                }
                                else
                                {
                                    complex_command = false;
                                }

                            }

                            //if command is invalid
                            if (command_type.Equals("invalid"))
                            {
                                richTbConsole.AppendText(Environment.NewLine + "Invalid Command ( " + Draw + " ) on line " + countL);
                                continue;
                            }


                            //if/then command break
                            if (command_type.Equals("singleif"))
                            {
                                break_single_if_line = countL + 1;
                            }

                            //if commands 'if/loop/method' are inactive
                            if (!complex_command && !command_type.Equals("end_tag"))
                            {
                                if (command_type.Equals("drawing_commands"))
                                {
                                    if (CommandParser.GetInstance.run_command(Draw))
                                    {
                                        if (error == 0)
                                        {
                                            drawing_command(Draw);
                                        }
                                    }
                                    else
                                    {
                                        error++;
                                        error_lines.Add(countL);
                                    }
                                }
                            }


                            //type of command 
                            if (command_type.Equals("variable") || command_type.Equals("if") || command_type.Equals("while") || command_type.Equals("method") || command_type.Equals("variableoperation") || command_type.Equals("methodcall"))
                            {
                                //method command
                                if (command_type.Equals("method"))
                                {
                                    complex_command = true;
                                    if (CommandParser.GetInstance.check_method(Draw))
                                    {
                                        if (error == 0)
                                        {
                                            Loop.GetInstance.run_method_command(Draw, lines, countL, this);
                                        }
                                    }
                                    else
                                    {
                                        error++;
                                        error_lines.Add(countL);
                                    }

                                }

                                //if command
                                if (command_type.Equals("if"))
                                {
                                    complex_command = true;
                                    if (CommandParser.GetInstance.check_if_command(Draw))
                                    {

                                        if (error == 0)
                                        {

                                            Loop.GetInstance.run_if_command(Draw, lines, countL, this);
                                        }
                                    }
                                    else
                                    {
                                        error++;
                                        error_lines.Add(countL);
                                    }
                                }

                                //while loop command
                                if (command_type.Equals("while"))
                                {
                                    complex_command = true;
                                    //check command validity
                                    if (CommandParser.GetInstance.check_loop(Draw))
                                    {
                                        if (error == 0)
                                        {
                                            Loop.GetInstance.run_loop_command(Draw, lines, countL, this);
                                        }
                                    }
                                    else
                                    {
                                        error++;
                                        error_lines.Add(countL);
                                    }

                                }

                                //variable command
                                if (command_type.Equals("variable"))
                                {
                                    if (CommandParser.GetInstance.check_variable(Draw))
                                    {
                                        if (error == 0)
                                        {
                                            Loop.GetInstance.run_variable_command(Draw);
                                        }
                                    }
                                    else
                                    {
                                        error++;
                                        error_lines.Add(countL);
                                    }
                                }

                                //variable operation command
                                if (command_type.Equals("variableoperation"))
                                {
                                    if (CommandParser.GetInstance.check_variable_operation(Draw))
                                    {
                                        if (error == 0)
                                        {
                                            Loop.GetInstance.runVariableOperation(Draw, this);
                                        }
                                    }
                                    else
                                    {
                                        error++;
                                        error_lines.Add(countL);
                                    }
                                }

                                //method call 
                                if (command_type.Equals("methodcall"))
                                {
                                    if (CommandParser.GetInstance.check_methodcall(Draw))
                                    {
                                        if (error == 0)
                                        {
                                            Loop.GetInstance.run_method_call(Draw, this);
                                        }
                                    }
                                    else
                                    {
                                        error++;
                                        error_lines.Add(countL);
                                    }

                                }
                            }
                            if (break_single_if_line == countL)
                            {
                                complex_command = false;
                            }
                        }

                        //show errors
                        if (error != 0)
                        {
                            int i = 0;
                            foreach (string error_description in CommandParser.GetInstance.error_list())
                            {
                                richTbConsole.AppendText(Environment.NewLine + "Error on line " + error_lines[i] + " : " + error_description);
                                i++;
                            }
                            richTbConsole.AppendText(Environment.NewLine + "Please correct command syntax to continue.");
                        }

                    }
                }
            }
        }
    
    }
}
