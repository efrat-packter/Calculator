
namespace ExpressionCalculation.Operators;

public class MulOperator : IBinaryOperator
{
    public int Priority => 2;
    public string OperatorType => "Binary";

    public string Symbol => "*";

    public double Execute(double left, double right)
    {
        return left * right;
    }   
}
