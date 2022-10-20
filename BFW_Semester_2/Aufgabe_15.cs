using System;

namespace BFW_Semester_2
{
    enum Alf { empty ,A, B, C, D, E, F, G, H, I, J }
    class Aufgabe_15
    {
        public static void Start()
        {
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
                { 1 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },                  // Schlachtschiff 5 Felder      Kreuzer 4 Felder        Fregatte 3 Felder          Schnellboot 2 Felder    
                { 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 1 , 0 , 0 , 1 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 1 , 0 , 0 , 1 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 1 , 1 },
                { 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 }
            };

            while (true)
            {
                AnzeigeFeld(feldfront);
                Tuple<Alf, int> tuple = (Input());
                Verarbeitung(tuple,feldback,feldfront);
            }
        }
        static void AnzeigeFeld(string[,] feldfront)
        {
            for (int i = 0; i < 12; i++)
            {
                for (int i2 = 0; i2 < 12; i2++)
                    Console.Write(" " + feldfront[i, 0 + i2]);
                Console.WriteLine();
            }
        }
        static Tuple<Alf, int> Input()
        {
            Console.WriteLine();
            while (true)
            {
                Array arr = Enum.GetValues(typeof(Alf));
                int temp = 0;
                Alf buchstabe = Alf.empty;
                bool b = false;

                Console.WriteLine("Welches Feld möchten Sie bombardieren? [Buchstabe][Zahl] z.B. A1.");
                string input = Console.ReadLine().Trim();

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
                Console.WriteLine("Invalide Eingabe!");
            }
        }
        static void Verarbeitung(Tuple<Alf, int> tuple, int[,] feldback, string[,] feldfront)
        {
            
            int spalte = (int)tuple.Item1-1;
            int zeile = tuple.Item2-1;
            if (feldback[spalte,zeile] == 0)
            {
                Console.WriteLine("Ziel verfehlt");
                feldfront[spalte + 2, zeile + 2] = "$";
            }
            else if (feldback[spalte, zeile] == 1)
            {
                Console.WriteLine("Ziel getroffen");
                feldback[spalte, zeile] = 2;
                feldfront[spalte+2, zeile+2] = "X";

            }
            else if (feldback[spalte, zeile] == 2)
            {
                Console.WriteLine("Schon getroffen");
            }
        }
    }
}
