using ExpressionCalculation;
using Parser;

namespace calculator
{
    public class Bootstrapper
    {

        public CalculatorApp Intilize()
        {
            ExpressionFactory factory = new ExpressionFactory();
            Tokenizer tokenizer = new Tokenizer();
            Validation validation = new Validation(tokenizer);
            Parse parse = new Parse(factory, validation);
            IWriter  writer = new Writer();
            IReader reader = new Reader();  

            return new CalculatorApp(tokenizer, validation, parse,writer,reader);
        }
    }
}
