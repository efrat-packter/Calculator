using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculation
{
    public class Number : IMathElement
    {
        public double Value { get; private set; }
        public Number(double value)
        {
            this.Value = value;
        }
        public double CalcValue()
        {
            return Value;
        }
    }
}
