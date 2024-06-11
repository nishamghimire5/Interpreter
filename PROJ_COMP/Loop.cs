using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PROJ_COMP.ShapesExceptions;
using static PROJ_COMP.SyntaxVal;
using static PROJ_COMP.Form1;
using System.Text.RegularExpressions;

namespace PROJ_COMP
{
    /// <summary>
    /// creating class loop
    /// </summary>
    public class Loop
    {
        //store method signatures i.e method name and number of parameters
        static IDictionary<string, ArrayList> methods = new Dictionary<string, ArrayList>();

        //store variables
        static IDictionary<string, int> variable = new Dictionary<string, int>();

        //Opeator used in condition of if command
        static string con_operators = "";

        //store variable name used during method declaration
        ArrayList method_para_var = new ArrayList();

        private static Loop instance = null;
        private Loop() { }

        /// <summary>
        /// if instance is null then create a new object of class
        /// </summary>
        public static Loop GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Loop();
                return instance;
            }
        }

        /// <summary>
        /// Collection of key/pair i.e. name/parameter.count
        /// </summary>
        /// <returns>method signatures</returns>
        public static IDictionary<string, ArrayList> getMethodSig()
        {
            return methods;
        }

        /// <summary>
        /// Clear methods, variables
        /// </summary>
        public void Clear_list()
        {
            methods.Clear();
            variable.Clear();
            method_para_var.Clear();
        }

        /// <summary>
        /// execute if command
        /// </summary>
        /// <param name="Draw">if command line</param>
        /// <param name="lines">all commands entered by user</param>
        /// <param name="line_num">if command found line</param>
        /// <param name="fm">Object of Form1</param>
        public bool run_if_command(string Draw, string[] lines, int line_num, Form1 fm)
        {
            // Check for the presence of "endif" after the current line
            int if_end = 0;
            for (int a = line_num; a < lines.Length; a++)
            {
                if (lines[a].Equals("endif"))
                {
                    if_end++;
                }
            }
            // If there is no "endif" and the current line does not contain "then", display an error message
            if (if_end == 0 && !lines[line_num].Equals("then"))
            {
                fm.richTbConsole.AppendText("Error: Please close the IF Statement.");
                return false;
            }

            // Get the conditional operator from the command parser
            con_operators = CommandParser.getOperator();
            // Split the IF statement to get the condition
            string condition = Draw.Split('(', ')')[1].Trim();
            // Split the condition based on the conditional operator
            string[] splitCondition = condition.Split(new string[] {
                    con_operators
                  },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                // Check if the condition is in the correct format
                if (splitCondition.Length == 2)
                {
                    // Extract condition key and value
                    string conditionKey = splitCondition[0].Trim();
                    int conditionValue = int.Parse(splitCondition[1].Trim());
                    // Check if the variable exists in the dictionary
                    if (variable.ContainsKey(conditionKey))
                    {
                        // Retrieve the variable value
                        int variableValue = 0;
                        variable.TryGetValue(conditionKey, out variableValue);
                        bool conditionStatus = false;
                        // Evaluate the condition based on the operator
                        // Update conditionStatus accordingly
                        // Examples: <=, >=, ==, >, <, !=
                        // If condition is true, execute the commands within the IF block or between "then" and "endif"
                        // Determine the type of command and execute it accordingly
                        // Display error message if unsupported command is encountered

                        int value1 = variableValue; //variable
                        int value2 = conditionValue; // 10 20 30

                        if (con_operators == "<=")
                        {
                            if (value1 <= value2) conditionStatus = true;
                        }
                        else if (con_operators == ">=")
                        {
                            if (value1 >= value2) conditionStatus = true;
                        }
                        else if (con_operators == "==")
                        {
                            if (value1 == value2) conditionStatus = true;
                        }
                        else if (con_operators == ">")
                        {
                            if (value1 > value2) conditionStatus = true;
                        }
                        else if (con_operators == "<")
                        {
                            if (value1 < value2) conditionStatus = true;
                        }
                        else if (con_operators == "!=")
                        {
                            if (value1 != value2) conditionStatus = true;
                        }

                        //if condition is true
                        if (conditionStatus)
                        {
                            if (lines[line_num].Equals("then"))
                            {
                                //check type of command
                                string command_type = CommandParser.GetInstance.check_command_type(lines[line_num + 1]);
                                if (command_type.Equals("drawing_commands"))
                                {
                                    if (CommandParser.GetInstance.run_command(lines[line_num + 1]))
                                    {
                                        fm.drawing_command(lines[line_num + 1]);
                                    }
                                }
                            }
                            else
                            {
                                for (int i = (line_num); i < lines.Length; i++)
                                {
                                    if (!(lines[i].Equals("endif")))
                                    {
                                        string command_type = CommandParser.GetInstance.check_command_type(lines[i]);
                                        if (command_type.Equals("drawing_commands"))
                                        {
                                            if (CommandParser.GetInstance.run_command(lines[i]))
                                            {
                                                fm.drawing_command(lines[i]);
                                            }
                                        }
                                        else if (command_type.Equals("variableoperation"))
                                        {
                                            if (CommandParser.GetInstance.check_variable_operation(lines[i]))
                                            {
                                                runVariableOperation(lines[i], fm);
                                            }
                                        }
                                        else
                                        {
                                            fm.richTbConsole.AppendText("\n Command: (" + lines[i] + ") cannot be supported.");
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }
                            }

                        }
                    }
                    else
                    {
                        // Throw exception if the variable is not found
                        throw new VariableNotFoundException("Variable: " + conditionKey + " does not exist");
                    }

                }
                else
                {
                    // Throw exception if the IF condition is in the wrong format
                    throw new InvalidParameterException("Syntax error: IF condition.");
                }
            }
            //catching the thrown errors and handling exceptions
            catch (InvalidParameterException e)
            {
                fm.richTbConsole.AppendText(e.Message);
                return false;
            }
            catch (VariableNotFoundException e)
            {
                fm.richTbConsole.AppendText(e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// method to run the loop command
        /// </summary>
        /// <param name="Draw"> it is the string to store data</param>
        /// <param name="lines">lines are the code's lines</param>
        /// <param name="loop_found_in_line"> it is the line where loop is found</param>
        /// <param name="fm"> it represents form1</param>
        /// <returns></returns>
        public bool run_loop_command(string Draw, string[] lines, int loop_found_in_line, Form1 fm)
        {
            // Check if the "endloop" tag exists after the loop command
            int loop_end_tag_exist = 0;
            for (int a = loop_found_in_line; a < lines.Length; a++)
            {
                if (lines[a].Equals("endloop"))
                {
                    loop_end_tag_exist++;
                }
            }
            // If "endloop" tag doesn't exist, display an error message
            if (loop_end_tag_exist == 0)
            {
                fm.richTbConsole.AppendText("Error: Please close the loop.");
                return false;
            }

            // Parse loop condition and command inside the loop
            string[] store_command = Draw.Split('(', ')');
            // Extract loop variable name and value
            // Validate loop condition and execute commands inside the loop accordingly

            int loop_val = 0; // Initialize loop value to 0
            int counter = 0; // Initialize a counter for variable operations within the loop
            string[] loop_condition = store_command[1].Split(new string[] { "<=", ">=", "<", ">" }, StringSplitOptions.RemoveEmptyEntries); // Split the loop condition based on comparison operators: <=, >=, <, >
            string variable_name = loop_condition[0].ToLower().Trim(); // Extract the variable name from the loop condition and convert it to lowercase
            Console.Write(loop_condition); // Output the loop condition (for debugging purposes)
            int loopValue = int.Parse(loop_condition[1].Trim()); // Parse the loop value from the loop condition
            ArrayList cmds = new ArrayList(); // Initialize an ArrayList to store commands inside the loop

            // Check if the variable exists in the variable dictionary
            if (variable.ContainsKey(variable_name))
            {
                // Get the current value of the loop variable from the variable dictionary
                variable.TryGetValue(variable_name, out loop_val);

                // Iterate through the lines of code to find commands inside the loop
                for (int i = (loop_found_in_line); i < lines.Length; i++)
                {
                    // Add commands to the ArrayList until "endloop" is encountered
                    if (!(lines[i].Equals("endloop")))
                    {
                        cmds.Add(lines[i]);
                    }
                    else
                    {
                        break; // Exit the loop if "endloop" is encountered
                    }

                    // Increment the counter if any variable operations are found in the command
                    if ((lines[i].Contains(variable_name + "+") || lines[i].Contains(variable_name + "-") || lines[i].Contains(variable_name + "*") || lines[i].Contains(variable_name + "/")))
                    {
                        counter++;
                    }
                }

                //if contains <=
                if (store_command[1].Contains("<=")) // Check if the loop condition indicates a "less than or equal to" comparison
                {
                    if (loop_val >= loopValue) // Check if the loop variable is already greater than or equal to the loop value
                    {
                        // Output an error message indicating that the loop variable should be smaller than the loop value
                        fm.richTbConsole.AppendText("Variable " + variable_name + " should be smaller than " + loopValue);
                        return false; // Return false indicating failure
                    }

                    // Loop while the loop variable is less than or equal to the loop value
                    while (loop_val <= loopValue)
                    {
                        foreach (string cmd in cmds) // Iterate through the commands inside the loop
                        {
                            string command_type = CommandParser.GetInstance.check_command_type(cmd); // Determine the type of command

                            // Execute the command based on its type
                            if (command_type.Equals("drawing_commands")) // If it's a drawing command
                            {
                                if (CommandParser.GetInstance.run_command(cmd)) // Execute the drawing command
                                {
                                    fm.drawing_command(cmd); // Display the drawing command in the form
                                }
                            }
                            else if (command_type.Equals("variableoperation")) // If it's a variable operation command
                            {
                                if (CommandParser.GetInstance.check_variable_operation(cmd)) // Check and execute the variable operation command
                                {
                                    runVariableOperation(cmd, fm); // Run the variable operation command
                                }
                            }
                            else // If the command type is not supported
                            {
                                // Output an error message indicating that the command is not supported
                                fm.richTbConsole.AppendText("\n Command: (" + cmd + ") not supported.");
                                return false; // Return false indicating failure
                            }
                        }
                        variable.TryGetValue(variable_name, out loop_val); // Get the updated value of the loop variable from the variable dictionary
                    }
                }

                // Check if the loop condition contains ">=" (greater than or equal to)
                else if (store_command[1].Contains(">="))
                {
                    // Check if the loop variable is less than or equal to the loop value
                    if (loop_val <= loopValue)
                    {
                        // Output an error message indicating that the loop variable should be greater than the loop value
                        fm.richTbConsole.AppendText("Variable " + variable_name + " should be greater than " + loopValue);
                        return false; // Return false indicating failure
                    }

                    // Loop while the loop variable is greater than or equal to the loop value
                    while (loop_val >= loopValue)
                    {
                        foreach (string cmd in cmds) // Iterate through the commands inside the loop
                        {
                            string command_type = CommandParser.GetInstance.check_command_type(cmd); // Determine the type of command

                            // Execute the command based on its type
                            if (command_type.Equals("drawing_commands")) // If it's a drawing command
                            {
                                if (CommandParser.GetInstance.run_command(cmd)) // Execute the drawing command
                                {
                                    fm.drawing_command(cmd); // Display the drawing command in the form
                                }
                            }
                            else if (command_type.Equals("variableoperation")) // If it's a variable operation command
                            {
                                if (CommandParser.GetInstance.check_variable_operation(cmd)) // Check and execute the variable operation command
                                {
                                    runVariableOperation(cmd, fm); // Run the variable operation command
                                }
                            }
                            else // If the command type is not supported
                            {
                                // Output an error message indicating that the command is not supported
                                fm.richTbConsole.AppendText("\n Command: (" + cmd + ") not supported.");
                                return false; // Return false indicating failure
                            }
                        }
                        variable.TryGetValue(variable_name, out loop_val); // Get the updated value of the loop variable from the variable dictionary
                    }
                }

                // Check if the loop condition contains ">"
                else if (store_command[1].Contains(">"))
                {
                    // Check if the loop variable is less than the loop value
                    if (loop_val < loopValue)
                    {
                        // Output an error message indicating that the loop variable should be greater than the loop value
                        fm.richTbConsole.AppendText("Variable " + variable_name + " should be greater than " + loopValue);
                        return false; // Return false indicating failure
                    }

                    // Loop while the loop variable is greater than the loop value
                    while (loop_val > loopValue)
                    {
                        foreach (string cmd in cmds) // Iterate through the commands inside the loop
                        {
                            string command_type = CommandParser.GetInstance.check_command_type(cmd); // Determine the type of command

                            // Execute the command based on its type
                            if (command_type.Equals("drawing_commands")) // If it's a drawing command
                            {
                                if (CommandParser.GetInstance.run_command(cmd)) // Execute the drawing command
                                {
                                    fm.drawing_command(cmd); // Display the drawing command in the form
                                }
                            }
                            else if (command_type.Equals("variableoperation")) // If it's a variable operation command
                            {
                                if (CommandParser.GetInstance.check_variable_operation(cmd)) // Check and execute the variable operation command
                                {
                                    runVariableOperation(cmd, fm); // Run the variable operation command
                                }
                            }
                            else // If the command type is not supported
                            {
                                // Output an error message indicating that the command is not supported
                                fm.richTbConsole.AppendText("\n Command: (" + cmd + ") not supported.");
                                return false; // Return false indicating failure
                            }
                        }
                        variable.TryGetValue(variable_name, out loop_val); // Get the updated value of the loop variable from the variable dictionary
                    }
                }

                // True if the loop condition contains "<"
                else if (store_command[1].Contains("<"))
                {
                    // Check if the loop variable is greater than the loop value
                    if (loop_val > loopValue)
                    {
                        // Output an error message indicating that the loop variable should be smaller than the loop value
                        fm.richTbConsole.AppendText("Variable " + variable_name + " should be smaller than " + loopValue);
                        return false; // Return false indicating failure
                    }
                    // Loop while the loop variable is smaller than the loop value
                    while (loop_val < loopValue)
                    {
                        foreach (string cmd in cmds) // Iterate through the commands inside the loop
                        {
                            string command_type = CommandParser.GetInstance.check_command_type(cmd); // Determine the type of command

                            // Execute the command based on its type
                            if (command_type.Equals("drawing_commands"))
                            {
                                if (CommandParser.GetInstance.run_command(cmd))
                                {
                                    fm.drawing_command(cmd);
                                }
                            }
                            else if (command_type.Equals("variableoperation"))
                            {
                                if (CommandParser.GetInstance.check_variable_operation(cmd))
                                {
                                    runVariableOperation(cmd, fm);
                                }
                            }
                            else // If the command type is not supported
                            {
                                // Output an error message indicating that the command is not supported
                                fm.richTbConsole.AppendText("\n Command: (" + cmd + ") not supported.");
                                return false; // Return false indicating failure
                            }
                        }
                        // Get the updated value of the loop variable from the variable dictionary
                        variable.TryGetValue(variable_name, out loop_val); 
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// execute method command
        /// </summary>
        /// <param name="Draw">method command line</param>
        /// <param name="lines">all commands entered by user</param>
        /// <param name="method_found">loop command found line</param>
        /// <param name="fm">Object of Form1</param>
        public bool run_method_command(string Draw, string[] lines, int method_found, Form1 fm)
        {
            // Check if the endmethod tag exists
            int method_end_tag_exist = 0;
            for (int a = method_found; a < lines.Length; a++)
            {
                if (lines[a].Equals("endmethod", StringComparison.OrdinalIgnoreCase))
                {
                    method_end_tag_exist++;
                }
            }

            // If the endmethod tag is not found, output an error message
            if (method_end_tag_exist == 0)
            {
                fm.richTbConsole.AppendText("Error: Method is not closed.");
                return false; // Return false indicating failure
            }

            // Parse method name and parameters
            string[] command_part = Draw.Split(new string[] { "(" }, StringSplitOptions.RemoveEmptyEntries);
            string inside_brackets = command_part[1];
            inside_brackets = Regex.Replace(inside_brackets, @"\s+", "");
            string cmd = command_part[0] + "(" + inside_brackets;

            string[] command_parts = cmd.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string method_name = command_parts[1].Trim();
            method_name = Regex.Replace(method_name, @"\s+", "");
            int parameter_count = 0;
            string parameter_inside_method = command_parts[2].Trim().Split('(', ')')[1];
            ArrayList commands_inside_method = new ArrayList();

            // Extract commands inside the method
            for (int i = method_found + 1; i < lines.Length; i++)
            {
                if (!lines[i].Equals("endmethod", StringComparison.OrdinalIgnoreCase))
                {
                    commands_inside_method.Add(lines[i]);
                }
                else
                {
                    break;
                }
            }

            // Handling parameters
            if (parameter_inside_method.Contains(','))
            {
                parameter_count = parameter_inside_method.Split(',').Length;
                foreach (string variable_name in parameter_inside_method.Split(','))
                {
                    method_para_var.Add(variable_name);
                }
            }
            else
            {
                if (parameter_inside_method.Length > 0)
                {
                    parameter_count = 1;
                    method_para_var.Add(parameter_inside_method);
                }
                else
                {
                    parameter_count = 0;
                }
            }

            // Generate method signature
            string signature = method_name + "," + parameter_count;

            // Add method signature and commands to the methods dictionary
            if (!methods.ContainsKey(signature))
            {
                methods.Add(signature, commands_inside_method);
            }
            else
            {
                fm.richTbConsole.AppendText("Method already exists in line " + method_found);
            }

            return true; // Return true indicating success
        }



        /// <summary>
        /// Execute method call command
        /// </summary>
        /// <param name="Draw">method call line</param>
        /// <param name="fm">Object of Form1</param>
        public bool run_method_call(string Draw, Form1 fm)
        {
            // Extract method name from the method call command
            string methodname = Draw.Split('(')[0];
            methodname = Regex.Replace(methodname, @"\s+", "");

            // Extract parameters from the method call command
            string parameter_inside_method = Draw.Trim().Split('(', ')')[1];
            int parameter_count = 0;

            // Handling parameters
            if (parameter_inside_method.Contains(','))
            {
                // If multiple parameters are present
                parameter_count = parameter_inside_method.Split(',').Length;
                for (int i = 0; i < parameter_count; i++)
                {
                    // Check if the variable exists in method_para_var list
                    if (!variable.ContainsKey((string)method_para_var[i]))
                    {
                        // If the variable does not exist, add it to the variable dictionary
                        variable.Add((string)method_para_var[i], int.Parse(parameter_inside_method.Split(',')[i]));
                    }
                    else
                    {
                        // If the variable exists, update its value in the variable dictionary
                        variable[(string)method_para_var[i]] = int.Parse(parameter_inside_method.Split(',')[i]);
                    }
                }
            }
            else
            {
                // Check if only one parameter is present in the method call
                if (parameter_inside_method.Length > 0)
                {
                    // Set the parameter count to 1 since there is only one parameter
                    parameter_count = 1;

                    // Check if the variable corresponding to the first parameter name exists in the variable dictionary
                    if (!variable.ContainsKey((string)method_para_var[0]))
                    {
                        // If the variable does not exist, add it to the variable dictionary with its value parsed from the parameter
                        variable.Add((string)method_para_var[0], int.Parse(parameter_inside_method));
                    }
                    else
                    {
                        // If the variable exists, update its value in the variable dictionary with the parsed value from the parameter
                        variable[(string)method_para_var[0]] = int.Parse(parameter_inside_method);
                    }
                }
                else
                {
                    // If no parameters are present, set the parameter count to 0
                    parameter_count = 0;
                }
            }

            // Generate method signature
            string signature = methodname.Trim() + "," + parameter_count;

            // Execute method commands if the method signature exists in the methods dictionary
            if (methods.TryGetValue(signature, out ArrayList commands))
            {
                foreach (string cmd in commands)
                {
                    // Check the type of command
                    string command_type = CommandParser.GetInstance.check_command_type(cmd);

                    // Execute drawing commands
                    if (command_type.Equals("drawing_commands"))
                    {
                        if (CommandParser.GetInstance.run_command(cmd))
                        {
                            fm.drawing_command(cmd);
                        }
                    }
                    // Execute variable operation commands
                    else if (command_type.Equals("variableoperation"))
                    {
                        if (CommandParser.GetInstance.check_variable_operation(cmd))
                        {
                            runVariableOperation(cmd, fm);
                        }
                    }
                    else
                    {
                        // Output an error message for unsupported commands
                        fm.richTbConsole.AppendText("\n Command: (" + cmd + ") not supported.");
                        return false; // Return false indicating failure
                    }
                }
            }
            else
            {
                // Output an error message if the method is not found
                fm.richTbConsole.AppendText("Method " + methodname + " not found.");
                return false; // Return false indicating failure
            }

            return true; // Return true indicating success
        }



        /// <summary>
        /// To get the variables
        /// </summary>
        /// <returns>variables and their values</returns>
        public static IDictionary<string, int> getVariables()
        {
            return variable;
        }

        /// <summary>
        /// method to run variable command
        /// </summary>
        /// <param name="Draw">method line command</param>
        /// <returns> bool </returns>
        public bool run_variable_command(string Draw)
        {
            Draw = Regex.Replace(Draw, @"\s+", "");
            string variable_name = Draw.Split('=')[0].Trim();
            int variable_value = int.Parse(Draw.Split('=')[1].Trim());
            if (!variable.ContainsKey(variable_name))
            {
                variable.Add(variable_name, variable_value);
            }
            else
            {
                variable[variable_name] = variable_value;
            }
            return true;
        }

        /// <summary>
        /// method to run variable operation
        /// </summary>
        /// <param name="line">loop command found line</param>
        /// <param name="fm">object of form1</param>
        /// <returns> variable operators</returns>
        public bool runVariableOperation(string line, Form1 fm)
        {
            //using try catch for exception handling
            try
            {
                line = Regex.Replace(line, @"\s+", "");
                string[] variables = line.Split(new Char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
                int number_of_operator = 0;
                if (variables.Length != 2)
                {
                    return false;
                }

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].Equals('+') || line[i].Equals('-') || line[i].Equals('*') || line[i].Equals('/'))
                    {
                        number_of_operator++;
                    }
                }
                if (number_of_operator > 1)
                {
                    return false;
                }
                string vrKey = variables[0].Trim();
                string vrValue = variables[1].Trim();
                int vrValuenum = Int32.Parse(vrValue);
                int dictValue = 0;

                //true if contains +, -, *, /
                if (variable.ContainsKey(vrKey))
                {
                    variable.TryGetValue(vrKey, out dictValue);
                    if (line.Contains("+"))
                    {
                        variable[vrKey] = dictValue + vrValuenum;
                    }
                    else if (line.Contains("-"))
                    {
                        variable[vrKey] = dictValue - vrValuenum;
                    }
                    else if (line.Contains("*"))
                    {
                        variable[vrKey] = dictValue * vrValuenum;
                    }
                    else if (line.Contains("/"))
                    {
                        variable[vrKey] = dictValue / vrValuenum;
                    }
                }
                else
                {
                    throw new VariableNotFoundException("Variable: " + vrKey + "doesnot exist");
                }
            }
            //catching the errors
            catch (VariableNotFoundException e)
            {
                fm.richTbConsole.AppendText(e.Message);
                return false;
            }
            return true;
        }

    }
}
