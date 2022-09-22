using System;
using System.Collections.Generic;
using System.Text;

namespace BFW_Semester_2
{
    enum Mög { Schere, Stein, Papier, Echse, Spock }
    class Aufgabe_10
    {
        public static void Start()
        {
            Input();
        }
        static void GenZufallszahl()
        {
            
            Random rand = new Random(DateTime.Now.Millisecond);
            int rand2 = rand.Next() % 10 ;
            if(rand2 == 0)
            {

            }
        }
        static void Input()
        {
            int player = 0;
            int computer = 0;

            Console.WriteLine("Ihre Punkte: {0} - Punkte Computer: {1}",player,computer);

            for (int i = 0; i < 5; i++)
                Console.WriteLine(i+") "+ Enum.GetName(typeof(Mög), i));
            Console.WriteLine("Bitte geben Sie einene Wert ein: ");
            string input = Console.ReadLine();
        }
    }
}
