using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Diagnostics;
/*
 * Project: Project2_Group_2
 * Purpose: To take a csv file and use expression tress to evalute in prefix and psotfix
 * Coders: An Le, Dylan McNair, Sonia Friesen
 * Date: Due April 11, 2021 
 */
namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            //generic lists to store data
            List<String> Infix = new List<string>();
            List<String> Prefix = new List<string>();
            List<String> Postfix = new List<string>();
            List<double> prefix_res = new List<double>();
            List<double> postfix_res = new List<double>();
            List<bool> match = new List<bool>();

            // csv reader   
            CSVFile csvreader = new CSVFile();
            Infix = csvreader.CSVDE_Serialized();
            ExpressionConverter converter = new ExpressionConverter();
            ExpressionEvaluation evaluator = new ExpressionEvaluation();
            CompareExpressions comparer = new CompareExpressions();
            XMLExtension xmlgenerator = new XMLExtension();
            Display_Summary display = new Display_Summary();
           
           
            // Infix to prefi and postfix convertion
            for (int i=1; i<Infix.Count; i++)
            {
                Prefix.Add(converter.Infix_to_Prefix(Infix[i]));
                Postfix.Add(converter.Infix_to_Postfix(Infix[i]));
            }
            // evaluation of prefix and postfix
            for(int i=0; i < Infix.Count-1; i++)
            {
                prefix_res.Add(evaluator.evaluate_Prefix(Prefix[i]));
                postfix_res.Add(evaluator.evaluate_Postfix(Postfix[i]));
            }
            // comperision f evaluation
            for (int i = 0; i < Infix.Count-1; i++)
            {
                match.Add(Convert.ToBoolean(comparer.Compare(prefix_res[i], postfix_res[i])));
            }
            // display on console interface
            Console.WriteLine("=======================================================================================================");
            Console.WriteLine("*                                    Summary Report                                                   *");
            Console.WriteLine("=======================================================================================================\n");
            Console.WriteLine("|  Sno|                Infix|          Postfix|           Prefix|  Prefix Res|Postfix Res|  Match|");
            for (int i = 0; i < Infix.Count-1; i++)
            {
                display.Display_Console(i+1, Infix[i+1], Prefix[i], Postfix[i], prefix_res[i], prefix_res[i], match[i]);
            }

            // Xml Generator
            xmlgenerator.xmlwriter(Infix.Count-1, Infix, Prefix, Postfix, postfix_res,match);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            System.Environment.Exit(0);
        }
    }
}
