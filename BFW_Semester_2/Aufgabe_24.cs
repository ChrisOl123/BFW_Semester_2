using System;
using System.Collections.Generic;
using System.Text;

namespace BFW_Semester_2
{
    internal class Aufgabe_24
    {
        public static void Start()
        {
            int playerPos = 0;                        // 0 = Start Position, 1 = Tafel Position, 2 = Arbeitsplatz Position, 3 = Ausgang Position
            MakeClass();

            while (true)
            {
                string input = Input();
                playerPos = Decision(input,playerPos);
                if (playerPos == -1)
                {
                    Console.Clear();
                    Console.WriteLine("Auf Wiedersehen!");
                    Environment.Exit(-1);
                }
            }
        }
        public static void MakeClass()
        {
            string[] grafik = new string[17];
            grafik[0] = "+-------+-------------+------+";
            grafik[1] = "|       +-------------+      |";
            grafik[2] = "|                            |";
            grafik[3] = "|                            |";
            grafik[4] = "|  +----+   +----+   +----+  |";
            grafik[5] = "|  |    |   |    |   |    |  |";
            grafik[6] = "|  +----+   +----+   +----+  |";
            grafik[7] = "|                            |                           Geben Sie ihre Antwort in Zahlen ein.";
            grafik[8] = "|  +----+   +----+   +----+  |";
            grafik[9] = "|  |    |   |    |   |    |  |";
            grafik[10] = "|  +----+   +----+   +----+ -+";
            grafik[11] = "|                             <-- Sie sind hier";
            grafik[12] = "|  +----+   +----+   +----+ -+";
            grafik[13] = "|  |    |   |    |   |    |  |";
            grafik[14] = "|  +----+   +----+   +----+  |";
            grafik[15] = "|                            |";
            grafik[16] = "+----------------------------+";
            Console.Clear();
            foreach (var item in grafik)
                Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine("[1] Zur Tafel gehen?");
            Console.WriteLine("[2] Zu einem Arbeitsplatz gehen?");
            Console.WriteLine("[3] Das Klassenzimmer verlassen?");
        }
        public static void MakeArbeitsplatz()
        {
            string[] grafik = new string[17];
            grafik[0] = "+----------------------------+";
            grafik[1] = "|                            |";
            grafik[2] = "|  +----------------------+  |";
            grafik[3] = "|  |                      |  |";
            grafik[4] = "|  |        Tafel         |  |";
            grafik[5] = "|  |          +-----------+--|";
            grafik[6] = "|  |          |  +-----------|";
            grafik[7] = "|  |----------|  |           |";
            grafik[8] = "|  |----------|  |      Pc   |";
            grafik[9] = "|             |  |           |";
            grafik[10] = "| +-----------|  |           |";
            grafik[11] = "| |           |  +-----------|";
            grafik[12] = "| |           +---------++---|";
            grafik[13] = "| |                     ||   |";
            grafik[14] = "| |         +-----------++---+";
            grafik[15] = "| |         |                |";
            grafik[16] = "+-+---------+----------------+";
            Console.Clear();
            foreach (var item in grafik)
                Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine("[1] Zur Tafel gehen?");
            Console.WriteLine("[2] Zum Eingang des Klassenzimmer gehen?");
            Console.WriteLine("[3] Das Klassenzimmer verlassen?");
        }
        public static void MakeExit()
        {
            string[] grafik = new string[17];
            grafik[0] = "+----------------------------+";
            grafik[1] = "|                            |";
            grafik[2] = "|         +--------+         |";
            grafik[3] = "|         |  Exit  |         |";
            grafik[4] = "|         +--------+         |";
            grafik[5] = "|                            |";
            grafik[6] = "|       +------------+       |";
            grafik[7] = "|       |            |       |";
            grafik[8] = "|       |            |       |";
            grafik[9] = "|       |            |       |";
            grafik[10] = "|       |            |       |";
            grafik[11] = "|       |        +-+ |       |";
            grafik[12] = "|       |        +-+ |       |";
            grafik[13] = "|       |            |       |";
            grafik[14] = "|       |            |       |";
            grafik[15] = "|       |            |       |";
            grafik[16] = "+-------+------------+-------+";
            Console.Clear();
            foreach (var item in grafik)
                Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine("[1] Zum Eingang des Klassenzimmer gehen?");
            Console.WriteLine("[2] Nach Hause gehen?");
        }
        public static void MakeTafel()
        {
            string[] grafik = new string[17];
            grafik[0] = "+----------------------------+";
            grafik[1] = "|                            |";
            grafik[2] = "+----------------------------+";
            grafik[3] = "|                            |";
            grafik[4] = "|                            |";
            grafik[5] = "|                            |";
            grafik[6] = "|            Tafel           |";
            grafik[7] = "|                            |";
            grafik[8] = "|                            |";
            grafik[9] = "|                            |";
            grafik[10] = "|                            |";
            grafik[11] = "+----------------------------+";
            grafik[12] = "|                       ==== |";
            grafik[13] = "+----------------------------+";
            grafik[14] = "|                            |";
            grafik[15] = "|                            |";
            grafik[16] = "+----------------------------+";
            Console.Clear();
            foreach (var item in grafik)
                Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine("[1] Zum Eingang des Klassenzimmer gehen?");
            Console.WriteLine("[2] Zu einem Arbeitsplatz gehen?");
            Console.WriteLine("[3] Das Klassenzimmer verlassen?");

        }
        public static string Input()
        {
            Console.WriteLine();
            Console.WriteLine("Was möchten Sie tun ?");
            string input =  Console.ReadLine().Trim();
                return input;
        }
        public static int Decision(string input, int playerPos)
        {
            while (true)
            {
                if (playerPos == 0)     // Start Position
                {
                    if (input == "1")
                    {
                        MakeTafel();
                        return playerPos = 1;
                    }
                    else if (input == "2")
                    {
                        MakeArbeitsplatz();
                        return playerPos = 2;
                    }
                    else if (input == "3")
                    {
                        MakeExit();
                        return playerPos = 3;
                    }
                }
                else if (playerPos == 1)       // Tafel Position
                {
                    if (input == "1")
                    {
                        MakeClass();
                        return playerPos = 0;
                    }
                    else if (input == "2")
                    {
                        MakeArbeitsplatz();
                        return playerPos = 2;
                    }
                    else if (input == "3")
                    {
                        MakeExit();
                        return playerPos = 3;
                    }
                }
                else if (playerPos == 2)     // Arbeitsplatz Position
                {
                    if (input == "1")
                    {
                        MakeTafel();
                        return playerPos = 1;
                    }
                    else if (input == "2")
                    {
                        MakeClass();
                        return playerPos = 0;
                    }
                    else if (input == "3")
                    {
                        MakeExit();
                        return playerPos = 3;
                    }
                }
                else if (playerPos == 3)
                {
                    if (input == "1")
                    {
                        MakeClass();
                        return playerPos = 0;
                    }
                    else if (input == "2")
                    {
                        return playerPos = -1;
                    }
                }
            }
        }
    }
}
