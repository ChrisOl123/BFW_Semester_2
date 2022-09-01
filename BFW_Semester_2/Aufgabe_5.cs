using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    class Aufgabe_5
    {
        public static void Start()
        {
            List<string> liste = new List<string>();
            Console.WriteLine("Welche Rechnung möchten sie Durchführen");
            string input = Console.ReadLine().Trim();

            int num = -1;
            int temp = 0;
            foreach (var element in input)
                num = NewMethod(liste, ref temp, element);
        }

        private static int NewMethod(List<string> liste, ref int temp, char element)
        {
            int num;
            {
                if (int.TryParse(element.ToString(), out num))
                {
                    temp *= 10;
                    temp += num;
                }
                else
                {
                    liste.Add(temp.ToString());
                    liste.Add(element.ToString());
                }

            }

            return num;
        }
    }
}
