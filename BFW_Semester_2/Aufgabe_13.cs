using System;

namespace BFW_Semester_2
{
    class Aufgabe_13
    {
        public static void Start()
        {
            try
            {
                Console.WriteLine("Ohne Selbstlaute: " + Selbstlaute(null));
                //Console.WriteLine("Ohne e: " + ÜberChar(null, 'e'));               
                //Console.WriteLine("Ist teilbar: " + ZweiTeilbar(22125, 0));                
                //Console.WriteLine("Wurzel: " + Wurzel(-135265));                              
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Die Exeption: " + ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Die Exeption: " + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Die Exeption: " + ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Ungbekannter Fehler");
            }

        }
        /// <summary>
        /// Die Methode nimmt einen String entgegen und entfert alle Selbstlaute.
        /// </summary>
        /// <param name="input">Der String der beschnitten werden soll.</param>
        /// <returns>Gibt den String ohne die Selbstlaute zurück.</returns>
        static string Selbstlaute(string input)
        {
            if (input == null)
                throw new ArgumentNullException("Die Eingabe darf nicht null sein.");

            string[] selbst = new string[] { "a", "e", "i", "o", "u" };
            string res = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                foreach (var element in selbst)
                {
                    if (input[i].ToString().ToLower() == element.ToString())
                        input = input.Replace(input[i].ToString(), string.Empty);
                }
            }
            return input;
        }
        /// <summary>
        /// Die Methode nimmt ein String und ein Char entgegen und entfernt diese Chars.
        /// </summary>
        /// <param name="one">String</param>
        /// <param name="two">Char</param>
        /// <returns>Gibt den String ohne den vergebenen Char aus.</returns>
        static string ÜberChar(string one, char two)
        {
            if (one == null)
                throw new ArgumentNullException("Die Eingabe darf nicht null sein.");

            foreach (var element in one)
            {
                if (element.ToString().ToLower() == two.ToString().ToLower())
                    one = one.Replace(element.ToString(), string.Empty);
            }
            return one;
        }
        /// <summary>
        /// Die Methode nimmt zwei Integer entgegen und prüft ob die erste Zahl durch die Zweite Zahl teilbar ist.
        /// </summary>
        /// <param name="a">1. Zahl</param>
        /// <param name="b">2. Zahl</param>
        /// <returns>Gibt True falls die erste Zahl durch die zweite Zahl teilbar ist.</returns>
        static bool ZweiTeilbar(int a, int b)
        {

            if (b == 0)
                throw new DivideByZeroException("Durch 0 kann nicht geteilt werden.");

            if (a % b == 0)
                return true;
            else
                return false;

        }
        /// <summary>
        /// Die Methode nimmt einen Integer entgegen und ermittelt die Wurzel der Zahl.
        /// </summary>
        /// <param name="input">Die Zahl, von der die Wurzel gezogen werden soll</param>
        /// <returns>Gibt die Wurzel der übergebenen Zahl zurück.</returns>
        static double Wurzel(int input)
        {
            if (input < 0)
                throw new ArgumentOutOfRangeException("Eingabe ist negativ.");
            return Math.Sqrt(input);
        }
    }
}
