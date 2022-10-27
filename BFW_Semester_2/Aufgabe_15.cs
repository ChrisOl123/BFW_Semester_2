using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BFW_Semester_2
{
    enum Alf { empty, A, B, C, D, E, F, G, H, I, J }
    class Aufgabe_15
    {
        public static int s2 = 0, s3 = 0, s4 = 0, s5 = 0;           // Erstellen der Klassenvariable
        public static List<string> zerstört = new List<string>();   // Erstellen der zerstörten Schiffe Liste

        public static void Start()
        {
            int spielzüge = 50;                                   // Wieviele Spielzüge erlaubt sind

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
            };          // Feld das angezeigt wird
            int[,] feldback = new int[10, 10] {
                { 4 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },                  // Schlachtschiff 5 Felder      Kreuzer 4 Felder        Fregatte 3 Felder          Schnellboot 2 Felder    
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 }
            };                 // Feld das im Hintergrund läuft

            Randomizer(feldback, feldfront);                      // Methode zum erstellen der Random Schiff belegung
            for (int i = spielzüge; i > 0; i--)
            {
                AnzeigeFeld(feldfront, message);                      // Anzeige des Feldes mit den Nachrichten zum Spiel
                Console.WriteLine("Sie habe {0} Schüsse übrig.", i);
                message = Verarbeitung(Input(), feldback, feldfront);
                if (zerstört.Count == 4)                              // Wenn alle 4 Schiffe zerstört sind, ist das spiel Gewonnen
                {
                    Console.Clear();
                    Console.WriteLine("Sie Haben alle Schiffe zerstört. SIE HABEN GEWONNEN!!!");
                    break;
                }
            }
            if (zerstört.Count < 4)
            {
                Console.Clear();                                     // Wenn die Spielzüge aufgebraucht sind hat man verloren
                Console.WriteLine("Leider haben Sie verloren :(");
            }
        }
        static void Randomizer(int[,] feldback, string[,] feldfront)
        {
            int counter = 0;
            int[] schiffe = new int[] { 5, 4, 3, 2 };
            while (counter < 4)                       // So lange bis alle 4 Schiffe erstellt worden sind
            {
                int x = 0;
                int y = 0;
                int ship = schiffe[counter];
                int c = 0;
                int verticalOrHorizontal = new Random().Next(0, 2);  // 1 = Vertikal, 2 = Hoizontal
                int spalte = new Random().Next() % (11 - ship);
                int zeile = new Random(DateTime.Now.Millisecond).Next() % (11 - ship);

                for (int j = 0; j < ship; j++)
                {
                    if (verticalOrHorizontal == 1)
                        x = j;                          // Vertikal: x = j
                    else
                        y = j;                          // Horizontal: y = j
                    if (feldback[spalte + x, zeile + y] < 1)
                        c++;
                    else
                        break;
                    if (c == ship)                      // Wenn alle geplanten Felder überprüft worden sind erstelle das Schiff
                    {
                        for (int i = 0; i < ship; i++)  
                        {
                            if (verticalOrHorizontal == 1)
                                x = i;
                            else
                                y = i;                                 // Schiff erstellung

                            feldback[spalte + x, zeile + y] = ship;
                            //feldfront[spalte + (x + 2), zeile + (y + 2)] = String.Format("{0}", schiffe[counter]);        //zum Anzeigen der Schiffe
                        }
                        counter++;
                    }
                }
            }
        }
        static void AnzeigeFeld(string[,] feldfront, string message)
        {
            Console.Clear();                // Cleart das alte Feld
            for (int i = 0; i < 12; i++)   // Zeigt alle Spalten des Feld Arrays an
            {
                for (int i2 = 0; i2 < 12; i2++)                 // Zeigt alle Zeilen des Feld Arrays an
                    Console.Write(" " + feldfront[i, 0 + i2]);
                Console.WriteLine();
            }
            Console.Write("Zerstörte Schiffe: ");  
            foreach (var element in zerstört)      // Zeigt die liste der zerstörten Schiffe an
                Console.Write(element);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(message);            // Gibt die Nachricht des letzten Zuges an
        }
        static Tuple<Alf, int> Input()
        {
            while (true)
            {
                Array arr = Enum.GetValues(typeof(Alf));
                Alf buchstabe = Alf.empty;
                bool b = false;

                Console.WriteLine("Welches Feld möchten Sie bombardieren? [Buchstabe][Zahl] z.B. A1.");
                string input = Console.ReadLine().Trim();
                if (input != string.Empty)           // Wenn etwas in der Eingabe steht geh rein
                {
                    foreach (Alf element in arr)
                    {                                                                           
                        if (element.ToString() == input[0].ToString().ToUpper() && input.Length <= 3)// Erstes Element der Eingabe überprüfen
                        {
                            buchstabe = element;                                
                            b = true;
                        }
                    }
                    if (b)
                    {
                        int temp = 0;
                        for (int i = 0; i < input.Length; i++)
                        {

                            if (int.TryParse(input[i].ToString(), out int zahl))  // 2. und 3. Element nach einer Zahl überprüfen
                            {
                                temp *= 10;
                                temp += zahl;
                            }
                        }
                        if (temp > 0 && temp <= 10) // Zahl nach korrektheit überrpüfen
                        {
                            Tuple<Alf, int> tuple = new Tuple<Alf, int>(buchstabe, temp); // Erstelle ein Tupel mit dem Buchstaben und der Zahl
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
            int zeile = tuple.Item2 - 1;       // Erstellen der passenden Variablen damit sie mit dem feld übereinstimmen
            string ship = string.Empty;

            switch (feldback[spalte, zeile]) // Die Felder nach Zahlen suchen 2-5 sind jeweils Schiffe
            {
                case 0:
                    feldfront[spalte + 2, zeile + 2] = "-";
                    return "Platsch. Sie haben nichts getroffen.";
                case 9:
                    return "Ziel wurde schon getroffen!";
                case 2:
                    s2++;         // Globale Variable wird genutzt um die Anzahl der treffer für die Schiffe zu zählen
                    if (s2 == 2)
                    {
                        ship = "Schnellboot versenkt.";
                        zerstört.Add("Schnellboot, ");        // Fügt das versenkte Schiff zur Zerstört Liste zu
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
            feldback[spalte, zeile] = 9;            // 9 bedeutet das dieses Feld mindestens ein mal getroffen wurde
            feldfront[spalte + 2, zeile + 2] = "X"; // der Treffer wird in der Anzeige mit einem X markiert
            return string.Format("Treffer! {0}", ship);
        }
    }
}
