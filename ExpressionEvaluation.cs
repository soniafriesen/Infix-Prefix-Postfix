using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class ExpressionEvaluation
    {
       

        // Function to check if given character is an operand or not.
        private static Boolean isOperand(char c)
        {
            // If the character is a digit then it must be an operand
            if (c >= 48 && c <= 57)
                return true;
            else
                return false;
        }

        //expression trees
        private static Expression<Func<double, double, double>> addition = (num1, num2) => num1 + num2;
        private Func<double, double, double> add = addition.Compile();

        private static Expression<Func<double, double, double>> subtraction = (num1, num2) => num1 - num2;
        private Func<double, double, double> sub = subtraction.Compile();

        private static Expression<Func<double, double, double>> multtiplication = (num1, num2) => num1 * num2;
        private Func<double, double, double> mul = multtiplication.Compile();

        private static Expression<Func<double, double, double>> division = (num1, num2) => num1 / num2;
        private Func<double, double, double> div = division.Compile();

        // Fuction to evaluate value of  a prefix expression 
        public double evaluate_Prefix(String exprsn)
        {
            Stack<Double> Stack = new Stack<Double>();

            for (int j = exprsn.Length - 1; j >= 0; j--)
            {

                // Push operand to Stack
                // To convert exprsn[j] to digit subtract
                // '0' from exprsn[j].
                if (isOperand(exprsn[j]))
                    Stack.Push((double)(exprsn[j] - 48));

                else
                {

                    // Operator encountered
                    // Pop two elements from Stack
                    double o1 = Stack.Peek();
                    Stack.Pop();
                    double o2 = Stack.Peek();
                    Stack.Pop();

                    // Use switch case to operate on o1
                    // and o2 and perform o1 O o2.
                    switch (exprsn[j])
                    {
                        case '+':
                            Stack.Push(add(o1 , o2));
                            break;
                        case '-':
                            Stack.Push(sub(o1 , o2));
                            break;
                        case '*':
                            Stack.Push(mul(o1 , o2));
                            break;
                        case '/':
                            Stack.Push(div(o1 , o2));
                            break;
                    }
                }
            }

            return Stack.Peek();
        }

        // Fuction to evaluate value of  a postfix expression 
        public double evaluate_Postfix(string exprsn)
        {
            string v, answer;
            v = exprsn;
            Stack i = new Stack();
            double a, b, ans;
            for (int j = 0; j < v.Length; j++)
            //'v.Length' means length of the string
            {
                String c = v.Substring(j, 1);
                if (c.Equals("*"))
                {
                    String sa = (String)i.Pop();
                    String sb = (String)i.Pop();
                    a = Convert.ToDouble(sb);
                    b = Convert.ToDouble(sa);
                    ans = a * b;
                    i.Push(ans.ToString());

                }
                else if (c.Equals("/"))
                {
                    String sa = (String)i.Pop();
                    String sb = (String)i.Pop();
                    a = Convert.ToDouble(sb);
                    b = Convert.ToDouble(sa);
                    ans = a / b;
                    i.Push(ans.ToString());
                }
                else if (c.Equals("+"))
                {
                    String sa = (String)i.Pop();
                    String sb = (String)i.Pop();
                    a = Convert.ToDouble(sb);
                    b = Convert.ToDouble(sa);
                    ans = a + b;
                    i.Push(ans.ToString());

                }
                else if (c.Equals("-"))
                {
                    String sa = (String)i.Pop();
                    String sb = (String)i.Pop();
                    a = Convert.ToDouble(sb);
                    b = Convert.ToDouble(sa);
                    ans = a - b;
                    i.Push(ans.ToString());

                }
                else
                {
                    i.Push(v.Substring(j, 1));
                }
            }
            answer = (String)i.Pop();
            return Convert.ToDouble(answer);
        }
    }
}
