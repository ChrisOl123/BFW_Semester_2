using System;

namespace BFW_Semester_2
{
    internal class Aufgabe_2
    {
        public static void Start()
        {
            while (true)
            {
                int zahl1, zahl2;

                Console.WriteLine("Bitte erste Zahl eingeben.");
                if (!int.TryParse(Console.ReadLine(), out zahl1))
                {
                    Console.WriteLine("Leider war die Eingabe nicht valide.");
                    continue;
                }
                while (true)
                {
                    Console.WriteLine("Bitte zweite Zahl eingeben.");
                    if (!int.TryParse(Console.ReadLine(), out zahl2))
                    {
                        Console.WriteLine("Leider war die Eingabe nicht valide.");
                        continue;
                    }
                    else
                        break;
                }
                Console.WriteLine(Div(zahl1, zahl2));
                Console.WriteLine();
            }
        }
        static string Div(int num1, int num2)
        {
            int erg = num1 / num2;
            int rest = num1 % num2;
            return string.Format("Das Ergebnis: {0} / {1} = {2} Rest: {3}", num1, num2, erg, rest);
        }
    }
}
