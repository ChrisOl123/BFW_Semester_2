using System;
using System.Collections.Generic;
using System.Text;

namespace BFW_Semester_2
{
    class Aufgabe_15
    {
        public static void Start()
        {

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
                AnzeigeFeld();
                Input();
            }
        }
        static void AnzeigeFeld()
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
                for (int i = 0; i < 12; i++)
                {
                    for (int i2 = 0; i2 < 12; i2++)
                        Console.Write(" " + feldfront[i, 0 + i2]);
                    Console.WriteLine();
                }
        }
        static void Input()
        {
            Console.WriteLine();
            Console.WriteLine("Welches Feld möchten Sie bombardieren? [Buchstabe][Zahl] z.B. A1.");
            string input = Console.ReadLine();
            

        }
    }
}
