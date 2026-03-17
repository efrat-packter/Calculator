using ExpressionCalculation;
using Parser;

namespace calculator
{
    public class Bootstrapper
    {


        private ExpressionFactory _factory;
        private Tokenizer _tokenizer;
        private Validation _validation;
        private Parse _parse;
        public void Run()
        {
            _factory = new ExpressionFactory();
            _tokenizer = new Tokenizer();
            _validation = new Validation(_tokenizer);
            _parse = new Parse(_factory, _validation);

            string inputExpression = "";
            while (true)
            {
                Console.WriteLine("enter a expressoin");
                inputExpression = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputExpression) || !_validation.IsValidInput(inputExpression))
                {
                    Console.WriteLine("invalid expression, try again");
                    continue;
                }
                break;
            }


            string[] str = _tokenizer.SplitForToken(inputExpression);

            IExpression expression = _parse.InfixToPrefix(str);
            Console.WriteLine(expression.CalcValue());
        }
    }
}
