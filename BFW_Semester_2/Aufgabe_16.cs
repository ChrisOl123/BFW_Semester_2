using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    internal class Aufgabe_16
    {
        public static void Start()
        {
            int[] lösungen = new int[] { 2, 3, 2, 8 };
            string[][] fragen = Möglichkeiten();

            List<int> antworten = Verarbeitung(Möglichkeiten());
            Console.Clear();
            for (int i = 0; i < lösungen.Length; i++)
            {
                if (lösungen[i] == antworten[i])
                    Console.WriteLine("Antwort {0} Richtig.", (i + 1));
                else
                    Console.WriteLine("Antwort {0} Falsch.", (i + 1));
            }
        }
        static string[][] Möglichkeiten()
        {
            string[][] fragen = new string[4][] {
                new string[] {"Aus wie vielen Einzelknochen besteht eine menschliche Hand?","17","27","32","21" }, // 27
                new string[] {"Wie hoch ist der Eiffelturm?","250m","270m","300m" }, // 300m
                new string[] {"Es gibt in unseren Sonnensystem 9 Platen. Stimmts?","Ja","Nein"}, // Nein
                new string[] {"Wie viele Joints raucht Snoop Dog täglich?","13", "2", "3", "40", "35", "60","79", "81", "90"} // 81
            };
            return fragen;
        }
        static List<int> Verarbeitung(string[][] fragen)
        {
            List<int> antworten = new List<int>();
            for (int i = 0; i < fragen.Length; i++)
            {
                Console.Clear();
                int counter = 0;
                foreach (var element in fragen[i])
                    counter++;

                Console.WriteLine(fragen[i][0]);
                Console.WriteLine();
                for (int i2 = 1; i2 < counter; i2++)
                    Console.WriteLine(String.Format("[{0}] = ", i2) + fragen[i][i2]);

                Console.WriteLine();
                Console.WriteLine("Bitte geben Sie die Antwort in Zahlen.");
                Console.Write("Ihre Antwort: ");
                while (true)
                {
                    int number;
                    if (int.TryParse(Console.ReadLine(), out number) && number > 0 && number < counter)
                    {
                        antworten.Add(number);
                        break;
                    }
                    else
                        Console.WriteLine("Invalide Eingabe, erneute Eingabe tätigen.");
                }
            }
            return antworten;
        }
    }
}
