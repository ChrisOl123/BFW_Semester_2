using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    class Aufgabe_5
    {
        public static void Start()
        {
            while (true)
            {
                List<string> liste = new List<string>();
                List<int> erglist = new List<int>();
                Console.WriteLine("Welche Rechnung möchten sie Durchführen");
                string input = Console.ReadLine().Trim();
                int num = -1;
                int temp = 0;
                int counter = 1;
                foreach (var element in input)
                {
                    if (int.TryParse(element.ToString(), out num))
                    {
                        temp *= 10;
                        temp += num;
                    }
                    else
                    {
                        if (element.ToString() == "+" || element.ToString() == "-" || element.ToString() == "*" || element.ToString() == "/")
                        {
                            liste.Add(temp.ToString());
                            liste.Add(element.ToString());
                            temp = 0;
                        }
                    }
                    if (counter == input.Length)
                        liste.Add(temp.ToString());
                    counter++;
                }
                double zwischen = 0;
                do
                {
                    bool b = false;
                    int c = 0;
                    foreach (var element in liste)
                    {
                        if (element == "*")
                        {
                            zwischen = Mal(liste, c);
                            b = true;
                            break;
                        }
                        else if (element == "/")
                        {
                            zwischen = Geteilt(liste, c);
                            b = true;
                            break;
                        }
                        c++;
                    }
                    Speichern(liste, b, c, zwischen);
                    foreach (var element in liste)
                    {
                        c = 1;
                        if (element == "+")
                        {
                            zwischen = Plus(liste, c);
                            b = true;
                            break;
                        }
                        else if (element == "-")
                        {
                            zwischen = Minus(liste, c);
                            b = true;
                            break;
                        }
                        c++;
                    }
                    Speichern(liste, b, c, zwischen);


                } while (liste.Count > 1);
                double ergebnis = Convert.ToDouble(liste[0]);
                Console.WriteLine("Das ist Ihr Ergebnis: " + Math.Round(ergebnis, 2));
                Console.WriteLine();
            }
        }

        public static void Speichern(List<string> liste, bool b, int c, double zwischen)
        {
            if (liste.Count > 1 && b == true)
            {
                liste.RemoveAt(c);
                liste.Insert(c, zwischen.ToString());
                liste.RemoveAt(c + 1);
                liste.RemoveAt(c - 1);
                b = false;
            }
        }

        public static double Mal(List<string> liste, int c)
        {
            double zwischen = Convert.ToDouble(liste[c - 1]) * Convert.ToDouble(liste[c + 1]);
            return zwischen;
        }
        public static double Geteilt(List<string> liste, int c)
        {
            double zwischen = Convert.ToDouble(liste[c - 1]) / Convert.ToDouble(liste[c + 1]);
            return zwischen;
        }
        public static double Plus(List<string> liste, int c)
        {
            double zwischen = Convert.ToDouble(liste[c - 1]) + Convert.ToDouble(liste[c + 1]);
            return zwischen;
        }
        public static double Minus(List<string> liste, int c)
        {
            double zwischen = Convert.ToDouble(liste[c - 1]) - Convert.ToDouble(liste[c + 1]);
            return zwischen;
        }
    }
}
