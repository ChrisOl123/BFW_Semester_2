using System;

namespace BFW_Semester_2
{
    internal class Aufgabe_16
    {
        public static void Start()
        {
            bool runde = true;
            while (runde)
            {
                Tuple<int, int> antworten = Verarbeitung(Möglichkeiten());
                Console.Clear();
                Console.WriteLine("Richtig = {0}", antworten.Item1);
                Console.WriteLine("Falsch = {0}", antworten.Item2);
                Console.WriteLine();
                Console.WriteLine("Noch eine Runde? [Y] ja | [N] nein ");
                while (runde)
                {
                    string input = Console.ReadLine().Trim().ToUpper();
                    if (input == "Y")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (input == "N")
                        runde = false;
                    else
                        Console.WriteLine("Invalide Eingabe!");
                }
            }
        }
        static string[][] Möglichkeiten()
        {
            string[][] fragen = new string[][] {
                new string[] {"Aus wie vielen Einzelknochen besteht eine menschliche Hand?","17","27","32","21",/*Richtige Antwort->*/"27"},
                new string[] {"Wie hoch ist der Eiffelturm?","250m","270m","300m",/*Richtige Antwort->*/"300m" },
                new string[] {"Es gibt in unseren Sonnensystem 9 Platen. Stimmts?","Ja","Nein",/*Richtige Antwort->*/"Nein"},
                new string[] {"Wie viele Joints raucht Snoop Dog täglich?","13", "2", "3", "40", "35", "60","79", "81", "90",/*Richtige Antwort->*/"81" }
            };
            return fragen;
        }
        static Tuple<int, int> Verarbeitung(string[][] fragen)
        {
            bool b = false;
            string pfeil = string.Empty;
            int number;
            int richtig = 0, falsch = 0;
            for (int i = 0; i < fragen.Length; i++)
            {
                foreach (var element in fragen[i])
                {
                    Console.WriteLine(fragen[i][0]);
                    Console.WriteLine("Richtig = {0} Falsch = {1}", richtig, falsch);
                    Console.WriteLine();

                    for (int i2 = 1; i2 < fragen[i].Length - 1; i2++)
                    {
                        if (fragen[i][i2] == fragen[i][fragen[i].Length - 1] && b == true)
                            pfeil = "<-- Richtig";
                        Console.WriteLine(String.Format("[{0}] = {1} {2}", i2, fragen[i][i2], pfeil));
                        pfeil = string.Empty;
                    }
                    if (b)
                    {
                        Console.ReadKey();
                        Console.Clear();
                        b = false;
                        break;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Bitte geben Sie die Antwort in Zahlen.");
                    Console.Write("Ihre Antwort: ");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out number) && number > 0 && number < fragen[i].Length - 1)
                        {
                            if (fragen[i][number] == fragen[i][fragen[i].Length - 1])
                            {
                                Console.WriteLine("Richtig");
                                richtig++;
                            }
                            else
                            {
                                Console.WriteLine("Falsch");
                                b = true;
                                falsch++;
                            }
                            break;
                        }
                        else
                            Console.WriteLine("Invalide Eingabe, erneute Eingabe tätigen.");
                    }
                    if (b)
                    {
                        Console.Clear();
                        continue;
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
            return new Tuple<int, int>(richtig, falsch);
        }
    }
}
