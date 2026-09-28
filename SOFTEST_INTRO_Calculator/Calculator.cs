namespace SOFTEST_INTRO_Calculator;

public class Calculator

{
    public double Add(double a, double b) => a + b;

    public double Subtract(double a, double b) => a - b;

    public double Multiply(double a, double b) => a * b;

    // Starter version: complete the zero - divisor rule in section 5.

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Divisor cannot be zero.");
        }
        return a / b;
    }
    public long Factorial(int n)
    {
        if (n < 0 || n > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "Input must be between 0 and 20.");
        }

        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
    public double DoOperation(double a, double b, string op)

    {
        return op switch
        {
            "a" => Add(a, b),
            "s" => Subtract(a, b),
            "m" => Multiply(a, b),
            "d" => Divide(a, b),
            _ => throw new ArgumentException("Unknown operation.")
        };
    }

    public double TriangleArea(double height, double width)
    {
        if (height < 0 || width < 0)
        {
            throw new ArgumentOutOfRangeException("Dimensions cannot be negative.");
        }
        return (height * width) / 2.0;
    }

    public double CircleArea(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentOutOfRangeException("Radius cannot be negative.");
        }
        return Math.PI * Math.Pow(radius, 2);
    }

    public long UnknownFunctionA(int n, int r)
    {
        if (n < 0 || n > 20 || r < 0 || r > n)
        {
            throw new ArgumentOutOfRangeException("Inputs must satisfy 0 <= r <= n <= 20.");
        }
        
        // Permutations formula
        return Factorial(n) / Factorial(n - r);
    }

    public long UnknownFunctionB(int n, int r)
    {
        if (n < 0 || n > 20 || r < 0 || r > n)
        {
            throw new ArgumentOutOfRangeException("Inputs must satisfy 0 <= r <= n <= 20.");
        }
        
        // Combinations formula
        return Factorial(n) / (Factorial(r) * Factorial(n - r));
    }
    public double MTBF(double operatingTime, int failures)
    {
        if (operatingTime <= 0 || failures <= 0)
            throw new ArgumentException("Operating time and failures must be strictly positive.");
        
        return operatingTime / failures;
    }

    public double Availability(double mtbf, double mttr)
    {
        if (mtbf < 0 || mttr < 0)
            throw new ArgumentException("MTBF and MTTR cannot be negative.");
        if (mtbf + mttr == 0)
            throw new DivideByZeroException("Denominator (MTBF + MTTR) must be strictly positive.");
        
        return mtbf / (mtbf + mttr);
    }

    public double CurrentFailureIntensity(double lambda0, double v0, double tau)
    {
        if (lambda0 <= 0 || v0 <= 0)
            throw new ArgumentOutOfRangeException("lambda0 and v0 must be strictly positive.");
        if (tau < 0)
            throw new ArgumentOutOfRangeException("tau (execution time) cannot be negative.");
        
        return lambda0 * Math.Exp(-lambda0 * tau / v0);
    }

    public double ExpectedCumulativeFailures(double lambda0, double v0, double tau)
    {
        if (lambda0 <= 0 || v0 <= 0)
            throw new ArgumentOutOfRangeException("lambda0 and v0 must be strictly positive.");
        if (tau < 0)
            throw new ArgumentOutOfRangeException("tau (execution time) cannot be negative.");
        
        return v0 * (1 - Math.Exp(-lambda0 * tau / v0));
    }
}