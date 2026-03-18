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
            BinaryExpression expr = new BinaryExpression(OperatorTypes.Add, left, right);

            Assert.AreEqual(4, expr.CalcValue());
        }
        [TestMethod]
        public void Subtract_CorrectResult()
        {
            Number left = new Number(2);
            Number right = new Number(2);
            BinaryExpression expr = new BinaryExpression(OperatorTypes.Sub, left, right);

            Assert.AreEqual(0, expr.CalcValue());
        }
        [TestMethod]
        public void Multiply_CorrectResult()
        {
            Number left = new Number(2);
            Number right = new Number(2);
            BinaryExpression expr = new BinaryExpression(OperatorTypes.Mul, left, right);

            Assert.AreEqual(4, expr.CalcValue());
        }
        [TestMethod]
        public void Divide_CorrectResult()
        {
            Number left = new Number(2);
            Number right = new Number(2);
            BinaryExpression expr = new BinaryExpression(OperatorTypes.Div, left, right);

            Assert.AreEqual(1, expr.CalcValue());
        }
        [TestMethod]
        public void CalcExpression_correctResult()
        {
            Number left = new Number(2);
            Number right = new Number(2);
            BinaryExpression expression1 = new BinaryExpression(OperatorTypes.Add, left, right);
            BinaryExpression expression2 = new BinaryExpression(OperatorTypes.Add, left, expression1);
            Assert.AreEqual(6, expression2.CalcValue());
        }
    }
}