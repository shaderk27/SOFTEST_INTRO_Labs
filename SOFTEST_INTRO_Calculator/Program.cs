using System.Globalization;
using SOFTEST_INTRO_Calculator;

var calculator = new Calculator();

Console.WriteLine("Calculator operations:");
Console.WriteLine("a=add, s=subtract, m=multiply, d=divide, f=factorial");

Console.Write("Operation: ");
string op = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

try
{
    // Branch for the single-input Factorial operation
    if (op == "f")
    {
        Console.Write("Number: ");
        string numStr = Console.ReadLine() ?? "";

        // Using int.TryParse prevents silent truncation of decimals
        if (!int.TryParse(numStr, out int n))
        {
            Console.WriteLine("Enter a valid integer.");
            return;
        }

        long result = calculator.Factorial(n);
        Console.WriteLine("Result: " + result);
    }
    // Branch for the two-input Double operations
    else
    {
        Console.Write("First number: ");
        string first = Console.ReadLine() ?? "";

        Console.Write("Second number: ");
        string second = Console.ReadLine() ?? "";

        bool firstOk = double.TryParse(
            first,
            NumberStyles.Float,
            CultureInfo.InvariantCulture,
            out double a);

        bool secondOk = double.TryParse(
            second,
            NumberStyles.Float,
            CultureInfo.InvariantCulture,
            out double b);

        if (!firstOk || !secondOk ||
            !double.IsFinite(a) || !double.IsFinite(b))
        {
            Console.WriteLine("Enter finite numbers; use . for decimals.");
            return;
        }

        double result = calculator.DoOperation(a, b, op);
        string text = result.ToString(CultureInfo.InvariantCulture);
        Console.WriteLine("Result: " + text);
    }
}
// Catch the specific exception thrown by Factorial
catch (ArgumentOutOfRangeException error) 
{
    Console.WriteLine(error.Message);
}
// Catch the exception thrown by Divide or DoOperation
catch (ArgumentException error)
{
    Console.WriteLine(error.Message);
}