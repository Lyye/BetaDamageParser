using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace BetaDamageParser
{
    class parserr
    {
        string attacker;
        string defender;
        int dam;
        string damage;
        string noDamageText;
        string noTimeStamp;
        string withTimeStamp;
        string[] attackArray;
        string forBox;

        public void parseFile(string fileName)
        {
            StreamReader myRead = new StreamReader(fileName);
            string[] attackArray = File.ReadLines("attacktypes.txt").ToArray();
            Dictionary<string, int> dDamTable = new Dictionary<string, int>();
            string withTimeStamp = "";
            while (withTimeStamp != null)
            {
                withTimeStamp = myRead.ReadLine();
                if (withTimeStamp != null)
                {
                    //for debugging
                    //Console.WriteLine(withTimeStamp);

                    for (int i = 0; i < attackArray.Length; i++)
                    {
                        if (withTimeStamp.Contains(attackArray[i]))
                        {
                            if (!withTimeStamp.Contains("hits them") && !withTimeStamp.Contains(" miss"))
                                {
                                    string noTimeStamp = withTimeStamp.Substring(withTimeStamp.IndexOf(']') + 2);

                                    int notAttackerText = noTimeStamp.IndexOf(attackArray[i]);
                                    if (notAttackerText > 0)
                                        attacker = noTimeStamp.Substring(0, notAttackerText);
                                    int damageText = noTimeStamp.IndexOf(" point");
                                    if (damageText > 0)
                                        noDamageText = noTimeStamp.Substring(0, damageText);
                                    string damage = noDamageText.Substring(noDamageText.LastIndexOf(' ') + 1);
                                    string defenderCleanOne = noDamageText.Substring(noDamageText.IndexOf(attackArray[i]) + 1);
                                    string defenderCleanTwo = defenderCleanOne.Substring(defenderCleanOne.IndexOf(' ') + 1);
                                    int defednerIndex = defenderCleanTwo.IndexOf(" for ");
                                    if (defednerIndex > 0)
                                        defender = defenderCleanTwo.Substring(0, defednerIndex);
                                    int dam = Convert.ToInt32(damage);

                                    if (!dDamTable.ContainsKey(attacker))
                                    {
                                        dDamTable.Add(attacker, dam);
                                    }
                                    else
                                    {
                                        dDamTable[attacker] += dam;
                                    }
                                    foreach (KeyValuePair<string, int> kv in dDamTable)
                                    {
                                        Console.WriteLine("Key = {0}, Value = {1}", kv.Key, kv.Value);
                                    }

                                    Console.WriteLine("No Time Stamp: " + noTimeStamp + ".");
                                    Console.WriteLine("Attacker: " + attacker + ".");
                                    Console.WriteLine("Damage: " + dam + ".");
                                    Console.WriteLine("Defender: " + defender + ".");
                                    //Console.WriteLine("other1: " + defenderCleanOne + ".");
                                    //Console.WriteLine("other2: " + defenderCleanTwo + ".");
                                    Console.WriteLine("");
                            }
                        }
                    }
                }
            }
            foreach (KeyValuePair<string, int> kv in dDamTable)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kv.Key, kv.Value);
            }
            Console.ReadLine();
        }
    }
}
