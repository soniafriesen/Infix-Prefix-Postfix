using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
/*
 * Project: Project2_Group_2
 * Purpose: To take a csv file and use expression tress to evalute in prefix and psotfix
 * Coders: An Le, Dylan McNair, Sonia Friesen
 * Date: Due April 11, 2021 
 */
namespace Project2
{
    public class XMLExtension
    {
        /*
         * Method: xmlwriter
         * Purpose: to create a xml file
         * Parameters:int,List<string> x3, List<double>, List<bool>
         * Returns: none
         */
        public void xmlwriter(int sno, List<String> Infix, List<String> Prefix, List<String> Postfix, List<double> res, List<bool> match)
        {
            string filename = "Project 2_INFO_5101XML.xml";
            XmlTextWriter xmlwriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            xmlwriter.Formatting = Formatting.Indented;
            xmlwriter.WriteStartDocument();
            xmlwriter.WriteStartElement("root");
            for (int i = 0; i < Infix.Count-1; i++)
            {
                xmlwriter.WriteStartElement("elements");
                xmlwriter.WriteElementString("Sno", Convert.ToString(i + 1));
                xmlwriter.WriteElementString("infix", Infix[i+1]);
                xmlwriter.WriteElementString("prefix", Prefix[i]);
                xmlwriter.WriteElementString("postfix", Postfix[i]);
                xmlwriter.WriteElementString("evaluation", Convert.ToString(res[i]));
                xmlwriter.WriteElementString("comperision", Convert.ToString(match[i]));
                xmlwriter.WriteEndElement();
            }
            xmlwriter.WriteEndElement();
            xmlwriter.WriteEndDocument();
            xmlwriter.Flush();
            xmlwriter.Close();

            var p = new Process();
            p.StartInfo.FileName = filename;
            p.Start();
        }
    }
}
