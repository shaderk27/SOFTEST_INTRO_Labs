using SOFTEST_INTRO_Calculator;
using NUnit.Framework;
using System;

namespace SOFTEST_INTRO_Calculator.UnitTests;

public class CalculatorTests
{
    private Calculator _calculator = null!;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        double result = _calculator.Add(10, 20);
        Assert.That(result, Is.EqualTo(30));
    }

    [TestCase(0, 0, 0)]
    [TestCase(0, 5, 5)]
    [TestCase(-3, 8, 5)]
    [TestCase(0.1, 0.2, 0.3)]
    public void Add_RepresentativeInputs_ReturnsSum(double a, double b, double expected)
    {
        Assert.That(_calculator.Add(a, b), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(10, 4, 6)]
    [TestCase(5, 0, 5)]
    [TestCase(-5, -3, -2)]
    [TestCase(5.5, 2.2, 3.3)]
    public void Subtract_RepresentativeInputs_ReturnsDifference(double a, double b, double expected)
    {
        Assert.That(_calculator.Subtract(a, b), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(4, 5, 20)]
    [TestCase(5, 0, 0)]
    [TestCase(-4, 3, -12)]
    [TestCase(-2, -3, 6)]
    [TestCase(0.5, 0.4, 0.2)]
    public void Multiply_RepresentativeInputs_ReturnsProduct(double a, double b, double expected)
    {
        Assert.That(_calculator.Multiply(a, b), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(1, 2, 0.5)]
    [TestCase(0, 15, 0)]
    [TestCase(15, -3, -5)]
    public void Divide_RepresentativeInputs_ReturnsDivision(double a, double b, double expected)
    {
        Assert.That(_calculator.Divide(a, b), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(15, 0)]
    [TestCase(0, 0)]
    public void Divide_ZeroDivisor_ThrowsArgumentException(double a, double b)
    {
        Assert.That(() => _calculator.Divide(a, b), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void Factorial_Zero_ReturnsOne()
    {
        Assert.That(_calculator.Factorial(0), Is.EqualTo(1L));
    }

    [TestCase(1, 1L)]
    [TestCase(5, 120L)]
    [TestCase(20, 2432902008176640000L)]
    public void Factorial_ValidInputs_ReturnsExpectedResult(int n, long expected)
    {
        Assert.That(_calculator.Factorial(n), Is.EqualTo(expected));
    }

    [TestCase(-1)]
    [TestCase(21)]
    public void Factorial_OutOfBounds_ThrowsArgumentOutOfRangeException(int n)
    {
        Assert.That(() => _calculator.Factorial(n), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(3, 4, 6)]
    [TestCase(0, 5, 0)]
    [TestCase(5, 0, 0)]
    [TestCase(0, 0, 0)]
    public void TriangleArea_ValidInputs_ReturnsArea(double height, double width, double expected)
    {
        Assert.That(_calculator.TriangleArea(height, width), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-1, 5)]
    [TestCase(5, -1)]
    [TestCase(-2, -2)]
    public void TriangleArea_NegativeInputs_ThrowsException(double height, double width)
    {
        Assert.That(() => _calculator.TriangleArea(height, width), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(1, Math.PI)]
    [TestCase(0, 0)]
    public void CircleArea_ValidInputs_ReturnsArea(double radius, double expected)
    {
        Assert.That(_calculator.CircleArea(radius), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-1)]
    public void CircleArea_NegativeInput_ThrowsException(double radius)
    {
        Assert.That(() => _calculator.CircleArea(radius), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(5, 5, 120L)]
    [TestCase(5, 4, 120L)]
    [TestCase(5, 3, 60L)]
    public void UnknownFunctionA_ValidInputs_ReturnsPermutations(int n, int r, long expected)
    {
        Assert.That(_calculator.UnknownFunctionA(n, r), Is.EqualTo(expected));
    }

    [TestCase(5, 5, 1L)]
    [TestCase(5, 4, 5L)]
    [TestCase(5, 3, 10L)]
    public void UnknownFunctionB_ValidInputs_ReturnsCombinations(int n, int r, long expected)
    {
        Assert.That(_calculator.UnknownFunctionB(n, r), Is.EqualTo(expected));
    }

    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    [TestCase(21, 5)]
    public void UnknownFunctions_InvalidInputs_ThrowsException(int n, int r)
    {
        Assert.That(() => _calculator.UnknownFunctionA(n, r), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => _calculator.UnknownFunctionB(n, r), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(1000, 10, 100)]
    public void MTBF_ValidInputs_ReturnsResult(double operatingTime, int failures, double expected)
    {
        Assert.That(_calculator.MTBF(operatingTime, failures), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(0, 10)]
    [TestCase(1000, 0)]
    [TestCase(-100, 5)]
    public void MTBF_InvalidInputs_ThrowsArgumentException(double operatingTime, int failures)
    {
        Assert.That(() => _calculator.MTBF(operatingTime, failures), Throws.TypeOf<ArgumentException>());
    }

    [TestCase(90, 10, 0.9)]
    [TestCase(100, 0, 1.0)]
    public void Availability_ValidInputs_ReturnsResult(double mtbf, double mttr, double expected)
    {
        Assert.That(_calculator.Availability(mtbf, mttr), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-10, 10)]
    [TestCase(10, -5)]
    public void Availability_NegativeInputs_ThrowsArgumentException(double mtbf, double mttr)
    {
        Assert.That(() => _calculator.Availability(mtbf, mttr), Throws.TypeOf<ArgumentException>());
    }

    [TestCase(0, 0)]
    public void Availability_ZeroDenominator_ThrowsDivideByZeroException(double mtbf, double mttr)
    {
        Assert.That(() => _calculator.Availability(mtbf, mttr), Throws.TypeOf<DivideByZeroException>());
    }

    [TestCase(10, 100, 10, 3.6787944117)] 
    [TestCase(10, 100, 0, 10)]
    public void CurrentFailureIntensity_ValidInputs_ReturnsResult(double lambda0, double v0, double tau, double expected)
    {
        Assert.That(_calculator.CurrentFailureIntensity(lambda0, v0, tau), Is.EqualTo(expected).Within(1e-5));
    }

    [TestCase(0, 100, 10)]
    [TestCase(10, 0, 10)]
    [TestCase(10, 100, -5)]
    public void CurrentFailureIntensity_InvalidInputs_ThrowsArgumentOutOfRangeException(double lambda0, double v0, double tau)
    {
        Assert.That(() => _calculator.CurrentFailureIntensity(lambda0, v0, tau), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(10, 100, 10, 63.2120558829)] 
    [TestCase(10, 100, 0, 0)]
    public void ExpectedCumulativeFailures_ValidInputs_ReturnsResult(double lambda0, double v0, double tau, double expected)
    {
        Assert.That(_calculator.ExpectedCumulativeFailures(lambda0, v0, tau), Is.EqualTo(expected).Within(1e-5));
    }

    [TestCase(0, 100, 10)]
    [TestCase(10, 0, 10)]
    [TestCase(10, 100, -4)]
    public void ExpectedCumulativeFailures_InvalidInputs_ThrowsArgumentOutOfRangeException(double lambda0, double v0, double tau)
    {
        Assert.That(() => _calculator.ExpectedCumulativeFailures(lambda0, v0, tau), Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}