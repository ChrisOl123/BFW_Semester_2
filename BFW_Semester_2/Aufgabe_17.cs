using System;
using System.Collections.Generic;
using System.IO;

namespace BFW_Semester_2
{
    internal class Aufgabe_17                          // Pfad @"C:\Schule\2. Semester\C#\Aufgabe17.txt"    Home
    {                                         // Pfad @"U:\Csharp\Aufgabe17.txt"
        static List<Tuple<string, List<string>>> mainList = new List<Tuple<string, List<string>>>();
        public static void Start()
        {
            while (true)
            {
                Menu();
                LoadList();
                Verarbeitung();
                SaveList();
            }
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Was möchten Sie tun?");
            Console.WriteLine("[1] Neue Liste erstellen.");
            Console.WriteLine("[2] Liste bearbeiten.");
            Console.WriteLine("[3] Liste löschen.");
        }
        static void Verarbeitung()
        {

            List<string> spalte = new List<string>();
            while (true)
            {
                string name = String.Empty;
                string input = Console.ReadLine().Trim();
                if (input == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Wie möchten Sie die neue Liste nennen?");
                    while (true)
                    {
                        name = "#";
                        name += Console.ReadLine().Trim();
                        if (name.Length == 1 || name[1].ToString() == "#" || name == "-----")
                        {
                            Console.WriteLine("Invalide Eingabe, bitte erneut eingeben.");
                        }
                        else
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine("Was möchten Sie der Liste \"{0}\" hinzufügen?", name.Substring(1, name.Length - 1));
                    while (true)
                    {
                        string content = Console.ReadLine();
                        if (content == string.Empty)
                            break;
                        else if (content[0].ToString() == "#" || content == "-----")
                            Console.WriteLine("Invalide Eingabe, bitte erneut eingeben.");
                        else
                            spalte.Add(content);
                    }
                }
                else if (input == "2")
                {
                    Console.Clear();
                    int i = 1;
                    if (mainList.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Noch keine Liste vorhanden.");
                        Console.ReadKey();
                        return;
                    }
                    foreach (var element in mainList)
                    {
                        Console.WriteLine("[{0}] {1}", i, element.Item1);
                        i++;
                    }
                    string input_2 = Console.ReadLine();
                }
                else if (input == "3")
                {

                }
                else
                {
                    Console.WriteLine("Invalide Eingabe");
                    continue;
                }
                spalte.Add("-----");
                Tuple<string, List<string>> erg = new Tuple<string, List<string>>(name, spalte);
                mainList.Add(erg);
                break;
            }
        }
        static void LoadList()
        {
            string name = string.Empty;
            bool b = false;
            List<string> load = new List<string>();
            if (File.Exists(@"C:\Schule\2. Semester\C#\Aufgabe17.txt"))
            {
                foreach (string line in File.ReadLines(@"C:\Schule\2. Semester\C#\Aufgabe17.txt"))
                {
                    if (line.Length == 0)
                        return;
                    if (line[0].ToString() == "#")
                    {
                        name = line;
                        b = true;
                        continue;
                    }
                    if (b)
                    {
                        load.Add(line);
                        if (line == "-----")
                        {
                            Tuple<string, List<string>> tuple = new Tuple<string, List<string>>(name, load);
                            mainList.Add(tuple);
                            b = false;
                            load = new List<string>();
                        }
                    }
                }
            }
        }
        static void SaveList()
        {

            File.Delete(@"C:\Schule\2. Semester\C#\Aufgabe17.txt");
            foreach (var element in mainList)
            {
                using (StreamWriter file = new StreamWriter(@"C:\Schule\2. Semester\C#\Aufgabe17.txt", append: true))
                {
                    file.WriteLine(element.Item1);
                    for (int i = 0; i < element.Item2.Count; i++)
                    {
                        file.WriteLine(element.Item2[i]);
                    }
                }
            }
            mainList.Clear();
        }
    }
}
