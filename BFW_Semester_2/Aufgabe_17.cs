using System;
using System.Collections.Generic;
using System.IO;

namespace BFW_Semester_2
{
    class Aufgabe_17
    {                                         // Pfad @"U:\Csharp\Aufgabe17.txt"
        static List<Tuple<string, List<string>>> mainList = new List<Tuple<string, List<string>>>();
        public static void Start()
        {
            Menu();
        }
        static void Input()
        {

        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welche Liste möchten Sie bearbeiten?");
            LoadList();
        }
        static void LoadList()
        {
            List<string> load = new List<string>();
            Tuple<string, List<string>> tuple;
            if (File.Exists(@"U:\Csharp\Aufgabe17.txt"))
            {
                foreach (string line in File.ReadAllLines(@"U:\Csharp\Aufgabe17.txt"))
                {
                    load.Add(line);
                    tuple = new Tuple<string, List<string>>();
                    Console.WriteLine(mainList);
                }
            }
            else
                File.WriteAllText(@"U:\Csharp\Aufgabe17.txt", " ");

        }
        static void SaveList()
        { 

        }

    }
}
