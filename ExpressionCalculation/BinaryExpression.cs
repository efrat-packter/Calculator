
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
        // CR: SOLID - OCP: you are coupled to double. what if we want to have different types?
        //  you have an abstraction, IExpression, but you still use double
        // CR: SOLID - OCP: you are coupled to double. what if we want to have different types?
        //  you have an abstraction, IExpression, but you still use double
        //funcForOperator = new Dictionary<OperatorTypes, Func<double, double, double>>
        //   {
        //       {OperatorTypes.Add,(x, y)=> (x+y) },
        //       {OperatorTypes.Sub,(x, y)=> (x-y) },
        //       { OperatorTypes.Mul,(x, y) => (x * y) },
        //       { OperatorTypes.Div,(x, y) => y == 0 ? throw new DivideByZeroException("cannot divide by zero") : (x / y) }
        //   };
public double CalculatValue()
        {
            var left = _left.CalculatValue();
            var right = _right.CalculatValue();
            return _operator.Execute(left, right);
        }
    }
}

