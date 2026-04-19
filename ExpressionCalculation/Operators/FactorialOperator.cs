namespace ExpressionCalculation.Operators;
using MathNet.Numerics;

public class FactorialOperator : IUnaryOperator
{
    public int Priority => 4;

    public string Symbol => "!";

    public string OperatorType => "Unary";

    public bool IsRight =>true;

    public double Execute(double value)
    {return value < 0||value%1!=0 ? throw new Exception("Math Error") :
      Math.Round(SpecialFunctions.Gamma(value + 1), 10);
    }
}
