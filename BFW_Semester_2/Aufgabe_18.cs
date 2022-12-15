using System;
using System.Collections.Generic;
using System.IO;

namespace BFW_Semester_2
{
    internal class Aufgabe_18
    {
        static string einfügen = string.Empty;
        static string pfad = @"C:\Users\Chris\source\repos\BFW_Semester_2\Aufgabe_18\Basis";
        static List<string> ordner = new List<string>();
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Input(ShowOrdner(pfad));
            }
        }
        static int ShowOrdner(string pfad) // Zeigt das Menü an und alle Ordner in dem Verzeichnis
        {
            Console.WriteLine(pfad); 
            Console.WriteLine("Zum Öffnen Geben Sie die Zahl ein.");
            Console.WriteLine("[.] Ein Ordner zurück.");
            Console.WriteLine("[=] Gesamte Ordnerstruktur anzeigen.");
            Console.WriteLine("[+] Ordner erstellen.");
            Console.WriteLine("[-] Ordner löschen.");
            Console.WriteLine("[#] Ordner verschieben.");
            if (einfügen != string.Empty)   // Wenn die Variable "einfügen" leer ist, soll das nicht angezeigt werden
                Console.WriteLine("[*] Ordner einfügen.");
            Console.WriteLine();
            Console.WriteLine("Enthaltene Ordner:");
            ordner = new List<string>();
            foreach (var element in Directory.GetDirectories(pfad))
                ordner.Add(element.Substring(element.LastIndexOf(@"\") + 1)); // Speichert alle befindlichen Ordner in eine Liste
            for (int i = 0; i < ordner.Count; i++)
                Console.WriteLine("[{0}] {1}", (i + 1), ordner[i]); // Gibt die Liste aus mit allen Ordner in dem jeweiligen Pfad
            return ordner.Count; // Gibt die Zahl zurück wiev iele Ordner gespeichert sind in der Liste
        }
        static void Input(int anzahl)  // Nimmt Eingaben entgegen und verarbeitet diese
        {
            while (true)
            {
                int eingabe;
                string input = Console.ReadLine();
                if (int.TryParse(input, out eingabe) && eingabe <= anzahl && eingabe > 0) // Überprüft die Eingabe
                {
                    pfad += "\\" + ordner[eingabe - 1]; // Geht in den Ordner hinein anhand der ihm übergebenen Nummer
                    break;
                }
                else if (input == ".") // Geht einen Ordner zurück
                {
                    if (pfad.Length > 0) // Limitiert das herausgehen bis zum Basisordner
                        pfad = pfad.Substring(0, pfad.LastIndexOf(@"\")); // Entfernt den letzten Ordnername aus dem Pfad
                    break;
                }
                else if (input == "=") // Zeigt die Gesamte Ordnerstruktur zusätzlich mit Tiefe der Ordner
                {
                    pfad = @"C:\Users\Chris\source\repos\BFW_Semester_2\Aufgabe_18\Basis"; // Absoluter Pfad zum Basisordner
                    Console.WriteLine();
                    ShowFolders(pfad);
                    Console.ReadKey();
                    break;
                }
                else if (input == "+") // Erstellt einen Ordner in den aktuellen Pfad mit frei wählbaren Namen
                {
                    Console.WriteLine("Wie möchten Sie den neuen Ordner nennen?");
                    string ordner = Console.ReadLine();
                    Directory.CreateDirectory(pfad + "\\" + ordner); // Fügt einen Ordner ein
                    return;
                }
                else if (input == "-") // Löscht den Ordner
                {
                    Console.WriteLine("Welchen Ornder wollen sie löschen? zur Sicherheit korrekten Name eingeben");
                    string löschen = Console.ReadLine();
                    if (Directory.Exists(pfad + "\\" + löschen)) // Überprüft ob der Ordner überhaupt existiert
                        Directory.Delete(pfad + "\\" + löschen, true); // Löscht rekursiv(alles im inneren) den gewählten Ordner
                    else
                    {
                        Console.WriteLine("Ordner existiert nicht");
                        Console.ReadKey();
                    }
                    return;
                }
                else if (input == "#") // Schneidet den gewählten Ordner aus
                {
                    Console.WriteLine("Welchen Ordner möchten Sie verschieben");
                    while (true)
                    {
                        string verschieben = Console.ReadLine();
                        if (int.TryParse(verschieben, out eingabe) && eingabe <= anzahl && eingabe > 0) // Überprüft die Eingabe
                        {
                            einfügen = pfad + "\\" + ordner[eingabe - 1]; // Speichert den gewünschten Zielordner durch den Pfad
                            break;
                        }
                        else
                            Console.WriteLine("Invalide Eingabe");
                    }
                    Console.WriteLine("Gehen Sie nun zu dem Zielordner und drücken Sie [*] zum einfügen.");
                    Console.ReadKey();
                    return;
                }
                else if (input == "*") // Fügt den zwischengespeicherten Ordner in das aktuelle Verzeichnis
                {
                    if (Directory.Exists(pfad + einfügen.Substring(einfügen.LastIndexOf(@"\")))) // Überprüft ob der Ordner schon existiert
                    {
                        Console.WriteLine("Es existiert schon ein Ordner mit diesem Namen");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Directory.Move(einfügen, pfad + einfügen.Substring(einfügen.LastIndexOf(@"\"))); // Verschiebt den Ordner anhand der Pfade
                        einfügen = string.Empty; // Löscht alles in der globalen Variable
                        return;
                    }
                }
                else
                    Console.WriteLine("Invalide Eingabe");
            }
        }
        static void ShowFolders(string path, int deep = 0) // Zeigt alle Ordner 
        {
            for (int i = 0; i < deep; i++) // Zeigt die Tiefe der Ordnerstruktur anhand von Bindestrichen
                Console.Write(" - ");
            Console.WriteLine(path.Substring(path.LastIndexOf(@"\") + 1)); // Zeigt nur den Letzten Ordner des Pfads an
            foreach (var element in Directory.GetDirectories(path))
                ShowFolders(element, deep + 1); // Anhand einer Rekursion werden alle Ordner aufgerufen
        }
    }
}