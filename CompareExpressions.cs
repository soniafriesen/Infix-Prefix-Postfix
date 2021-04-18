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
    class CompareExpressions : IComparer<double>
    {
        //returns 1 or 0 if the expression is true or false
        public int Compare(double x, double y)
        {
            return Convert.ToInt32(x.Equals(y));
        }
    }
}
