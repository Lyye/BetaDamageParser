using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using BetaDamageParser;
using System.Windows.Forms;

namespace DipsParse
{
    class Program
    {
        static void Main(string[] args)
        {
            parserr a = new parserr();
            a.parseFile("C:/games/Everquest server stuff/Underfoot/everquest/Logs/eqlog_Somemage_PEQTGC.txt");
            //a.parseFile("eqlog_Somemonk_PEQTGC.txt");
        }
    }
}
