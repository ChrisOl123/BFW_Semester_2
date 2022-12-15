using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters.Binary;

namespace BFW_Semester_2
{
    internal class Aufgabe_19
    {
        static string pfad = @"C:\Users\Chris\Desktop";
        static List<Mensch> mainList = new List<Mensch>();
        public static void Start()
        {
            while (true)
            {
                Menu();
                Verarbeitung();
            }
        }
        static void Menu()
        {
            Console.WriteLine("Menschen:");
            Console.WriteLine("[1] Erstellen");
            Console.WriteLine("[2] Bearbeiten");
            Console.WriteLine("[3] Löschen");
        }
        static void Verarbeitung()
        {
            while (true)
            {
                if (!(int.TryParse(Console.ReadLine(), out int zahl) && zahl > 0 && zahl <= 3))
                    Console.WriteLine("Invalide Eingabe.");
                else
                {
                    if (zahl == 1)
                    {
                        Erstellen();
                        break;
                    }
                    else if (zahl == 2)
                    {
                        Bearbeiten();
                        break;
                    }
                    else
                    {
                    }
                }
            }
            static void Erstellen()
            {
                Mensch human = new Mensch();
                while (true)
                {
                    List<string> attribute = new List<string>() { human.Vorname, human.NachName, human.Gender, human.Birth };
                    string[] arr = new string[] { "Vorname", "Nachname", "Geschlecht", "Geburtsdatum" };
                    Console.Clear();
                    Console.WriteLine("Ein neuer Mensch wurde erstellt.");
                    Console.WriteLine("Was möchten Sie eingeben?");
                    for (int i = 0; i < arr.Length; i++)
                        Console.WriteLine(string.Format("[{0}] {1}: {2}", i + 1, arr[i], attribute[i]));
                    Console.WriteLine("[5] Speichern");
                    string input = Console.ReadLine();
                    if (input == "")
                    {
                        Console.Clear();
                        break;
                    }
                    if (int.TryParse(input, out int zahl) && zahl > 0 && zahl <= 5)
                    {
                        if (zahl == 1)
                        {
                            Console.WriteLine("Vorname?");
                            human.Vorname = Console.ReadLine();
                        }
                        else if (zahl == 2)
                        {
                            Console.WriteLine("Nachname?");
                            human.NachName = Console.ReadLine();
                        }
                        else if (zahl == 3)
                        {
                            Console.WriteLine("Geschlecht?");
                            human.Gender = Console.ReadLine();
                        }
                        else if (zahl == 4)
                        {
                            Console.WriteLine("Geburstag?");
                            human.Birth = Console.ReadLine();
                        }
                        else if (zahl == 5)
                        {
                            mainList.Add(new Mensch() { Vorname = human.Vorname, NachName = human.NachName, Birth = human.Birth });
                            break;
                        }
                        
                    }
                    else
                        Console.WriteLine("Invalide Eingabe");
                }
                Speichern();
            }
        }
        static void Bearbeiten()
        {
            Laden();
            Console.Clear();
            foreach (var element in mainList)
                Console.WriteLine(element.Vorname);
            Console.ReadKey();
        }
        static void Löschen()
        {

        }
        static void Laden()
        {
            byte[] b = File.ReadAllBytes(pfad+@"\Text.txt");
            var element = FromByteArray<List<Mensch>>(b);
            mainList = element;
        }
        static void Speichern()
        {
            byte[] msg = ToByteArray(mainList);
            File.WriteAllBytes(pfad+@"\Text.txt", msg);
        }
        public static byte[] ToByteArray<T>(T obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using(MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }

        [Serializable]
        private class Mensch
        {
            public string Vorname = "undefined";
            public string NachName = "undefined";
            public string Gender = "undefined";
            public string Birth = "undefined";
            public int ID = 0;
        }
    }
}
