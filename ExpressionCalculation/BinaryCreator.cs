namespace ExpressionCalculation;

public class BinaryCreator : IExpressionCreator
{
    public string Type => "Binary";

    public IExpression Create(params object[] args)
    {
        var op = (IBinaryOperator)args[0];
        var left = (IExpression)args[1];
        var right = (IExpression)args[2];

        return new BinaryExpression(op, left, right);
    }
}
