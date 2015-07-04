using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create user and let her compute
            User user = new User();
            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);
            // Undo 4 commands
            user.Undo(4);
            // Redo 3 commands
            user.Redo(3);
            // Wait for user
            Console.ReadKey();
        }
    }
}


/// <summary>
/// The 'Command' abstract class
/// </summary>
abstract class Command
{
    public abstract void Execute();
    public abstract void UnExecute();
}


/// <summary>
/// The 'ConcreteCommand' class
/// </summary>
class CalculatorCommand : Command
{
    private char operation;
    private int operand;
    private Calculator calculator;

    // Constructor
    public CalculatorCommand(Calculator calculator, char operation, int operand)
    {
        this.calculator = calculator;
        this.operation = operation;
        this.operand = operand;
    }

    // Gets operator
    public char Operator { set { operation = value; }}

    // Get operand
    public int Operand {set { operand = value; } }

    // Execute new command
    public override void Execute()
    {
        calculator.Operation(operation, operand);
    }

    // Unexecute last command
    public override void UnExecute()
    {
        calculator.Operation(Undo(operation), operand);
    }

    // Returns opposite operator for given operator
    private char Undo(char operation)
    {
        switch (operation)
        {
            case '+': return '-';
            case '-': return '+';
            case '*': return '/';
            case '/': return '*';
            default: throw new ArgumentException("unknown operation");
        }

    }

}


/// <summary>
/// The 'Receiver' class
/// </summary>
class Calculator
{
    private int curValue = 0;

    public void Operation(char operation, int operand)
    {
        switch (operation)
        {
            case '+': curValue += operand; break;
            case '-': curValue -= operand; break;
            case '*': curValue *= operand; break;
            case '/': curValue /= operand; break;
        }

        Console.WriteLine("Current value = {0,3} (operation {1} {2})", curValue, operation, operand);

    }

}



/// <summary>
/// The 'Invoker' class
/// </summary>
class User
{
    // Initializers
    private Calculator calculator = new Calculator();
    private List<Command> commandsList = new List<Command>();
    private int current = 0;


    public void Redo(int levels)
    {
        Console.WriteLine("\n---- Redo {0} levels ", levels);

        // Perform redo operations
        for (int i = 0; i < levels; i++)
        {
            if (current < commandsList.Count - 1)
            {
                Command command = commandsList[current++] as Command; 
                command.Execute();
            }
        }

    }


    public void Undo(int levels)
    {
        Console.WriteLine("\n---- Undo {0} levels ", levels);
        // Perform undo operations
        for (int i = 0; i < levels; i++)
        {
            if (current > 0)
            {
                Command command = commandsList[--current] as Command;
                command.UnExecute();
            }
        }

    }


    public void Compute(char operation, int operand)
    {
        // Create command operation and execute it
        Command command = new CalculatorCommand(calculator, operation, operand);
        command.Execute();

        // Add command to undo list
        commandsList.Add(command);
        current++;
    }

}






