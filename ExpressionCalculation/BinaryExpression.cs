using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculation
{
    public class BinaryExpression : IExpression
    {
        public OperatorTypes Operator { get; set; }
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }
        Dictionary<OperatorTypes, Func<double, double, double>> funcForOperator;
        public BinaryExpression(OperatorTypes op,IExpression left,IExpression right)
        {
            Operator = op;
            Left = left;
            Right = right;
            funcForOperator = new Dictionary<OperatorTypes, Func<double, double, double>>
           {
               {OperatorTypes.Add,(x,y)=> (x+y) },
               {OperatorTypes.Sub,(x,y)=> (x-y) },
               {OperatorTypes.Mul,(x,y)=> (x*y) },
               {OperatorTypes.Div,(x,y)=> (x/y) }
           };
        }
        public double CalcValue()
        {
            double left = Left.CalcValue();
            double right = Right.CalcValue();
            return funcForOperator[Operator](left, right);
        }
    }
}
