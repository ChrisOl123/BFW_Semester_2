using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BFW_Semester_2
{
    class Aufgabe_6
    {
        enum Countries { Deutschland, Frankreich, Polen, Italien, Griechenland, Schweiz };
        public static void Start()
        {
            List<Countries> coun = new List<Countries>();

            Console.WriteLine("Bitte geben Sie einen Ländernamen ein:");
            string input = Console.ReadLine().Trim();
            Array arr = Enum.GetValues(typeof(Countries));


        } 
    }