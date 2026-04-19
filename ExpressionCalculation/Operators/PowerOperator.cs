namespace ExpressionCalculation.Operators;

public class PowerOperator : IBinaryOperator
{
    public int Priority => 3;

    public string Symbol => "^";
    public bool IsRight =>true;

    public string OperatorType =>"Binary";

    public double Execute(double left, double right)
    {
        if (left < 0 && right % 1 != 0)
            throw new Exception("Math Error");

        return left == 0 &&right==0? throw new DivideByZeroException("Math Error")
            :Math.Pow(left, right);
        }
}
