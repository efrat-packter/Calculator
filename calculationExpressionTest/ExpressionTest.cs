using ExpressionCalculation;
namespace calculationExpressionTest
{
    [TestClass]
    public class ExpressionTest
    {


        [TestMethod]
        public void Add_CorrectResult()
        {
            Number left = new Number(2);
            Number right = new Number(2);
            Expression expr = new Expression(OperatorTypes.Add, left, right);

            Assert.AreEqual(4, expr.ValueCalc());
        }
        [TestMethod]
        public void Subtract_CorrectResult()
        {
            Number left = new Number(2);
            Number right = new Number(2);
            Expression expr = new Expression(OperatorTypes.Subtract, left, right);

            Assert.AreEqual(0, expr.ValueCalc());
        }
        [TestMethod]
        public void Multiply_CorrectResult()
        {
            Number left = new Number(2);
            Number right = new Number(2);
            Expression expr = new Expression(OperatorTypes.Multiply, left, right);

            Assert.AreEqual(4, expr.ValueCalc());
        }
        [TestMethod]
        public void Divide_CorrectResult()
        {
            Number left = new Number(2);
            Number right = new Number(2);
            Expression expr = new Expression(OperatorTypes.Divide, left, right);

            Assert.AreEqual(1, expr.ValueCalc());
        }
        [TestMethod]
        public void CalcExpression_correctResult()
        {
            Number left = new Number(2);
            Number right = new Number(2);
            Expression expression1 = new Expression(OperatorTypes.Add, left, right);
            Expression expression2 = new Expression(OperatorTypes.Add, left, expression1);
            Assert.AreEqual(6, expression2.ValueCalc());
        }
    }
}