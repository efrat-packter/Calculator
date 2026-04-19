using ExpressionCalculation;
using ExpressionCalculation.Operators;
namespace CalculationExpressionTest;

[TestClass]
public class ExpressionTest
{
    private readonly IBinaryOperator _add = new AddOperator();
    private readonly IBinaryOperator _sub = new SubOperator();
    private readonly IBinaryOperator _mul = new MulOperator();
    private readonly IBinaryOperator _div = new DivOperator(); 

    [TestMethod]
    public void Add_CorrectResult()
    {
        var left = new Number(2);
        var right = new Number(2);
        var expr = new BinaryExpression(_add, left, right);

        Assert.AreEqual(4, expr.CalculateValue());
    }
    [TestMethod]
    public void Subtract_CorrectResult()
    {
        var left = new Number(2);
        var right = new Number(2);
        var expr = new BinaryExpression(_sub, left, right);

        Assert.AreEqual(0, expr.CalculateValue());
    }
    [TestMethod]
    public void Multiply_CorrectResult()
    {
        var left = new Number(2);
        var right = new Number(2);
        var expr = new BinaryExpression(_mul, left, right);

        Assert.AreEqual(4, expr.CalculateValue());
    }
    [TestMethod]
    public void Divide_CorrectResult()
    {
        var left = new Number(2);
        var right = new Number(2);
        var expr = new BinaryExpression(_div, left, right);

        Assert.AreEqual(1, expr.CalculateValue());
    }
    [TestMethod]
    public void CalcExpression_correctResult()
    {
        var left = new Number(2);
        var right = new Number(2);
        var expression1 = new BinaryExpression(_add, left, right);
        var expression2 = new BinaryExpression(_add, left, expression1);
        Assert.AreEqual(6, expression2.CalculateValue());
    }
}