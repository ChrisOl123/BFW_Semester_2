using System;

namespace BFW_Semester_2
{
    class Aufgabe_12
    {
        public static void Start()
        {
            int input_1;
            int input_3 = 0;
            int res;
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
                    string input_2 = Console.ReadLine();
                    if (!(input_2 == "/" || input_2 == "+" || input_2 == "*" || input_2 == "-"))
                    {
                        string[] arr = new string[0];
                        arr[1] = input_2;
                    }
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
                    res = input_1 / input_3;
                    Console.WriteLine("Ihre Rechnung: {0} / {1} = {2}",input_1,input_3,res);
                }
                catch
                {
                    Console.WriteLine("Durch {0} teilen ist leider nicht möglich!",input_3);
                    Console.WriteLine();
                    continue;
                }
            }
        }
    }
}
