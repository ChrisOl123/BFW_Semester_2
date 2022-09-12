using System;

namespace BFW_Semester_2
{
    class Aufgabe_8
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
            Console.WriteLine("Das Übergebene Element ist ein String mit der Länge {0}.", str.Length);
        }
        static void Analyze(int zahl)
        {
            Console.WriteLine("Das Übergebene Element ist ein Integer. Dieser hat {0} Stellen.", zahl.ToString().Length);
        }
        static void Analyze(char cha)
        {
            Console.WriteLine("Das Übergebene Element ist ein Character mit der dezimalen Codierung {0}.", (int)cha);
        }
        static void Analyze(double d)
        {
            int res = 0;
            int i = 0;
            if (d % 1 == 0)
                res = 0;
            else
            {
                foreach (var element in d.ToString())
                {
                    if (element.ToString() == ",")
                    {
                        string temp = d.ToString().Substring(i, d.ToString().Length - (i + 1));
                        res = temp.Length;
                    }
                    i++;
                }
                Console.WriteLine("Das Übergebene Element ist ein Double. Dieser hat {0} Nachkommastellen.", res);
            }
        }
    }
}
