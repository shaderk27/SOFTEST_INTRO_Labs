using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;
using System;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorFactorialSteps
{
    private readonly CalculatorContext _context;

    // Inject the shared context
    public UsingCalculatorFactorialSteps(CalculatorContext context) => _context = context;

    [When("I enter {int} and press factorial")]
    public void WhenIEnterAndPressFactorial(int value)
    {
        // Reset the context state to prevent false positives
        _context.IntegerResult = null;
        _context.Error = null;

        try
        {
            _context.IntegerResult = _context.Calculator.Factorial(value);
        }
        catch (ArgumentOutOfRangeException error)
        {
            // Catch the specific exception expected from Lab 1
            _context.Error = error;
        }
    }
}