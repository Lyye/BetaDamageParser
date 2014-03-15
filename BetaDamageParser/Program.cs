using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using BetaDamageParser;

namespace DipsParse
{
    class Program
    {
        static void Main(string[] args)
        {
            parserr a = new parserr();
            a.parseFile("sampleLog.txt");
        }
    }
}
