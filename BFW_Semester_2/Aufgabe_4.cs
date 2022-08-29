using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    class Aufgabe_4
    {
        public static void Start()
        {
            List<string> liste = new List<string>();
            while (true)
            {
                Console.WriteLine("Bitte geben Sie einen String oder eine Zahl ein:");
                liste.Add(Console.ReadLine());
                Console.WriteLine("Soll noch etwas eingegeben werden? [j = weiter]");
                if (Console.ReadLine().Trim() == "j")
                {
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    int res = 0;
                    Console.WriteLine();
                    foreach (var element in liste)
                    {
                        int länge, num;
                        if (int.TryParse(element, out num))
                        {
                            res += num;
                            Console.WriteLine("Eingabe: {0} Nummer: {0}", num);
                        }
                        else
                        {
                            länge = element.Length;
                            res += länge;
                            Console.WriteLine("Eingabe: {0} Nummer: {1}", element, länge);
                        }
                    }
                    Console.WriteLine("Gesamtsumme: " + res);
                    break;
                }
            }
        }
    }
}
