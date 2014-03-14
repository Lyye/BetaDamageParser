using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace DipsParse
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser a = new Parser();
            a.parseFile("sampleLog.txt");
        }
    }
}
