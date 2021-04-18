using System;
using System.Collections.Generic;
using System.IO;
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
    public class CSVFile
    {
        /*
        * Method: CSVDE_Serialized
        * Purpose: read an csv file
        * Parameters:none
        * Returns: List<String> 
        */
        public List<String> CSVDE_Serialized()
        {
            List<string> Infix = new List<string>();
            using (var reader = new StreamReader("Project 2_INFO_5101.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Infix.Add(values[1]);
                }
            }
            
            return Infix;
        }
    }
}
