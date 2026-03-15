using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculation
{
    public class Expression : IMathElement
    {
        public OperatorTypes Operator { get; set; }
        public IMathElement Left { get; set; }
        public IMathElement Right { get; set; }
        Dictionary<OperatorTypes, Func<double, double, double>> operators;
        public Expression(OperatorTypes op, IMathElement left, IMathElement right)
        {
            Operator = op;
            Left = left;
            Right = right;
            operators = new Dictionary<OperatorTypes, Func<double, double, double>>
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
            return operators[Operator](left, right);
        }
    }
}
