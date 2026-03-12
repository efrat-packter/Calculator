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
               {OperatorTypes.Subtract,(x,y)=> (x-y) },
               {OperatorTypes.Multiply,(x,y)=> (x*y) },
               {OperatorTypes.Divide,(x,y)=> (x/y) }
           };
        }
        public double ValueCalc()
        {
            double left = Left.ValueCalc();
            double right = Right.ValueCalc();
            return operators[Operator](left, right);
        }
    }
}
