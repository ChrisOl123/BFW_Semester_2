using System;

namespace BFW_Semester_2
{
    class Aufgabe_1
    {
        public static void Start()
        {
            Console.WriteLine(Div(14, 3));
        }
        static string Div(int num1, int num2)
        {
            int erg = num1 / num2;
            int rest = num1 % num2;
            return string.Format("Das Ergebnis: {0} / {1} = {2} Rest: {3}", num1, num2, erg, rest);
        }
    }
}

