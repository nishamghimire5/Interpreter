//Component Two
// Fundamental types and base classes for basic functionality like string manipulation and exception handling.
using System;
// Interfaces and classes for managing collections of objects efficiently.
using System.Collections;
// Interfaces and classes for creating strongly-typed collections, improving type safety and performance.
using System.Collections.Generic;
// Provides access to GDI+ basic graphics functionality for drawing shapes, images, and text on forms.
using System.Drawing;
// Classes and interfaces for querying collections using Language-Integrated Query (LINQ) syntax.
using System.Linq;
// Classes for encoding/decoding strings, working with regular expressions, and text manipulation.
using System.Text;
// Classes for using regular expressions to search, match, and manipulate text.
using System.Text.RegularExpressions;
// Types for simplifying the work of writing concurrent and asynchronous code.
using System.Threading.Tasks;
// Classes for creating Windows-based applications with forms, controls, and user input handling.
using System.Windows.Forms;
// Access to enumerated types related to shape exceptions.
using static PROJ_COMP.ShapesExceptions;


namespace PROJ_COMP
{
    /// <summary>
    /// This class contains all the methods to check and run commands
    /// </summary>
    public class CommandParser
    {
        //assigning f1
        Form1 f1;
        

        /// <summary>
        /// It is the parameterized constructor of commandparser
        /// </summary>
        /// <param name="f1"></param>
        public CommandParser(Form1 f1)
        {
            this.f1 = f1;
        }

        /// <summary>
        /// calling constructor 
        /// </summary>
        public CommandParser()
        {

        }


        /// <summary>
        /// setting command parser instance to null
        /// </summary>
        private static CommandParser instance = null;

        /// <summary>
        /// private constructor
        /// </summary>
        public static CommandParser GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new CommandParser();
                return instance;
            }
        }

        //store if statement operator
        static string conditionOperator = null;

        //store variables and their value
        IDictionary<string,
        int> variable = new Dictionary<string,
        int>();

        //store method signature
        IDictionary<string,
        ArrayList> method_signature = new Dictionary<string,
        ArrayList>();

        //store errors
        ArrayList errors = new ArrayList();

        /// <summary>
        /// clear error list, variables, method
        /// </summary>
        public void clear_list()
        {
            errors.Clear();
            method_signature.Clear();
            variable.Clear();
        }

        /// <summary>
        /// clearing the errors
        /// </summary>
        public void clear_error()
        {
            errors.Clear();
        }

        /// <summary>
        /// run command to run all the commands
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool run_command(string command)
        {
            //assigning variable
            variable = Loop.getVariables();
            string Draw_cmd = command.Split('(')[0].Trim();
            //try and catch for error handling
            try
            {
                //if for checking the commands
                if (Draw_cmd.Equals("moveto") || Draw_cmd.Equals("drawto") || Draw_cmd.Equals("pen") || Draw_cmd.Equals("fill") || Draw_cmd.Equals("circle") || Draw_cmd.Equals("rectangle") || Draw_cmd.Equals("triangle") || Draw_cmd.Equals("polygon") || Draw_cmd.Equals("rotate"))
                {
                    string value_inside_brackets = null;
                    string[] parameters = null;

                    //try and catch for error handling
                    try
                    {
                        if (command.Split('(', ')').Length > 1)
                        {
                            value_inside_brackets = command.Split('(', ')')[1];
                            value_inside_brackets = Regex.Replace(value_inside_brackets, @"\s+", "");
                            parameters = value_inside_brackets.Split(',');
                        }
                        else
                        {
                            throw new InvalidParameterException("Parameters Missing");
                        }
                    }
                    catch (InvalidParameterException e)
                    {
                        errors.Add(e.Message);
                        return false;
                    }

                    //check moveto and Drawto command
                    if (Draw_cmd.Equals("moveto") || Draw_cmd.Equals("drawto"))
                    {
                        //try and catch for error handling
                        try
                        {
                            //checking the parameter length
                            if (parameters.Length == 2)
                            {
                                //If it's not a number (checked using a regular expression) and not found in the variable dictionary, a VariableNotFoundException is thrown.
                                if (!Regex.IsMatch(parameters[0], @"^[0-9]+$"))
                                {
                                    if (!variable.ContainsKey(parameters[0]))
                                    {
                                        throw new VariableNotFoundException("Variable: " + parameters[0] + " doesnot exist");
                                    }
                                }
                                else
                                {
                                    int.Parse(parameters[0]);
                                }

                                //checking parameter
                                if (!Regex.IsMatch(parameters[1], @"^[0-9]+$"))
                                {
                                    if (!variable.ContainsKey(parameters[1]))
                                    {
                                        throw new VariableNotFoundException("Variable: " + parameters[1] + " doesnot exist");
                                    }
                                }
                                else
                                {
                                    int.Parse(parameters[1]);
                                }
                            }
                            else
                            {
                                throw new InvalidParameterException("2 parameters required.");
                            }
                        }
                        //catching the thrown errors
                        catch (FormatException)
                        {
                            errors.Add("X and Y should be in numbers");
                            return false;
                        }
                        //catching the thrown errors
                        catch (InvalidParameterException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }
                        //catching the thrown errors
                        catch (VariableNotFoundException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }
                        return true;

                    }
                    //check moveto and Drawto command ended

                    //check pen command
                    if (Draw_cmd.Equals("pen"))
                    {
                        //try catch for error handling
                        try
                        {
                            if (!value_inside_brackets.Contains(','))
                            {
                                if (value_inside_brackets.Equals("red") || value_inside_brackets.Equals("green") || value_inside_brackets.Equals("blue") || value_inside_brackets.Equals("black") || value_inside_brackets.Equals("orange"))
                                {
                                    return true;
                                }
                                else
                                {
                                    throw new InvalidParameterException("Color not supported.");
                                }
                            }
                            else
                            {
                                throw new InvalidParameterException("Only 1 parameter required.");
                            }
                        }
                        //catching the thrown errors
                        catch (InvalidParameterException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }
                    }
                    // pen command ended

                    //check fill command
                    if (Draw_cmd.Equals("fill"))
                    {
                        try
                        {
                            if (!value_inside_brackets.Contains(','))
                            {
                                if (value_inside_brackets.Equals("on") || value_inside_brackets.Equals("off"))
                                {
                                    return true;
                                }
                                else
                                {
                                    throw new InvalidParameterException("Invalid fill option.");
                                }
                            }
                            else
                            {
                                throw new InvalidParameterException("Only 1 parameter required.");
                            }
                        }
                        //catching the thrown errors
                        catch (InvalidParameterException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }
                    }
                    //fill command ended

                    //check rotate command
                    if (Draw_cmd.Equals("rotate"))
                    {
                        //try catch to catch errors
                        try
                        {
                            //checking parameter lenght
                            if (parameters.Length == 1)
                            {
                                if (!Regex.IsMatch(parameters[0], @"^[0-9]+$"))
                                {
                                    if (variable.ContainsKey(parameters[0]))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        throw new VariableNotFoundException("Variable: " + parameters[0] + " does not exist");
                                    }
                                }
                                else
                                {
                                    int.Parse(parameters[0]);
                                    return true;
                                }
                            }
                            else
                            {
                                throw new InvalidParameterException("Only 1 parameter required.");
                            }

                        }
                        //catching thrown errors
                        catch (FormatException)
                        {
                            errors.Add("Degree should be in numbers (0-9).");
                            return false;
                        }
                        catch (InvalidParameterException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }
                        catch (VariableNotFoundException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }

                    }
                    //end rotate command


                    //check circle command
                    if (Draw_cmd.Equals("circle"))
                    {
                        try
                        {
                            //checking paramenters
                            if (parameters.Length == 1)
                            {
                                if (!Regex.IsMatch(parameters[0], @"^[0-9]+$"))
                                {
                                    if (variable.ContainsKey(parameters[0]))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        throw new VariableNotFoundException("Variable: " + parameters[0] + " does not exist");
                                    }
                                }
                                else
                                {
                                    int.Parse(parameters[0]);
                                    return true;
                                }
                            }
                            else
                            {
                                throw new InvalidParameterException("Only 1 parameter required.");
                            }

                        }
                        //catching thrown errors
                        catch (FormatException)
                        {
                            errors.Add("Radius should be in numbers (0-9).");
                            return false;
                        }
                        catch (InvalidParameterException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }
                        catch (VariableNotFoundException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }

                    }
                    //circle command ended

                    //check polygon command
                    if (Draw_cmd.Equals("polygon"))
                    {
                        try
                        {
                            //checking parameter's length
                            if (parameters.Length % 2 == 0 && parameters.Length >= 4)
                            {
                                foreach (string param in parameters)
                                {
                                    if (!Regex.IsMatch(param, @"^[0-9]+$"))
                                    {
                                        if (!variable.ContainsKey(param))
                                        {
                                            throw new VariableNotFoundException("Variable: " + param + " does not exist");
                                        }
                                    }
                                    else
                                    {
                                        int.Parse(param);
                                    }
                                }
                            }
                            else
                            {
                                throw new InvalidParameterException("Minimum 2 points (4 parameters) needed.");
                            }
                        }
                        //catching the thrown errors
                        catch (FormatException)
                        {
                            errors.Add("Points should be in numbers.");
                            return false;
                        }
                        catch (InvalidParameterException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }
                        catch (VariableNotFoundException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }

                        return true;
                    }
                    //polygon command ended

                    //check rectangle command
                    if (Draw_cmd.Equals("rectangle"))
                    {
                        try
                        {
                            //checking the parameter's length
                            if (parameters.Length == 2)
                            {
                                if (!Regex.IsMatch(parameters[0], @"^[0-9]+$"))
                                {
                                    if (!variable.ContainsKey(parameters[0]))
                                    {
                                        throw new VariableNotFoundException("Variable: " + parameters[0] + " does not exist");
                                    }
                                }
                                else
                                {
                                    int.Parse(parameters[0]);
                                }

                                if (!Regex.IsMatch(parameters[1], @"^[0-9]+$"))
                                {
                                    if (!variable.ContainsKey(parameters[1]))
                                    {
                                        throw new VariableNotFoundException("Variable: " + parameters[1] + " does not exist"); ;
                                    }
                                }
                                else
                                {
                                    int.Parse(parameters[1]);
                                }
                            }
                            else
                            {
                                throw new InvalidParameterException("2 parameters required");
                            }
                        }
                        //catching thrown errors
                        catch (FormatException)
                        {
                            errors.Add("Width and height should be in numbers.");
                            return false;
                        }
                        catch (InvalidParameterException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }
                        catch (VariableNotFoundException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }
                        return true;
                    }
                    //end rectangle command

                    //check triangle command
                    if (Draw_cmd.Equals("triangle"))
                    {
                        try
                        {
                            //checking parameter's length
                            if (parameters.Length == 3)
                            {
                                foreach (string param in parameters)
                                {
                                    if (!Regex.IsMatch(param, @"^[0-9]+$"))
                                    {
                                        if (!variable.ContainsKey(param))
                                        {
                                            throw new VariableNotFoundException("Variable: " + param + " does not exist");
                                        }
                                    }
                                    else
                                    {
                                        int.Parse(param);
                                    }
                                }
                            }
                            //if there is less parameter
                            else
                            {
                                throw new InvalidParameterException("Three parameters required");
                            }

                        }
                        //catching the errors
                        catch (FormatException)
                        {
                            errors.Add("Triangle sides should be in numbers.");
                            return false;
                        }
                        catch (InvalidParameterException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }
                        catch (VariableNotFoundException e)
                        {
                            errors.Add(e.Message);
                            return false;
                        }

                        return true;
                    }
                }
                else
                {
                    throw new InvalidCommandException("Command not valid");
                }
            }
            //catching the errors
            catch (InvalidCommandException e)
            {
                errors.Add(e.Message);
                return false;
            }
            return false;
        }

        /// <summary>
        /// method to check the command type
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public string check_command_type(string cmd)
        {
            string type = null;
            //if and endif
            if (cmd.Contains("if") && !cmd.Contains("endif"))
            {
                type = "if";
            }
            //single line if
            else if (cmd.Contains("then"))
            {
                type = "singleif";
            }
            //while loop
            else if (cmd.Contains("while")) 
            {
                type = "while";
            }
            //methods
            else if (cmd.Contains("method") && !cmd.Contains("endmethod"))
            {
                if (cmd.Split(' ')[0].Equals("method"))
                {
                    type = "method";
                }
                else
                {
                    type = "methodcall";
                }
            }
            //all the other shape's command
            else if (cmd.Contains("moveto") || cmd.Contains("drawto") || cmd.Contains("pen") || cmd.Contains("fill") || cmd.Contains("circle") || cmd.Contains("rectangle") || cmd.Contains("triangle") || cmd.Contains("polygon") || cmd.Contains("rotate"))
            {
                type = "drawing_commands";
            }
            //ending commands
            else if (cmd.Contains("endif") || cmd.Contains("endloop") || cmd.Contains("endmethod"))
            {
                type = "end_tag";
            }
            //other than the previous commands
            else
            {
                if (cmd.Contains("="))
                {
                    if (cmd.Split('=').Length == 2)
                    {
                        type = "variable";
                    }
                }
                else if (cmd.Contains("+") || cmd.Contains("-") || cmd.Contains("*") || cmd.Contains("/"))
                {
                    type = "variableoperation";
                }
                else if (cmd.Contains("(") && cmd.Contains(")"))
                {
                    type = "methodcall";
                }
                else
                {
                    type = "invalid";
                }
            }
            return type;
        }

        /// <summary>
        /// method to check the variables
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool check_variable(string command)
        {
            command = Regex.Replace(command, @"\s+", "");
            string variable_name = command.Split('=')[0];
            string first_char = variable_name.Substring(0, 1);

            //try catch for error handling
            try
            {
                if (Regex.IsMatch(first_char, @"^[a-zA-Z]+$"))
                {
                    if (Regex.IsMatch(variable_name, @"^[a-zA-Z0-9]+$"))
                    {
                        int.Parse(command.Split('=')[1]);
                        return true;
                    }
                    else
                    {
                        throw new InvalidVariableNameException("Variable name is invalid");
                    }
                }
                //if the condition isn't met
                else
                {
                    throw new InvalidVariableNameException("Variable name should start with alphabet");
                }
            }
            //to catch the errors
            catch (InvalidVariableNameException e)
            {
                errors.Add(e.Message);
                return false;
            }
            catch (FormatException)
            {
                errors.Add("Variable value should be in number format.");
                return false;
            }
        }
        
        /// <summary>
        /// checking the variable of the operation
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool check_variable_operation(string cmd)
        {
            variable = Loop.getVariables();
            cmd = Regex.Replace(cmd, @"\s+", "");
            string[] parameter = cmd.Trim().Split(new Char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (variable.ContainsKey(parameter[0]))
                {
                    return true;
                }
                else
                {
                    throw new InvalidCommandException("Variable not found");
                }
            }
            catch (InvalidCommandException e)
            {
                errors.Add(e.Message);
                return false;
            }
        }

        /// <summary>
        /// checking the if command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool check_if_command(string command)
        {
            command = Regex.Replace(command, @"\s+", "");
            string[] command_parts = command.Trim().Split(new string[] { "(" }, StringSplitOptions.RemoveEmptyEntries);
            string condition;
            try
            {
                if (command_parts[0].Equals("if"))
                {
                    if (command_parts.Length == 2)
                    {
                        condition = command.Split('(', ')')[1].Trim();
                        //check for operator
                        if (condition.Contains("<=") && !condition.Contains(">"))
                        {
                            conditionOperator = "<=";
                            return true;
                        }
                        else if (condition.Contains(">=") && !condition.Contains("<"))
                        {
                            conditionOperator = ">=";
                            return true;
                        }
                        else if (condition.Contains("!="))
                        {
                            conditionOperator = "!=";
                            return true;
                        }
                        else if (condition.Contains("==") && !condition.Contains(">") && !condition.Contains("<"))
                        {
                            conditionOperator = "==";
                            return true;
                        }
                        else if (!condition.Contains("==") && condition.Contains(">") && !condition.Contains("<"))
                        {
                            conditionOperator = ">";
                            return true;

                        }
                        else if (!condition.Contains("==") && !condition.Contains(">") && condition.Contains("<"))
                        {
                            conditionOperator = "<";
                            return true;
                        }
                        //if invalid operation is used
                        else
                        {
                            throw new InvalidParameterException("Invalid Operator Used.");
                        }
                    }
                    //if invalid syntax is used
                    else
                    {
                        throw new InvalidCommandException("Invalid 'If' Command Syntax");
                    }

                }
                //if invalid name is used
                else
                {
                    throw new InvalidCommandException("Invalid Command Name.");
                }
            }
            //catching the errors
            catch (InvalidCommandException e)
            {
                errors.Add(e.Message);
                return false;
            }
            catch (InvalidParameterException e)
            {
                errors.Add(e.Message);
                return false;
            }
        }


        /// <summary>
        /// get if condition operator
        /// </summary>
        /// <returns>operator used in if command</returns>
        public static string getOperator()
        {
            return conditionOperator;
        }

        /// <summary>
        /// check loop command validity
        /// </summary>
        /// <param name="command">command to be checked</param>
        /// <returns>true if command is valid else false</returns>
        public bool check_loop(string command)
        {
            variable = Loop.getVariables();
            command = Regex.Replace(command, @"\s+", "");
            string[] check_cmd = command.Split(new string[] { "(" },

            StringSplitOptions.RemoveEmptyEntries);
            string[] loopCondition = { };
            try
            {
                if (!check_cmd[0].Equals("while"))
                {
                    throw new InvalidCommandException("Invalid Command Name");
                }

                if (check_cmd.Length != 2)
                {
                    throw new InvalidCommandException("Invalid while Command Syntax");
                }

                loopCondition = check_cmd[1].Split(new string[] { "<=", ">=", "<", ">" }, StringSplitOptions.RemoveEmptyEntries);
                if (loopCondition.Length == 1)
                {
                    throw new InvalidParameterException("Invalid loop statement. Operator should be <= or => or < or >");
                }

                if (!Regex.IsMatch(check_cmd[1], @"^[0-9]+$"))
                {
                    string variable_name = loopCondition[0].ToLower().Trim();
                    if (!variable.ContainsKey(variable_name))
                    {
                        throw new VariableNotFoundException("Variable: " + variable_name + " not found.");
                    }
                }
            }
            //catching the errors
            catch (InvalidCommandException e)
            {
                errors.Add(e.Message);
                return false;
            }
            catch (VariableNotFoundException e)
            {
                errors.Add(e.Message);
                return false;
            }
            catch (InvalidParameterException e)
            {
                errors.Add(e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// checking the method
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool check_method(string command)
        {
            try
            {
                if (!(command.Contains("(") && command.Contains(")")))
                {
                    throw new InvalidCommandException("Invalid Command Syntax");
                }
                string[] command_part = command.Split(new string[] { "(" }, StringSplitOptions.RemoveEmptyEntries);
                string inside_brackets = command_part[1];
                inside_brackets = Regex.Replace(inside_brackets, @"\s+", "");
                string cmd = command_part[0] + "(" + inside_brackets;
                string[] command_parts = cmd.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string parameter_inside_method = "";

                if (command_parts[0].Equals("method"))
                {
                    if (command_parts.Length == 3)
                    {
                        if (Regex.IsMatch(command_parts[1], @"^[a-zA-Z0-9]+$"))
                        {
                            string first_char = command_parts[1].Substring(0, 1);

                            if (Regex.IsMatch(first_char, @"^[a-zA-Z]+$"))
                            {
                                string check_param = command_parts[2];
                                check_param = Regex.Replace(check_param, @"\s+", "");
                                if (!check_param[0].Equals('(') || !check_param[check_param.Length - 1].Equals(')'))
                                {
                                    throw new InvalidMethodNameException("Invalid Method Command Syntax");
                                }
                                else
                                {
                                    parameter_inside_method = command_parts[2].Trim().Split('(', ')')[1];
                                    if (parameter_inside_method.Length > 0)
                                    {
                                        //check for alphanumeric or , inside ()
                                        for (int i = 1; i < check_param.Length - 1; i++)
                                        {
                                            if (!(Char.IsLetter(check_param[i]) || check_param[i].Equals(',')))
                                            {
                                                throw new InvalidParameterException("Invalid parameters");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                            }
                            else
                            {
                                throw new InvalidMethodNameException("Method name cannot start with number");
                            }
                        }
                        else
                        {
                            throw new InvalidMethodNameException("Method name cannot contain special characters");
                        }

                    }
                    else
                    {
                        throw new InvalidCommandException("Invalid Method Command Syntax");
                    }
                }
                else
                {
                    throw new InvalidCommandException("Invalid Command Name");
                }
            }
            //catching the errors
            catch (InvalidCommandException e)
            {
                errors.Add(e.Message);
                return false;
            }
            catch (InvalidMethodNameException e)
            {
                errors.Add(e.Message);
                return false;
            }
            catch (InvalidParameterException e)
            {
                errors.Add(e.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// check vadility of method call command
        /// checks if method exist or not
        /// </summary>
        /// <param name="command">method containing command</param>
        /// <returns>returns true if valid and false if invalid</returns>
        public bool check_methodcall(string command)
        {
            method_signature = Loop.getMethodSig();
            string methodname = command.Split('(')[0];
            methodname = Regex.Replace(methodname, @"\s+", "");
            string parameter_inside_method = command.Trim().Split('(', ')')[1];
            int parameter_count = 0;
            if (parameter_inside_method.Contains(','))
            {
                parameter_count = parameter_inside_method.Split(',').Length;
            }
            else
            {
                if (parameter_inside_method.Length > 0)
                {
                    parameter_count = 1;
                }
                else
                {
                    parameter_count = 0;
                }
            }

            string signature = methodname + "," + parameter_count;
            //check for method signature;
            try
            {
                if (method_signature.ContainsKey(signature))
                {
                    return true;
                }
                else
                {
                    throw new MethodNotFoundException("method not found");
                }

            }
            catch (MethodNotFoundException e)
            {
                errors.Add(e.Message);
                return false;
            }
        }
        /// <summary>
        /// arraylist to return the errors
        /// </summary>
        /// <returns>errors</returns>
        public ArrayList error_list()
        {
            return errors;
        }

        /// <summary>
        /// to valid the executed commands
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool Valid_execute_command(string command)
        {
            string valid_cmd = command;
            if (valid_cmd.Equals("run") || valid_cmd.Equals("reset") || valid_cmd.Equals("clear"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
