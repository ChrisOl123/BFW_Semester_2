using System;

namespace BFW_Semester_2
{
    internal class Aufgabe_16
    {
        public static void Start()
        {
            bool runde = true;
            while (runde)  
            {
                Tuple<int, int> antworten = Verarbeitung(Möglichkeiten());    // Fragen und antworten + Eingabe
                Console.Clear();
                Console.WriteLine("Richtig = {0}", antworten.Item1);          // Counter für richtige Antworten
                Console.WriteLine("Falsch = {0}", antworten.Item2);           // Counter für falsche Antworten
                Console.WriteLine();
                Console.WriteLine("Noch eine Runde? [Y] ja | [N] nein ");
                while (runde) 
                {                                                       // Frage ob noch eine Runde gespielt werden soll
                    string input = Console.ReadLine().Trim().ToUpper();
                    if (input == "Y")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (input == "N")
                        runde = false;
                    else
                        Console.WriteLine("Invalide Eingabe!");
                }
            }
        }
        static string[][] Möglichkeiten()  // Fragen mit Antworten im jagged Array gespeichert
        {
            string[][] fragen = new string[][] { // Das letzte Element des Arrays ist die Lösung
                new string[] {"Aus wie vielen Einzelknochen besteht eine menschliche Hand?","17","27","32","21",/*Richtige Antwort->*/"27"},
                new string[] {"Wie hoch ist der Eiffelturm?","250m","270m","300m",/*Richtige Antwort->*/"300m" },
                new string[] {"Es gibt in unseren Sonnensystem 9 Platen. Stimmts?","Ja","Nein",/*Richtige Antwort->*/"Nein"},
                new string[] {"Wie viele Joints raucht Snoop Dog täglich?","13", "2", "3", "40", "35", "60","79", "81", "90",/*Richtige Antwort->*/"81" },
                new string[] {"Wie viele Tasten hat ein Klavier?","88 Tasten","72 Tasten","80 Tasten",/*Richtige Antwort->*/"88 Tasten"},
                new string[] {"Welche Blumenzwiebeln wurden früher als Zahlungsmittel genutzt?", "Krokusse", "Lilien", "Gladiolen", "Tulpen",/*Richtige Antwort->*/"Tulpen"},
                new string[] {"Was ist ein Falchion?", "Ein Schwert", "Ein Tier", "Ein Kleidungsstück",/*Richtige Antwort->*/"Ein Schwert"},
                new string[] {"Ist es wirklich wahr, dass im Hochmittelalter in Europa im Durchschnitt auf zwei Menschen eine Kirche kam? ","Ja","Nein",/*Richtige Antwort->*/"Ja"}            };
            return fragen;
        }
        static Tuple<int, int> Verarbeitung(string[][] fragen) 
        {
            bool b = false;
            string pfeil = string.Empty;
            int richtig = 0, falsch = 0, number;
            for (int i = 0; i < fragen.Length; i++)   // Schleife durch die 1. Dimension des Arrays
            {
                foreach (var element in fragen[i])    // Schleife durch die einzelnen Arrays 
                {
                    Console.WriteLine(fragen[i][0]);                            // Gibt die Fragen aus, die auf Position 1 sind
                    Console.WriteLine("Richtig = {0} Falsch = {1}", richtig, falsch);  // Zeigt den aktuellen Stand der Punkte an
                    Console.WriteLine();

                    for (int i2 = 1; i2 < fragen[i].Length - 1; i2++) // Schleife die jedes Element überprüft
                    {
                        if (fragen[i][i2] == fragen[i][fragen[i].Length - 1] && b == true) // Wenn die Antwort falsch war (b = true)
                            pfeil = "<--";                                                 // Setz hinter der richtigen Lösung einen pfeil
                        Console.WriteLine(String.Format("[{0}] = {1} {2}", i2, fragen[i][i2], pfeil));  // Zeigt die möglichen Antworten an
                        pfeil = string.Empty;                                              // Der Peil wird nur einmal genutzt pro schleife
                    }
                    if (b)     // Wenn die Antwort Falsch war ist (b = true)
                    {
                        Console.ReadKey(); // Stopt das Programm das man durch den Pfeil sieht welche Antwort die Richtige war
                        Console.Clear();
                        b = false;         // Stellt b wieder auf false damit die neue Frage gestellt werden kann
                        break;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Bitte geben Sie die Antwort in Zahlen.");
                    Console.Write("Ihre Antwort: ");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out number) && number > 0 && number < fragen[i].Length - 1) // Überprüft die Eingabe
                        {
                            if (fragen[i][number] == fragen[i][fragen[i].Length - 1]) // Überprüft die Eingabe mit dem letzten Element des Arrays also die Lösung
                            {
                                Console.WriteLine("Richtig"); // Gibt Richtig aus und zählt den "richtig" Counter hoch
                                richtig++;
                            }
                            else
                            {
                                Console.WriteLine("Falsch"); // Gibt Falsch aus und zählt den "falsch" Counter hoch
                                b = true;                    // Setzt b auf true damit der Pfeil hinzugefügt wird und sich die Schleife für die Anzeige wiederholt
                                falsch++;
                            }
                            break;
                        }
                        else
                            Console.WriteLine("Invalide Eingabe, erneute Eingabe tätigen.");
                    }
                    if (b)
                    {
                        Console.Clear(); // Wenn b = true Wiederhole die Anzeige mit Pfeil
                        continue;
                    }
                    Console.ReadKey();  // Hält das Programm an damit man sieht ob die Antwort Richtig an
                    Console.Clear();
                    break;
                }
            }
            return new Tuple<int, int>(richtig, falsch);
        }
    }
}
