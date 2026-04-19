
namespace ExpressionCalculation.Operators;

public class SquareOperator : IUnaryOperator
{
    public int Priority => 3;
    public string OperatorType => "Unary";
    public bool IsRight => false;

    public string Symbol => "√";

    public double Execute(double value)
    {
        return value < 0 ?
            throw new Exception("A root cannot be a negative number") :
         Math.Sqrt(value);
    }

}
