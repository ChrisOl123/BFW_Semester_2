using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    internal class Aufgabe_6Alternate
    {
        enum Countries { Deutschland, Österreich, Schweiz, Italien, Polen }

        static List<Countries> CountryList = new List<Countries>();
        public static void Start()
        {
            while (true)
                registercountry(getuserinput());
        }

        static Countries getuserinput()
        {
            Console.WriteLine("Bitte ein Land eingeben:");

            while (true)
            {
                string userinput = Console.ReadLine().Trim();
                //Ausgabe falls leer
                if (userinput == "")
                {
                    showList();
                    Console.WriteLine("Bitte ein Land eingeben:");
                    continue;
                }

                //Prüfung: Ist das Land im Enum erhalten?
                foreach (Countries element in Enum.GetValues(typeof(Countries)))
                {
                    if (element.ToString().ToUpper() == userinput.ToUpper())
                    {
                        return element;
                    }
                }

                Console.WriteLine("Leider befindet sich das Land nicht in unserer Liste.... :(");
                Console.WriteLine("Bitte wiederholen Sie Ihre Eingabe (aber bitte diesmal richtig!):");
            }
        }
        static void registercountry(Countries country)
        {
            for (int i = 0; i < CountryList.Count; i++)
            {
                if (country == CountryList[i])
                {
                    Console.WriteLine("Nutzer! Möchten Sie dieses Land aus der Liste entfernen? Denn dieses Land ist bereits enthalten... (y = löschen)");
                    if (Console.ReadLine().ToLower() == "y")
                        CountryList.RemoveAt(i);
                    return;
                }
            }

            CountryList.Add(country);
        }

        static void showList()
        {
            if (CountryList.Count == 0)
            {
                Console.WriteLine("Leider ist die Liste leer... Hey, befüllen Sie sie doch :)");
                return;
            }

            Console.WriteLine("Hier sind Ihre Länder:");
            foreach (var element in CountryList)
                Console.WriteLine(element.ToString());
        }
    }
}

