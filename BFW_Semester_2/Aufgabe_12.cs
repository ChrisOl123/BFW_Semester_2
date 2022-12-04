using System;

namespace BFW_Semester_2
{
    internal class Aufgabe_12
    {
        public static void Start()
        {
            int input_1;
            string input_2;
            int input_3 = -1;
            int erg;
            int rest = 0;
            while (true)
            {
                Console.WriteLine("Bitte geben Sie die erste Zahl ein:");
                try
                {
                    input_1 = Convert.ToInt32(Console.ReadLine()); // Eingabe Zahl, falls keine Zahl eingegeben wird springe in das catch scope
                }
                catch
                {
                    Console.WriteLine("Leider war ihre Eingabe keine Zahl!");
                    continue;
                }
                while (true)
                {
                    Console.WriteLine("Bitte geben Sie das Rechenzeichen ein:");
                    try
                    { // Wenn die Eingabe ein Rechenzeichen ist spring raus ansonsten verursache eine Exeption
                        input_2 = Console.ReadLine(); 
                        if (input_2 == "/" || input_2 == "+" || input_2 == "*" || input_2 == "-")
                              break;  
                        else
                            erg = Convert.ToInt32(input_2) / 0;
                    }
                    catch
                    {
                        Console.WriteLine("Leider war ihre Eingabe kein Rechenzeichen!");
                    }
                }
                while (true)
                {
                    Console.WriteLine("Bitte geben Sie die zweite Zahl ein:");
                    try
                    {
                        input_3 = Convert.ToInt32(Console.ReadLine());
                        if (input_2 == "/")
                        {
                            erg = input_1 / input_3;
                            rest = input_1 % input_3;                  // Rechenoperationen ausführen
                        }
                        else if (input_2 == "*")
                            erg = input_1 * input_3;
                        else if (input_2 == "-")
                            erg = input_1 - input_3;
                        else
                            erg = input_1 + input_3;
                        if (input_1 % input_3 != 0 && input_2 == "/")                                                               // Wenn ein Rest enthalten ist gebe diese Ausgabe aus
                            Console.WriteLine("Ihre Rechnung: {0} {1} {2} = {3} Rest {4}", input_1, input_2, input_3, erg, rest);
                        else
                            Console.WriteLine("Ihre Rechnung: {0} {1} {2} = {3}", input_1, input_2, input_3, erg);                 // Wenn kein Rest enthalten ist gebe diese Ausgabe aus
                        Console.WriteLine();
                        break;
                    }
                    catch
                    {
                        if (input_3 == 0)
                            Console.WriteLine("Durch {0} teilen ist leider nicht möglich!", input_3);
                        else
                            Console.WriteLine("Leider war ihre Eingabe keine Zahl!");
                    }
                }
            }
        }
    }
}
