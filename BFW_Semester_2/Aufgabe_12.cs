using System;

namespace BFW_Semester_2
{
    class Aufgabe_12
    {
        public static void Start()
        {
            int input_1;
            string input_2;
            int input_3 = 0;
            int erg;
            int rest = 0;
            while (true)
            {
                Console.WriteLine("Bitte geben Sie die erste Zahl ein:");
                try
                {
                    input_1 = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Leider war ihre Eingabe keine Zahl!");
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine("Bitte geben Sie das Rechenzeichen ein:");
                try
                {
                    input_2 = Console.ReadLine();
                    if (!(input_2 == "/" || input_2 == "+" || input_2 == "*" || input_2 == "-"))
                        erg = Convert.ToInt32(input_2) / 0;
                }
                catch
                {
                    Console.WriteLine("Leider war ihre Eingabe kein Rechenzeichen!");
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine("Bitte geben Sie die zweite Zahl ein:");
                try
                {
                    input_3 = Convert.ToInt32(Console.ReadLine());
                    if (input_2 == "/")
                    {
                        erg = input_1 / input_3;
                        rest = input_1 % input_3;
                    }
                    else if (input_2 == "*")
                        erg = input_1 * input_3;
                    else if (input_2 == "-")
                        erg = input_1 - input_3;
                    else
                        erg = input_1 + input_3;
                    if (input_1 % input_3 != 0 && input_2 == "/")
                        Console.WriteLine("Ihre Rechnung: {0} {1} {2} = {3} Rest {4}", input_1, input_2, input_3, erg, rest);
                    else
                        Console.WriteLine("Ihre Rechnung: {0} {1} {2} = {3}", input_1, input_2, input_3, erg);
                    Console.WriteLine();
                }
                catch
                {
                    if (input_3 == 0)
                        Console.WriteLine("Durch {0} teilen ist leider nicht möglich!", input_3);
                    else
                        Console.WriteLine("Leider ist ein Fehler aufgetreten geben Sie andere Zahlen ein.");
                    Console.WriteLine();
                    Console.WriteLine();
                    continue;
                }
            }
        }
    }
}
