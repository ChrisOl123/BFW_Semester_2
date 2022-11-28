using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    internal class Aufgabe_9B
    {
        public static void Start()

        {
            List<Tuple<string, int>> liste = new List<Tuple<string, int>>();

            Console.WriteLine("Bitte geben Sie Wörter ein:");

            Input(liste);

            Ausgabe(liste);
        }
        static Tuple<string, int> Selbstlautprüf(string input)
        {
            int counter = 0;
            string[] selbst = new string[] {"a", "e", "i", "o", "u" };

            for (int i = 0; i < selbst.Length; i++)
                foreach (var element in input)
                {
                    if (element.ToString().ToLower() == selbst[i])
                        counter++;
                }
            Tuple<string, int> tuple = new Tuple<string, int>(input, counter);
            return tuple;
        }
        static void Ausgabe(List<Tuple<string, int>> tuples)
        {
            for (int i = 0; i < tuples.Count; i++)
            {
                if (tuples[i].Item2 == 0)
                    Console.WriteLine("Das Wort '" + tuples[i].Item1 +"' hat keine Selbstlaute.");
                else if (tuples[i].Item2 == 1)
                    Console.WriteLine("Das Wort '"+ tuples[i].Item1 + "' hat einen Selbstlaut.");
                else
                    Console.WriteLine("Das Wort '"+ tuples[i].Item1 + "' hat "+ tuples[i].Item2 + " Selbstlaute.");
            }
        }
        static void Input(List<Tuple<string, int>> liste)
        {
            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == string.Empty)
                    break;
                else
                    liste.Add(Selbstlautprüf(input));
            }
        }
    }
}
