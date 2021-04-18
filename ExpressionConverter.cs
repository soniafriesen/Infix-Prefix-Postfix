using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Project: Project2_Group_2
 * Purpose: To take a csv file and use expression tress to evalute in prefix and psotfix
 * Coders: An Le, Dylan McNair, Sonia Friesen
 * Date: Due April 11, 2021 
 */
namespace Project2
{
    public class ExpressionConverter
    {
        // Function to check if given character is an operator or not.
        private static bool isOperator(char c)
        {
            return (!(c >= 'a' && c <= 'z') &&
                    !(c >= '0' && c <= '9') &&
                    !(c >= 'A' && c <= 'Z'));
        }

        // Function to find priority of given operator.
        private static int getPriority(char C)
        {
            if (C == '-' || C == '+')
                return 1;
            else if (C == '*' || C == '/')
                return 2;
            else if (C == '^')
                return 3;
            return 0;
        }
        private static int Prec(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }
        // Function to convert INFIX to PREFIX Expression
        public String Infix_to_Prefix(String infix)
        {
            // stack for operators.
            Stack<char> operators = new Stack<char>();

            // stack for operands.
            Stack<String> operands = new Stack<String>();

            for (int i = 0; i < infix.Length; i++)
            {

                // If current character is an  opening bracket, then push into the operators stack.
                if (infix[i] == '(')
                {
                    operators.Push(infix[i]);
                }
                // If current character is a closing bracket, then pop from both stacks and push result
                // in operands stack until matching opening bracket is not found.
                else if (infix[i] == ')')
                {
                    while (operators.Count != 0 && operators.Peek() != '(')
                    {

                        // operand 1
                        String op1 = operands.Peek();
                        operands.Pop();

                        // operand 2
                        String op2 = operands.Peek();
                        operands.Pop();

                        // operator
                        char op = operators.Peek();
                        operators.Pop();

                        // Add operands and operator in form operator + operand1 + operand2.
                        String tmp = op + op2 + op1;
                        operands.Push(tmp);
                    }

                    // Pop opening bracket from stack.
                    operators.Pop();
                }

                // If current character is an operand then push it into operands stack.
                else if (!isOperator(infix[i]))
                {
                    operands.Push(infix[i] + "");
                }

                // If current character is an operator, then push it into operators stack after popping
                // high priority operators from operators stack and pushing result in operands stack.
                else
                {
                    while (operators.Count != 0 && getPriority(infix[i]) <= getPriority(operators.Peek()))
                    {

                        String op1 = operands.Peek();
                        operands.Pop();

                        String op2 = operands.Peek();
                        operands.Pop();

                        char op = operators.Peek();
                        operators.Pop();

                        String tmp = op + op2 + op1;
                        operands.Push(tmp);
                    }

                    operators.Push(infix[i]);
                }
            }

            // Pop operators from operators stack until it is empty and
            // operation in add result of each pop operands stack.
            while (operators.Count != 0)
            {
                String op1 = operands.Peek();
                operands.Pop();

                String op2 = operands.Peek();
                operands.Pop();

                char op = operators.Peek();
                operators.Pop();

                String tmp = op + op2 + op1;
                operands.Push(tmp);
            }

            // Final prefix expression is present in operands stack.
            return operands.Peek();
        }

        // Function to convert INFIX to POSTFIX Expression
        public String Infix_to_Postfix(String Infix)
        {
            // initializing empty String for result 
            string Postfix = "";

            // initializing empty stack 
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < Infix.Length; ++i)
            {
                char c = Infix[i];

                // If the scanned character is an  operand, add it to output. 
                if (char.IsLetterOrDigit(c))
                {
                    Postfix += c;
                }

                // If the scanned character is an '(', push it to the stack. 
                else if (c == '(')
                {
                    stack.Push(c);
                }

                //  If the scanned character is an ')',  pop and output from the stack   until an '(' is encountered. 
                else if (c == ')')
                {
                    while (stack.Count > 0 &&
                            stack.Peek() != '(')
                    {
                        Postfix += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        return "Invalid Expression"; // invalid expression
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else // an operator is encountered
                {
                    while (stack.Count > 0 && Prec(c) <=
                                      Prec(stack.Peek()))
                    {
                        Postfix += stack.Pop();
                    }
                    stack.Push(c);
                }

            }

            // pop all the operators from the stack 
            while (stack.Count > 0)
            {
                Postfix += stack.Pop();
            }

            return Postfix;

        }
    }
}
