using System;
using System.Collections.Generic;
using System.Text;

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
            {
                if(int.TryParse(element.ToString(), out num))
                {
                    temp *= 10;
                    temp += num;
                }
                else
                {
                    liste.Add(temp.ToString());
                    liste.Add(element.ToString());
                }

                if (element == '+')
                {
                    Plus(Convert.ToInt32(liste[0]),Convert.ToInt32(liste[1]));
                }
            }
            static string Plus(int temp, int temp_2)
            {
                return "";
            }
        }
    }
}
