using System.Linq.Expressions;

namespace ExpressionCalculation;

public class UnaryCreator : IExpressionCreator
{
    public string Type =>"Unary";

    public IExpression Create(params object[] args)
    {
        var op = (IUnaryOperator)args[0];
        var value = (IExpression)args[1];

        return new UnaryExpression(op,value);
    }
}
