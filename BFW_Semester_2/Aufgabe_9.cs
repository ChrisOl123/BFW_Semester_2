using System;
using System.Xml.Linq;

namespace BFW_Semester_2
{
    public enum Marken { Audi, Mercedes, BMW, Nissan, VW }
    public enum Sitze { Stoff, Leder, Samt, Kunststoff, Holz };
    public enum Color { Rot, Blau, Grün, Gelb, Lila, Pink, Grau, Silber }
    internal class Aufgabe_9
    {
        public static void Start()
        {
            Auto car_1 = new Auto(Marken.Audi, Color.Blau, 4.60) { Sitz = Sitze.Leder, KW = 160 };
            Auto car_2 = new Auto(Marken.BMW, Color.Silber, 4.20) { Sitz = Sitze.Samt, KW = 140 };
            Auto car_3 = new Auto(Marken.Mercedes, Color.Grau, 5.30);

            car_1.Fahren(3);
            car_2.Fahren(3);
            car_3.Fahren(3);

            car_1.RadioAnAus(true);
            car_1.Lautstärke(10);
            car_1.Lautstärke(-3);

            car_2.Temperatur(22);

            car_1.Fahren(3);
            car_2.Fahren(3);
            car_3.Fahren(3);

            car_3.Temperatur(20);

            Console.ReadLine();
            Ausgabe(car_1);
            Ausgabe(car_2);
            Ausgabe(car_3);
        }
        public static void Ausgabe(Auto auto)
        {

            
            Console.Clear();
            Console.WriteLine("Das Auto ist ein {0}, besitzt die Farbe {1} und ist {2} Meter lang.", auto.Marke, auto.Farbe, auto.Länge);
            Console.WriteLine("Es besitzt {0} Sitze und eine Leistung von {1} KW.", auto.Sitz, auto.KW);
            Console.WriteLine("Das Radio ist {0}.", auto.Radio);
            if (auto.Radio == "an")
                Console.WriteLine("Die Radiolautstärke beträgt {0}.", auto.RadioLaut);
            if (auto.Temper != 0)
                Console.WriteLine("Die Temperatureinstellung des {0} lautet {1}°C.", auto.Marke, auto.Temper);
            Console.WriteLine("Der {0} ist {1} Meter gefahren", auto.Marke, auto.Gefahren);
            Console.ReadLine();
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
        public Auto(Marken marke, Color farbe, double länge)
        {
            Marke = marke;
            Farbe = farbe;
            Länge = länge;
        }
        public void Fahren(int anzahl)
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
