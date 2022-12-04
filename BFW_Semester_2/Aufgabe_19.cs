using System;
using System.Collections.Generic;
using System.Text;

namespace BFW_Semester_2
{
    internal class Aufgabe_19
    {
        public static void Start()
        {
            Human Mensch = new Human();
        }
        static void Ausgabe()
        {
            Console.WriteLine("Menschen:");
            Console.WriteLine("[1] Erstellen");
            Console.WriteLine("[2] Bearbeiten");
            Console.WriteLine("[3] Löschen");

            Verarbeitung();
        }
        static void Verarbeitung()
        {
            if (int.TryParse(Console.ReadLine(), out int zahl) && zahl > 0 && zahl < 4){
                Console.WriteLine("h");
            }
        }
    }
}
