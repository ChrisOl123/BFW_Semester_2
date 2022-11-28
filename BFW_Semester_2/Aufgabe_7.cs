using System;

namespace BFW_Semester_2
{
    enum EyeColor { Braun, Blau, Grün, Grau }
    enum Gender { Männlich, Weiblich, Divers }
    enum dire { West, East, South, North }
    enum Meal { Soup, Burger, Pizza }
    internal class Aufgabe_7
    {
        public static void Start()
        {
            Human spieler = new Human() { Birth = new DateTime(1995,02,01), Size = 190M, Weight = 80M, EyeColor = EyeColor.Blau, Gender = Gender.Männlich, Name = "Spieler" };

            spieler.Eat(Meal.Soup); // Was isst der Spieler
            spieler.Meditate(10); // Wie lange meditiert er

            spieler.Go(dire.West);
            spieler.Go(dire.West);
            for (int i = 0; i < 3; i++)
                spieler.Go(dire.South);

            spieler.Speak("Auf Wiedersehen!"); // Was sagt der Spieler zum abschluss
        }
    }
    class Human
    {
        public DateTime Birth;
        public decimal Size;
        public decimal Weight;
        public EyeColor EyeColor;
        public Gender Gender;
        public string Name;

        public void Go(dire direciton)
        {
            Console.WriteLine(Name+"ist in folgende Richtung gegangen: "+direciton);
        }
        public void Speak(string words) {
            Console.WriteLine(Name+" hat folgendes gesagt: {0} :)",words);
        }
        public void Eat(Meal Meal)
        {
            Console.WriteLine(Name + " hat folgendes gegessen: "+Meal);
        }
        public void Meditate(int duration) {
            Console.WriteLine(Name +" hat {0} Minuten meditiert",duration);
        }
    }

}
