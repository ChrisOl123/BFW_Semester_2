using System;

namespace BFW_Semester_2
{
    enum EyeColor { Braun, Blau, Grün, Grau }
    enum Gender { Männlich, Weiblich, Divers }

    class Aufgabe_7
    {
        public static void Start()
        {
            Human spieler = new Human() { Birth = DateTime.Now, Size = 190M, Weight = 80M, EyeColor = EyeColor.Blau, Gender = Gender.Männlich, Name = "Spieler" };
            spieler.Eat("Soup");
            spieler.Go("s");
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

        public void Go(string direciton)
        {
            string[] arr = new string[] { "West", "West", "South", "South", "South" };
            foreach(var element in arr)
            Console.WriteLine(Name + " ist in folgende Richtung gegangen: "§+element);
            return;
        }
        public void Speak(string words) { }
        public void Eat(string Meal)
        {
            Console.WriteLine(Name + " hat folgendes gegessen: Soup");
        }
        public void Meditate(int duration) { }
    }

}
