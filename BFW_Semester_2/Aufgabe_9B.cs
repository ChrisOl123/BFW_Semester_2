using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    class Aufgabe_9B
    {
        public static void Start()

        {
            Console.WriteLine("Bitte geben Sie Wörter ein:");
            while (true)
            {

                string input = Console.ReadLine().Trim();

                if (input == string.Empty)
                {
                    List<string> str = new List<string>();
                }
                else
                {

                }
            }
        }
        static Tuple<string, int> In(string input)
        {
            int counter = 0;
            string[] selbst = new string[] { "A", "a", "E", "e", "I", "i", "O", "o", "U", "u" };
            for (int i = 0; i < input.Length; i++)
                foreach (var element in input)
                {
                    if (element.ToString() == selbst[i])
                        counter++;
                }


            Tuple<string, int> tuple = new Tuple<string, int>(input, counter);

            return tuple;
        }
    }
}
