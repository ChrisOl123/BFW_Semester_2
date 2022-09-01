using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    class Aufgabe_6
    {
        enum Countries { Deutschland, Frankreich, Polen, Italien, Griechenland, Schweiz };
        public static void Start()
        {
            List<Countries> coun = new List<Countries>();

            Console.WriteLine("Bitte geben Sie einen Ländernamen ein:");
            string input = Console.ReadLine().Trim();

            foreach (var element in Enum.GetValues(typeof(Countries)))
            {
                if (input == element.ToString())
                {
                   
                }
            }
        }
    }
}