
//namespace ExpressionCalculation
//{
//    public class BinaryExpression<T> : IExpression<T>
//    {

//        private readonly IBinaryOperator<T> _operator;
//        private readonly IExpression<T> _left;
//        private readonly IExpression<T> _right;

//     public BinaryExpression(IBinaryOperator<T> op, IExpression<T> left, IExpression<T> right)
//        {
//            _operator = op;
//            _left = left;
//            _right = right;
//        }
//        public T CalculatValue()
//        {
//            var left = _left.CalculatValue();
//            var right = _right.CalculatValue();
//           return _operator.Execute(left, right);
//        }
//    }
//}

namespace ExpressionCalculation
{
    public class BinaryExpression : IExpression
    {

        private readonly IBinaryOperator _operator;
        private readonly IExpression _left;
        private readonly IExpression _right;

        public BinaryExpression(IBinaryOperator op, IExpression left, IExpression right)
        {
            _operator = op;
            _left = left;
            _right = right;
        }
        public double CalculateValue()
        {
            var left = _left.CalculateValue();
            var right = _right.CalculateValue();
            return _operator.Execute(left, right);
        }
    }
}

