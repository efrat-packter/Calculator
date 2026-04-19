namespace ExpressionCalculation.Operators;

public class SubOperator : IBinaryOperator
{
    public int Priority => 1;
    public string OperatorType => "Binary";
    public bool IsRight => false;

    public string Symbol => "-";

    public double Execute(double left, double right)
    {
        return left-right;
    }
}
