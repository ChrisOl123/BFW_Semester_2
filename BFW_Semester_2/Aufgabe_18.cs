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
                // Console.ReadKey();
            }
        }
        static int ShowOrdner(string pfad)
        {


            Console.WriteLine(pfad);
            Console.WriteLine("Zum Öffnen Geben Sie die Zahl ein.");
            Console.WriteLine("[.] Ein Ordner zurück.");
            Console.WriteLine("[=] Gesamte Ordnerstruktur anzeigen.");
            Console.WriteLine("[+] Ordner erstellen.");
            Console.WriteLine("[-] Ordner löschen.");
            Console.WriteLine("[#] Ordner verschieben.");
            if (einfügen != string.Empty)
                Console.WriteLine("[*] Ordner einfügen.");
            Console.WriteLine();
            Console.WriteLine("Enthaltene Ordner:");
            ordner = new List<string>();
            foreach (var element in Directory.GetDirectories(pfad))
            {
                ordner.Add(element.Substring(element.LastIndexOf(@"\") + 1));
            }
            for (int i = 0; i < ordner.Count; i++)
            {
                Console.WriteLine("[{0}] {1}", (i + 1), ordner[i]);
            }
            return ordner.Count;
        }
        static void Input(int anzahl)
        {
            while (true)
            {
                int eingabe;
                string input = Console.ReadLine();
                if (int.TryParse(input, out eingabe) && eingabe <= anzahl && eingabe > 0)
                {
                    pfad += "\\" + ordner[eingabe - 1];
                    break;
                }
                else if (input == ".")
                {
                    if (pfad.Length > 60)
                        pfad = pfad.Substring(0, pfad.LastIndexOf(@"\"));
                    break;
                }
                else if (input == "=")
                {
                    pfad = @"C:\Users\Chris\source\repos\BFW_Semester_2\Aufgabe_18\Basis";
                    Console.WriteLine();
                    ShowFolders(pfad);
                    Console.ReadKey();
                    break;
                }
                else if (input == "+")
                {
                    Console.WriteLine("Wie möchten Sie den neuen Ordner nennen?");
                    string ordner = Console.ReadLine();
                    Directory.CreateDirectory(pfad + "\\" + ordner);
                    return;
                }
                else if (input == "-")
                {
                    Console.WriteLine("Welchen Ornder wollen sie löschen? zur Sicherheit korrekten Name eingeben");
                    string löschen = Console.ReadLine();
                    if (Directory.Exists(pfad + "\\" + löschen))
                        Directory.Delete(pfad + "\\" + löschen, true);
                    else
                    {
                        Console.WriteLine("Ordner existiert nicht");
                        Console.ReadKey();
                    }
                    return;
                }
                else if (input == "#")
                {
                    Console.WriteLine("Welchen Ordner möchten Sie verschieben");
                    while (true)
                    {
                        string verschieben = Console.ReadLine();
                        if (int.TryParse(verschieben, out eingabe) && eingabe <= anzahl && eingabe > 0)
                        {
                            einfügen = pfad + "\\" + ordner[eingabe - 1];
                            break;
                        }
                        else
                            Console.WriteLine("Invalide Eingabe");
                    }
                    Console.WriteLine("Gehen Sie nun zu dem Zielordner und drücken Sie [*] zum einfügen.");
                    Console.ReadKey();
                    return;

                }
                else if (input == "*")
                {
                    if (Directory.Exists(pfad + einfügen.Substring(einfügen.LastIndexOf(@"\"))))
                    {
                        Console.WriteLine("Es existiert schon ein Ordner mit diesem Namen");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Directory.Move(einfügen, pfad + einfügen.Substring(einfügen.LastIndexOf(@"\")));
                        einfügen = string.Empty;
                        return;
                    }

                }
                else
                {
                    Console.WriteLine("Invalide Eingabe");
                }
            }
        }
        static void ShowFolders(string path, int deep = 0)
        {
            for (int i = 0; i < deep; i++)
                Console.Write(" - ");
            Console.WriteLine(path.Substring(path.LastIndexOf(@"\") + 1));
            foreach (var element in Directory.GetDirectories(path))
                ShowFolders(element, deep + 1);
        }

    }
}
