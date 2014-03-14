using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace DipsParse
{
    class Parser
    {
        public void parseFile(string fileName)
        {
            StreamReader myRead = new StreamReader(fileName);
            string line = "";
            StreamWriter myWrite = new StreamWriter("cleanedup.txt");
            while (line != null)
            {
                line = myRead.ReadLine();
                if (line != null)
                {
                    Console.WriteLine(line);

                    if (line.Contains(']'))
                    {
                        int index = line.IndexOf(']');
                        string cleanedup = line.Substring(line.IndexOf(']') + 2);
                        myWrite.WriteLine(cleanedup);
                        Console.WriteLine("Cleaned Up :" + cleanedup);

                        Regex re = new Regex(@"\d+");
                        Match m = re.Match(cleanedup);

                        if (m.Success)
                        {
                            parseAttack(cleanedup, " bites ");
                            parseAttack(cleanedup, " bite ");
                            parseAttack(cleanedup, " hits ");
                            parseAttack(cleanedup, " hit ");
                            parseAttack(cleanedup, " crushes ");
                            parseAttack(cleanedup, " crush ");
                            parseAttack(cleanedup, " slashes ");
                            parseAttack(cleanedup, " slash ");
                            parseAttack(cleanedup, " punches ");
                            parseAttack(cleanedup, " punch ");
                            parseAttack(cleanedup, " pierces ");
                            parseAttack(cleanedup, " pierce ");
                            parseAttack(cleanedup, " kicks ");
                            parseAttack(cleanedup, " kick ");

                            Console.WriteLine(string.Format("Damage :" + m.Value));
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                    }
                }
            }

            myRead.Close();
            Console.ReadLine();
        }

        private void parseAttack(string output, string type)
        {
            if (output.Contains(type))
            {
                int dealerindex = output.IndexOf(type);
                string attacker = output.Substring(0, dealerindex);
                Console.WriteLine("Attacker: " + attacker + ".");
            }
        }
        //public void dictionaryParse()
        //{
        //    //// attacker, m.Value, and defender
        //    //Dictionary<string, int> dictionary=
        //    //    new Dictionary<string, int>();
        //    //dictionary.Add(attacker, m.Value);


        //    {

        //    }

        //}
    }
}


