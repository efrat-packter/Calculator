using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculation
{
    public class DoubleValue:IValue
    {
        public double Value { get; }
        public DoubleValue(double value) => Value = value;
    }
}
