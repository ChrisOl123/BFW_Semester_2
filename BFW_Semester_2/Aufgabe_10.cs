using System;
using System.Collections.Generic;


namespace BFW_Semester_2
{
    class Aufgabe_10
    {
        enum Mög { Schere, Stein, Papier, Echse, Spock }
        static List<Tuple<Mög, Mög, string>> list = new List<Tuple<Mög, Mög, string>>() {
            new Tuple<Mög, Mög, string>(Mög.Schere, Mög.Papier, "Schere schneidet Papier."),
            new Tuple<Mög, Mög, string>(Mög.Papier, Mög.Stein, "Papier bedeckt Stein."),
            new Tuple<Mög, Mög, string>(Mög.Stein, Mög.Echse, "Stein zerquetscht Echse."),
            new Tuple<Mög, Mög, string>(Mög.Echse, Mög.Spock, "Echse vergiftet Spock."),        // Regeln in Tuple in einer Liste
            new Tuple<Mög, Mög, string>(Mög.Spock, Mög.Schere, "Spock zertrümmert Schere."),
            new Tuple<Mög, Mög, string>(Mög.Schere, Mög.Echse, "Schere köpft Echse."),
            new Tuple<Mög, Mög, string>(Mög.Echse, Mög.Papier, "Echse frisst Papier."),
            new Tuple<Mög, Mög, string>(Mög.Papier, Mög.Spock, "Papier widerlegt Spock."),
            new Tuple<Mög, Mög, string>(Mög.Spock, Mög.Stein, "Spock verdampft Stein."),
            new Tuple<Mög, Mög, string>(Mög.Stein, Mög.Schere, "Stein schleift Schere.")
        };
        public static void Start()
        {
            int player = 0;
            int computer = 0;
            string erg = "";

            while(true){
                Tuple<Mög, Mög> tuple = Input(player, computer,erg);

                foreach (var element in list)
                {
                    if(tuple.Item1 == tuple.Item2)
                    {
                        erg = "Unentschieden";
                        break;
                    }
                    else if (element.Item1 == tuple.Item1 && element.Item2 == tuple.Item2)
                    {
                        erg = "Gewonnen!    " + element.Item3;
                        player++;
                        break;
                    }
                    else if (element.Item1 == tuple.Item2 && element.Item2 == tuple.Item1)
                    {
                        erg = "Verloren!    " + element.Item3;
                        computer++;
                        break;
                    }
                }
            }
        }
        static Tuple<Mög, Mög> Input(int player, int computer,string erg)              //erstellen einer Methode
        {
            Mög compinput = (Mög)(new Random(DateTime.Now.Millisecond).Next() % 5);   // Erstellen einer Zufallszahl
            Mög input;
            Console.Clear();
            Console.WriteLine("Ihre Punkte: {0} - Punkte Computer: {1}", player, computer);
            Console.WriteLine(erg);
            for (int i = 0; i < 5; i++)
                Console.WriteLine(i + ") " + Enum.GetName(typeof(Mög), i));

            Console.WriteLine("Bitte geben Sie einene Wert ein: ");
            while (true)
            {
                int zahl;
                if (!int.TryParse(Console.ReadLine(), out zahl) || zahl > 4 || zahl < 0)     // Eingabe überprüfen 
                    Console.WriteLine("Invalide Eingabe");
                else
                {
                    input = (Mög)zahl;
                    break;
                }
            }
            Tuple<Mög, Mög> tuple = new Tuple<Mög, Mög>(input, compinput);
            return tuple;
        }
    }
}
