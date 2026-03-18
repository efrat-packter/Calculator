using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Validation
    {
        private readonly Tokenizer _tokenizer;
        public Validation(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }
        public bool IsDigit(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return true;
            }
            return false;
        }

        public bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        public bool IsValidInput(string str)
        {

            bool status = true;
            int countParenthesis = 0;
            string[] tokens = _tokenizer.SplitForToken(str);
            foreach (string token in tokens)
            {
                if (IsDigit(token[0]))
                {
                    if (!status)
                    {
                        return false;
                    }
                    status = false;
                }
                else if (token == "(")
                {
                    if (!status)
                    {
                        return false;
                    }
                    countParenthesis++;
                }
                else if (token == ")")
                {
                    if (status)
                    {
                        return false;
                    }
                    else
                    {
                        if (countParenthesis > 0)
                            countParenthesis--;
                        else
                            return false;
                    }
                }
                else if (IsOperator(token[0]))
                {
                    if (status)
                    {
                        return false;
                    }
                    status = true;
                }
                else
                {
                    return false;
                }
            }
            return countParenthesis == 0 && !status;
        }
    }
}