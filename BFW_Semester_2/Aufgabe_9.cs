using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    public enum Marken { Audi, BMW, Mercedes, Nissan, VW }
    public enum Sitze { Stoff, Leder, Samt, Kunststoff, Holz };                       // Enum´s erstellen
    public enum Color { Rot, Blau, Grün, Gelb, Lila, Pink, Grau, Silber }
    internal class Aufgabe_9
    {
        public static void Start()
        {
            List<Auto> carList = new List<Auto> { 
                new Auto(Marken.Audi, Color.Blau, 4.60) { Sitz = Sitze.Leder, KW = 160 },       // Liste mit 3 Autos erstellen die jeweils verschiedene Werte erhalten
                new Auto(Marken.BMW, Color.Silber, 4.20) { Sitz = Sitze.Samt, KW = 140 }, 
                new Auto(Marken.Mercedes, Color.Grau, 5.30) };


            DriveThree(carList);                        // 3x nach vorne 

            carList[0].RadioAnAus(true);                // Radio einschalten
            carList[0].Lautstärke(10);
            carList[0].Lautstärke(-3);                  // Lautstärke erst auf 10 stellen und dann um 3 reduzieren

            carList[1].Temperatur(22);                  // Temperatur auf 22 stellen

            DriveThree(carList);                        // 3x nach vorne fahren

            carList[2].Temperatur(20);                  // Temperatur auf 20 stellen

            Console.ReadKey();

            foreach (var element in carList)            // Ausgabe 
                Ausgabe(element);
        }
        static void Ausgabe(Auto auto)
        {
            Console.Clear();
            Console.WriteLine("Das {0}. Auto ist ein {1}, besitzt die Farbe {2} und ist {3} Meter lang.", (int)auto.Marke+1, auto.Marke, auto.Farbe, auto.Länge);
            Console.WriteLine("Es besitzt {0} Sitze und eine Leistung von {1} KW.", auto.Sitz, auto.KW);
            Console.WriteLine("Das Radio ist {0}.", auto.Radio);

            if (auto.Radio == "an")
                Console.WriteLine("Die Radiolautstärke beträgt {0}.", auto.RadioLaut);

            if (auto.Temper != 0)
                Console.WriteLine("Die Temperatureinstellung des {0} lautet {1}°C.", auto.Marke, auto.Temper);

            Console.WriteLine("Der {0} ist insgesamt {1} Meter gefahren", auto.Marke, auto.Gefahren);
            Console.ReadKey();
        }
        static void DriveThree(List<Auto> carList)
        {
            foreach (var element in carList)            // 3x nach vorne fahren
                element.Fahren(3);
        }
    }
    public class Auto
    {
        public Marken Marke;
        public Color Farbe;
        public double Länge;
        public int KW = 75;
        public Sitze Sitz = Sitze.Stoff;
        public int RadioLaut;
        public string Radio = "aus";
        public int Temper;
        public int Gefahren;
        public Auto(Marken marke, Color farbe, double länge)   // Konstruktor 
        {
            Marke = marke;
            Farbe = farbe;
            Länge = länge;
        }
        public void Fahren(int anzahl)                         // Methoden
        {
            Gefahren += anzahl * KW * 2;
            Console.WriteLine("Der {0} fährt {1} mal nach vorne und erreicht {2} Meter.", Marke, anzahl, Gefahren);
        }
        public void RadioAnAus(bool b)
        {
            if (b)
            {
                Console.WriteLine("Im " + Marke + " wurde das Radio eingeschaltet.");
                Radio = "an";
            }
            else
            {
                Console.WriteLine("Im " + Marke + " wurde das Radio ausgeschaltet.");
                Radio = "aus";
            }
        }
        public void Lautstärke(int laut)
        {
            RadioLaut += laut;
            Console.WriteLine("Im " + Marke + " wurde das Radio auf " + RadioLaut + " gestellt.");
        }
        public void Temperatur(int temp)
        {
            Temper = temp;
            Console.WriteLine("Im " + Marke + " wurde die Temperatur auf " + Temper + "°C gestellt.");
        }
    }
}
