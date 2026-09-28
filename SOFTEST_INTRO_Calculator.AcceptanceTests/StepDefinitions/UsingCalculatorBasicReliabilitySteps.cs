using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
    private readonly CalculatorContext _context;

    public UsingCalculatorBasicReliabilitySteps(CalculatorContext context)
    {
        _context = context;
    }

    [When("I enter initial intensity {double}, total failures {double}, and execution time {double} to calculate current intensity")]
    public void WhenIEnterValuesForCurrentIntensity(double lambda0, double v0, double tau)
    {
        _context.Result = _context.Calculator.CurrentFailureIntensity(lambda0, v0, tau);
    }

    [When("I enter initial intensity {double}, total failures {double}, and execution time {double} to calculate expected failures")]
    public void WhenIEnterValuesForExpectedFailures(double lambda0, double v0, double tau)
    {
        _context.Result = _context.Calculator.ExpectedCumulativeFailures(lambda0, v0, tau);
    }
}