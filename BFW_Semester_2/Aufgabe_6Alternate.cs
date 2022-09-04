using System;
using System.Collections.Generic;
using System.Text;

namespace BFW_Semester_2
{
    public class Aufgabe_6Alternate
    {
        enum Countries { Deutschland, Österreich, Schweiz, Italien, Niederlande }

        public static void Start()
        {
            var listCountries = new List<Countries>();
            Array values = Enum.GetValues(typeof(Countries));

            PrintEnumList(values);

            while (true)
            {
                Console.WriteLine("Bitte geben Sie einen Ländernamen ein: ");
                string str = Console.ReadLine();

                if (str == "")
                {
                    if (listCountries.Count > 0)
                    {
                        Console.WriteLine("\nHier sind alle Länder:");
                        for (int i = 0; i < listCountries.Count; i++)
                            Console.WriteLine(i + 1 + ": " + listCountries[i]);
                    }
                    else
                        Console.WriteLine("\nEs sind noch keine Länder in Ihrer Liste!");
                }
                else
                {
                    bool isCountry = false;
                    foreach (Countries val in values)
                    {
                        if (str == Enum.GetName(typeof(Countries), val))
                        {
                            if (listCountries.Contains(val))
                            {
                                Console.WriteLine("\nLöschen (y/n)?");
                                string input = Console.ReadLine();
                                if (input == "y")
                                    listCountries.Remove(val);
                            }
                            else
                                listCountries.Add(val);

                            isCountry = true;
                        }
                    }
                    if (!isCountry)
                        Console.WriteLine("\nLeider wurde das Land nicht erkannt...");
                }
                Console.WriteLine();
            }
        }

        private static void PrintEnumList(Array values)
        {
            Console.Write("Mögliche Länder: ");

            foreach (Countries val in values)
                Console.Write(val + " ");

            Console.WriteLine("\n\n");
        }
    }
}