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
        string player;
        string noDamageText;
        string deathByOther;
        string deathByYou;

        public void parseFile(string fileName)
        {
            string[] attackArray = File.ReadLines("attacktypes.txt").ToArray();
            string fileNameCleanOne = fileName.Substring(fileName.IndexOf('_') + 1);
            int fileNameIndex = fileNameCleanOne.IndexOf("_");
            if (fileNameIndex > 0)
                player = fileNameCleanOne.Substring(0, fileNameIndex);
            Dictionary<string, int> dDamTable = new Dictionary<string, int>();
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            using (var reader = new StreamReader(fs))
            {
                while (true)
                {
                    var withTimeStamp = reader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(withTimeStamp))
                    {
                        for (int i = 0; i < attackArray.Length; i++)
                        {
                            if (withTimeStamp.Contains(attackArray[i]))
                            {
                                #region Damage Text Parser
                                if (!withTimeStamp.Contains("hits them") && !withTimeStamp.Contains(" miss") && !withTimeStamp.Contains("is hit"))
                                {
                                    withTimeStamp = withTimeStamp.Replace("You", player);
                                    withTimeStamp = withTimeStamp.Replace("YOU", player);
                                    string noTimeStamp = withTimeStamp.Substring(withTimeStamp.IndexOf(']') + 2);

                                    int notAttackerText = noTimeStamp.IndexOf(attackArray[i]);
                                    if (notAttackerText > 0)
                                        attacker = noTimeStamp.Substring(0, notAttackerText);

                                    int damageText = noTimeStamp.IndexOf(" point");
                                    if (damageText > 0)
                                        noDamageText = noTimeStamp.Substring(0, damageText);
                                    string damage = noDamageText.Substring(noDamageText.LastIndexOf(' ') + 1);
                                    int dam = Convert.ToInt32(damage);

                                    string defenderCleanOne = noDamageText.Substring(noDamageText.IndexOf(attackArray[i]) + 1);
                                    string defenderCleanTwo = defenderCleanOne.Substring(defenderCleanOne.IndexOf(' ') + 1);
                                    int defenderIndex = defenderCleanTwo.IndexOf(" for ");
                                    if (defenderIndex > 0)
                                        defender = defenderCleanTwo.Substring(0, defenderIndex);

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
                                        Console.WriteLine("Attacker = {0}, Damage = {1}", kv.Key, kv.Value);
                                    }
                                    Console.WriteLine("No Time Stamp: " + noTimeStamp);
                                    Console.WriteLine("");
                                }
                                #endregion
                            }
                            //if (withTimeStamp.Contains("slain"));
                            //{
                            //    withTimeStamp = withTimeStamp.Replace("You", player);
                            //    withTimeStamp = withTimeStamp.Replace("YOU", player);
                            //    string noTimeStampDeath = withTimeStamp.Substring(withTimeStamp.IndexOf(']') + 2);
                            //    if (noTimeStampDeath.Contains(" has been"))
                            //    {
                            //        int deathByOtherIndex = noTimeStampDeath.IndexOf(" has been");
                            //        if (deathByOtherIndex > 0)
                            //            deathByOther = noTimeStampDeath.Substring(0, deathByOtherIndex);
                            //        Console.WriteLine(deathByOther + ".");
                            //        if (!dDamTable.ContainsKey(deathByOther))
                            //        {
                            //            dDamTable.Remove(deathByOther);
                            //        }
                            //    }
                            //    if (noTimeStampDeath.Contains(" have "))
                            //    {
                            //        int deathByYouIndex = noTimeStampDeath.IndexOf(" have ");
                            //        if (deathByYouIndex > 0)
                            //            deathByYou = noTimeStampDeath.Substring(0, deathByYouIndex);
                            //        Console.WriteLine(deathByYou + ".");
                            //        if (!dDamTable.ContainsKey(deathByYou))
                            //        {
                            //            dDamTable.Remove(deathByYou);
                            //        }
                            //    }
                            //}
                        }
                    }
                }
                foreach (KeyValuePair<string, int> kv in dDamTable)
                {
                    Console.WriteLine("Attacker = {0}, Damage = {1}", kv.Key, kv.Value);
                }
                Console.ReadLine();
            }
        }
    }
}