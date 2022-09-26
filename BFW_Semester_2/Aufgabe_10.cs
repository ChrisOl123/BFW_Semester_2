using System;
using System.Collections.Generic;


namespace BFW_Semester_2
{
    class Aufgabe_10
    {
        enum Mög { Schere, Stein, Papier, Echse, Spock }

        static List<Tuple<Mög, Mög, string>> list = new List<Tuple<Mög, Mög, string>>() {
            new Tuple<Mög, Mög, string>(Mög.Schere, Mög.Papier, "Schere schneidet Papier"),
            new Tuple<Mög, Mög, string>(Mög.Papier, Mög.Stein, "Papier bedeckt Stein"),
            new Tuple<Mög, Mög, string>(Mög.Stein, Mög.Echse, "Stein zerquetscht Echse"),
            new Tuple<Mög, Mög, string>(Mög.Echse, Mög.Spock, "Echse vergiftet Spock"),
            new Tuple<Mög, Mög, string>(Mög.Spock, Mög.Schere, "Spock zertrümmert Schere"),
            new Tuple<Mög, Mög, string>(Mög.Schere, Mög.Echse, "Schere köpft Echse"),
            new Tuple<Mög, Mög, string>(Mög.Echse, Mög.Papier, "Echse frisst Papier"),
            new Tuple<Mög, Mög, string>(Mög.Papier, Mög.Spock, "Papier widerlegt Spock"),
            new Tuple<Mög, Mög, string>(Mög.Spock, Mög.Stein, "Spock verdampft Stein"),
            new Tuple<Mög, Mög, string>(Mög.Stein, Mög.Schere, "Stein schleift Schere")
        };

        public static void Start()
        {
            int player = 0;
            int computer = 0;

            foreach (var element in list)
            {
                if (Input(player, computer).Item1 == Input(player, computer).Item2)
                {
                    Console.WriteLine("Unentschieden");
                }
                else if (element.Item1 == Input(player, computer).Item1 && element.Item2 == Input(player, computer).Item2)
                {
                    Console.WriteLine(element.Item3);
                    player++;
                    break;
                }
                else if (element.Item1 == Input(player, computer).Item2 && element.Item2 == Input(player, computer).Item1)
                {
                    Console.WriteLine(element.Item3);
                    computer++;
                    break;
                }
            }
        }

        static Tuple<Mög, Mög> Input(int player, int computer)
        {

            int zahl;
            Mög input;
            // PC = (MÖG)(new Random().Next() % 5);

            Random rand = new Random(DateTime.Now.Millisecond);
            int rand2 = rand.Next() % 5;
            Mög computerinput = (Mög)rand2;
            Console.Clear();
            Console.WriteLine("Ihre Punkte: {0} - Punkte Computer: {1}", player, computer);
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
                Console.WriteLine(i + ") " + Enum.GetName(typeof(Mög), i));

            Console.WriteLine("Bitte geben Sie einene Wert ein: ");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out zahl) || zahl > 4 || zahl < 0)
                    Console.WriteLine("Invalide Eingabe");
                else
                {
                    input = (Mög)zahl;
                    break;
                }

            }
            Tuple<Mög, Mög> tuple = new Tuple<Mög, Mög>(input, computerinput);
            return tuple;
        }
    }
}
