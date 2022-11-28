using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    internal class Aufgabe_6
    {
        enum Countries { Deutschland, Frankreich, Polen, Italien, Griechenland, Schweiz };
        public static void Start()
        {
            List<Countries> coun = new List<Countries>();
            Console.WriteLine("Mögliche Länder (Deutschland, Frankreich, Polen, Italien, Griechenland, Schweiz)");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Bitte geben Sie einen Ländernamen ein:");
                Array arr = Enum.GetValues(typeof(Countries));
                string input = Console.ReadLine().Trim();

                if (input == "")
                {
                    if (coun.Count == 0)
                        Console.WriteLine("Es sind noch keine Länder in der Liste.");
                    else
                    {
                        for (int i = 0; i < coun.Count; i++)
                            Console.WriteLine("{0}. {1}", i + 1, coun[i]);
                    }
                }
                else
                {
                    int counter = 0;
                    foreach (Countries element in arr)
                    {
                        if (input == Enum.GetName(typeof(Countries), element))
                        {
                            if (coun.Contains(element))
                            {
                                Console.WriteLine("Dieses Land ist schon vorhanden. Soll dieses gelöscht werden? (y/n)");
                                string yorn = Console.ReadLine();
                                if (yorn.ToLower() == "y")
                                {
                                    coun.Remove(element);
                                    Console.WriteLine(element + " wurde entfernt.");
                                }
                                else if (yorn.ToLower() == "n")
                                    break;
                                else
                                {
                                    Console.WriteLine("Invalide Eingabe.");
                                    break;
                                }
                            }
                            else
                                coun.Add(element);
                        }
                        else
                        {
                            counter++;
                            if (counter >= Enum.GetNames(typeof(Countries)).Length)
                                Console.WriteLine("Invalide Eingabe");
                        }
                    }
                }
            }
        }
    }
}