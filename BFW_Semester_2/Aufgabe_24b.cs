using System;
using System.Collections.Generic;
using System.Text;

namespace BFW_Semester_2
{
    internal class Aufgabe_24b
    {
        public static void Start()
        {
            Klassenzimmer classZ = new Klassenzimmer() { grafik = "+-------+-------------+------+\n|       +-------------+      |\n|                            |\n" +
                "|                            |\n|  +----+   +----+   +----+  |\n|  |    |   |    |   |    |  |\n|  +----+   +----+   +----+  |\n" +
                "|                            |                           Geben Sie ihre Antwort in Zahlen ein.\n|  +----+   +----+   +----+  |\n|  |    |   |    |   |    |  |\n" +
                "|  +----+   +----+   +----+ -+\n|                             <-- Sie sind hier\n|  +----+   +----+   +----+ -+\n|  |    |   |    |   |    |  |\n" +
                "|  +----+   +----+   +----+  |\n|                            |\n+----------------------------+"};
            Console.WriteLine(classZ.grafik);
        }
    }
    class Klassenzimmer
    {
        public string grafik;
        public int höhe;
        public int breite;
        public int raumnr;

        public void Betreten() { }
        public void Verlassen() { }
    }

}
