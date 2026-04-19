namespace ExpressionCalculation;

public class ExpressionFactory
{
    private readonly Dictionary<string, IExpressionCreator> _creators;

    public ExpressionFactory(IEnumerable<IExpressionCreator> creators)
    {
        _creators = creators.ToDictionary(c => c.Type);
    }

    public IExpression Create(string type, params object[] args)
    {
        return _creators[type].Create(args);
    }
}