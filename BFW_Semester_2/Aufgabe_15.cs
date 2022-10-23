using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    enum Alf { empty, A, B, C, D, E, F, G, H, I, J }
    class Aufgabe_15
    {
        public static int s2 = 0, s3 = 0, s4 = 0, s5 = 0;
        public static List<string> zerstört = new List<string>();

        public static void Start()
        {
            int spielzüge = 50;

            string message = "Herzlich Willkommen!";
            string[,] feldfront = new string[12, 12]
            {
                {" "," ","1","2","3","4","5","6","7","8","9","10"},
                {" "," ","|","|","|","|","|","|","|","|","|","|"},
                {"A","-","O","O","O","O","O","O","O","O","O","O"},
                {"B","-","O","O","O","O","O","O","O","O","O","O"},
                {"C","-","O","O","O","O","O","O","O","O","O","O"},
                {"D","-","O","O","O","O","O","O","O","O","O","O"},
                {"E","-","O","O","O","O","O","O","O","O","O","O"},
                {"F","-","O","O","O","O","O","O","O","O","O","O"},
                {"G","-","O","O","O","O","O","O","O","O","O","O"},
                {"H","-","O","O","O","O","O","O","O","O","O","O"},
                {"I","-","O","O","O","O","O","O","O","O","O","O"},
                {"J","-","O","O","O","O","O","O","O","O","O","O"}
            };
            int[,] feldback = new int[10, 10] {
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 3 , 3 , 3 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },                  // Schlachtschiff 5 Felder      Kreuzer 4 Felder        Fregatte 3 Felder          Schnellboot 2 Felder    
                { 0 , 0 , 0 , 0 , 0 , 0 , 5 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 5 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 5 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 4 , 0 , 0 , 5 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 4 , 0 , 0 , 5 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 4 , 0 , 0 , 0 , 0 , 2 , 2 },
                { 0 , 0 , 0 , 4 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 }
            };
            for (int i = spielzüge; i > 0; i--)
            {
                AnzeigeFeld(feldfront, message);
                Console.WriteLine("Sie habe {0} Schüsse übrig.", i);
                message = Verarbeitung(Input(), feldback, feldfront);
                if (zerstört.Count == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Sie Haben alle Schiffe zerstört. SIE HABEN GEWONNEN!!!");
                    break;
                }
            }
            if (zerstört.Count < 4)
            {
                Console.Clear();
                Console.WriteLine("Leider haben Sie verloren :(");
            }
        }
        static void AnzeigeFeld(string[,] feldfront, string message)
        {
            Console.Clear();
            for (int i = 0; i < 12; i++)
            {
                for (int i2 = 0; i2 < 12; i2++)
                    Console.Write(" " + feldfront[i, 0 + i2]);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Zerstörte Schiffe: ");
            foreach (var element in zerstört)
                Console.Write(element);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(message);
        }
        static Tuple<Alf, int> Input()
        {
            while (true)
            {
                Array arr = Enum.GetValues(typeof(Alf));
                int temp = 0;
                Alf buchstabe = Alf.empty;
                bool b = false;

                Console.WriteLine("Welches Feld möchten Sie bombardieren? [Buchstabe][Zahl] z.B. A1.");
                string input = Console.ReadLine().Trim();
                if (input != string.Empty)
                {
                    foreach (Alf element in arr)
                    {
                        if (element.ToString() == input[0].ToString().ToUpper() && input.Length <= 3)
                        {
                            buchstabe = element;
                            b = true;
                        }
                    }
                    if (b)
                    {
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (int.TryParse(input[i].ToString(), out int zahl))
                            {
                                temp *= 10;
                                temp += zahl;
                            }
                        }
                        if (temp > 0 && temp <= 10)
                        {
                            Tuple<Alf, int> tuple = new Tuple<Alf, int>(buchstabe, temp);
                            return tuple;
                        }
                    }
                }
                Console.WriteLine("Invalide Eingabe!");
            }
        }
        static string Verarbeitung(Tuple<Alf, int> tuple, int[,] feldback, string[,] feldfront)
        {
            int spalte = (int)tuple.Item1 - 1;
            int zeile = tuple.Item2 - 1;
            string ship = string.Empty;

            switch (feldback[spalte, zeile])
            {
                case 0:
                    feldfront[spalte + 2, zeile + 2] = "-";
                    return "Platsch. Sie haben nichts getroffen.";

                case 9:
                    return "Ziel wurde schon getroffen!";

                case 2:
                    s2++;
                    if (s2 == 2)
                    {
                        ship = "Schnellboot versenkt.";
                        zerstört.Add("Schnellboot, ");
                    }
                    break;

                case 3:
                    s3++;
                    if (s3 == 3)
                    {
                        ship = "Fregatte versenkt.";
                        zerstört.Add("Fregatte, ");
                    }
                    break;

                case 4:
                    s4++;
                    if (s4 == 4)
                    {
                        ship = "Kreuzer versenkt.";
                        zerstört.Add("Kreuzer, ");
                    }
                    break;

                case 5:
                    s5++;
                    if (s5 == 5)
                    {
                        ship = "Schlachtschiff versenkt.";
                        zerstört.Add("Schlachtschiff, ");
                    }
                    break;
            }
            feldback[spalte, zeile] = 9;
            feldfront[spalte + 2, zeile + 2] = "X";
            return string.Format("Treffer! {0}", ship);
        }
    }
}
