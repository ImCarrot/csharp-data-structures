using System;
using System.Collections.Generic;

namespace csharp_data_structures.Stacks
{
    public class PostfixCalculator
    {

        private readonly ICollection<string> operators = new HashSet<string>() {"+", "-", "*" };

        private int parseValue(int left, int right, string op)
        {
            switch (op)
            {
                case "+":
                    return left + right;
                case "-":
                    return left - right;
                case "*":
                    return left * right;
                default:
                    return 0;
            }
        }

        public int calculate(string postfix)
        {

            string[] characters = postfix.Split(" ");

            Stack<int> processStack = new Stack<int>();

            foreach (var token in characters)
            {

                if (char.IsDigit(char.Parse(token)))
                    processStack.Push(int.Parse(token.ToString()));
                
                else if (!operators.Contains(token))
                    throw new InvalidOperationException("The input can only contain numbers or operators (+, -, *)");
                
                else
                {
                    int rightOperand = processStack.Pop();
                    int leftOperand = processStack.Pop();

                    int result = parseValue(leftOperand, rightOperand, token.ToString());

                    processStack.Push(result);

                }

            }

            return processStack.Pop();
        }

    }
}
