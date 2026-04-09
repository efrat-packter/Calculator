
namespace ExpressionCalculation.Operators;

public class DivOperator : IBinaryOperator
{
    public int Priority => 2;

    public string OperatorType => "Binary";

    public string Symbol => "/";

    public double Execute(double left, double right)
    {
        return right == 0 ? throw new DivideByZeroException("cannot divide by zero") :left / right;
    }
}
