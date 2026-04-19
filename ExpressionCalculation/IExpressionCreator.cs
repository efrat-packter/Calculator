namespace ExpressionCalculation;

public interface IExpressionCreator
{
    string Type { get; }
    IExpression Create(params object[] args);
}
