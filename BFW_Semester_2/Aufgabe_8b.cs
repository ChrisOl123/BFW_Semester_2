using System;

namespace BFW_Semester_2
{
    internal class Aufgabe_8b
    {
        public static void Start()
        {
            Analyze(44.343);
            Analyze('S');
            Analyze("Teststring");
            Analyze(390);
            Analyze(33.0);
            Analyze(1209);
            Analyze('c');
        }
        static void Analyze(string str)
        {
            Console.WriteLine("Das übergebene Element in ein String mit der Länge {0}.", str.Length);
        }
        static void Analyze(int inte)
        {
            Console.WriteLine("Das übergebene Element in ein Integer. Dieser hat {0} Stellen.", inte.ToString().Length);
        }
        static void Analyze(char c)
        {
            Console.WriteLine("Das übergebene Element in ein Charakter mit der dezimalen Codierung {0}.", (int)c);
        }
        static void Analyze(double d)
        {
            string doppel = d.ToString();
            int res = 0;
            if (d % 1 == 0)           // überprüfen ob die Zahl durch 1 Teilbar ist
                res = 0;
            else
                for (int i = 0; i < doppel.Length; i++)
                {
                    if (doppel[i].ToString() == ",")        // Nachkommastellen ermitteln
                    {
                        string temp = doppel.Substring(i, doppel.Length - (i + 1));
                        res = temp.Length;
                    }
                }
            Console.WriteLine("Das übergebene Element in ein Double. Dieser hat {0} Nachkommastellen.", res);
        }
    }
}
