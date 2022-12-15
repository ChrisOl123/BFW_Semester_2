using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BFW_Semester_2
{
    class Schulaufgabe
    {
       static List<Tuple<int, string, int>> liste = new List<Tuple<int, string, int>>();
        public static void Start()
        {
            ReadList();
            List<Tuple<int, string>> ergebnis = new List<Tuple<int, string>>(Verarbeitung());
            foreach(var element in ergebnis)
            {
                Console.WriteLine(element);
            }
        }
        static void ReadList()
        {            
            string pfad = @"C:\Users\christian.olwitz\Desktop\Aufgabe_4_Vorlage.superdatei";
            
            

            if (File.Exists(pfad)){
                foreach (string line in File.ReadLines(pfad))
                {
                    // 1 = 0-30, 2 = 30-65, 3 = 66+
                    int altersgruppe = -1;
                    int num = -1;
                    int num2 = -1;
                    string farbe = string.Empty;
                    int reaktion = 0;
                    int temp = 0;
                    int counter = 0;
                    foreach(var element in line)
                    {
                        if (int.TryParse(element.ToString(), out num) && counter == 0)
                        {
                            temp *= 10;
                            temp += num;
                        }
                        else if (element.ToString() == "X")
                            counter++;
                        if (counter == 3)
                        {
                            farbe += element;
                        }
                        else if (counter == 6 && int.TryParse(element.ToString(), out num2))
                        {
                            temp *= 10;
                            temp += num2;
                        }
                    }
                    if (temp <= 30)
                    {
                        altersgruppe = 1;
                    }
                    else if (temp > 30 && temp <= 65)
                    {
                        altersgruppe = 2;
                    }
                    else if (temp >= 66)
                    {
                        altersgruppe = 3;
                    }
                    Tuple<int, string, int> tuple = new Tuple<int, string, int>(altersgruppe, farbe, reaktion);
                    liste.Add(tuple);
                }
            }
            else
                Console.WriteLine("Datei nicht vorhanden");
        }
        static List<Tuple<int, string>> Verarbeitung()
        {
            List<Tuple<int, string>> ergebnisListe = new List<Tuple<int, string>>();
            int alter1 = 0;
            int alter2 = 0;
            int alter3 = 0;
            string farbe = string.Empty;
            int reaktionszeit = 0;
            int altersgruppen;
            int durchschnitt;
            
            foreach(var element in liste)
            {
                // 1 = 0-30
                if (element.Item1 == 1)  
                {
                    alter1++;
                    reaktionszeit += element.Item3;
                    farbe = element.Item2;
                }// 2 = 30-65
                else if (element.Item1 == 2)
                {
                    alter2++;
                    reaktionszeit += element.Item3;
                    farbe = element.Item2;
                }// 3 = 66+
                else if (element.Item1 == 3)
                {
                    alter3++;
                    reaktionszeit += element.Item3;
                    farbe = element.Item2;
                }

            }
            altersgruppen = alter1 + alter2 + alter3;
            durchschnitt = altersgruppen / reaktionszeit;

            ergebnisListe.Add(new Tuple<int, string>(durchschnitt, farbe));
            return ergebnisListe;
        }
    }
}
