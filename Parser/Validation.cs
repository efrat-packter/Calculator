using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CR: Always format your code

namespace Parser
{
    public class Validation
    {
        private readonly Tokenizer _tokenizer;
        
        // Suggestion: you can use primary constructor if you like
        public Validation(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }
        // CR: Clean Code: methods used only in this class should be private
        public bool IsDigit(char c)
        {
            // CR: Clean Code: magic strings
            // CR: Clean Code: the if statement has a boolean expression, you can return it
            if (c >= '0' && c <= '9')
            {
                return true;
            }
            return false;
        }

        // CR: Clean Code: methods used only in this class should be private
        public bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        public bool IsValidInput(string str)
        {

            // CR: SOLID - OCP: too hard coded logic, this will for sure break in the future
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
                    //CR: unnecessary else
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