namespace ExpressionCalculation;

public class NumberCreator : IExpressionCreator
{
    public string Type =>"Number";

    public IExpression Create(params object[] args)
    {
        return new Number(Convert.ToDouble(args[0])); 
    }
}
