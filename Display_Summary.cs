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
    public class Display_Summary
    {
        // Fuction to Display the Report
        public void Display_Console(int sno, String Infix, String Prefix, String Postfix, double prefix_res, double postfix_res, bool match)
        {
            Console.WriteLine("| {0,4}| {1,20}|  {2,15}|  {3,15}|  {4,10}| {5,10}|  {6,5}|", sno, Infix, Postfix, Prefix, prefix_res, postfix_res, match);
        }
    }
}
