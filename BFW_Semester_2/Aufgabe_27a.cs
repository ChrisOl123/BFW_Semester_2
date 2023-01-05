using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BFW_Semester_2
{
    class Aufgabe_27a
    {
        static string ip = "localhost";
        static string port = "3306";
        static string username = "Christian";
        static string password = "wert123!";
        static string dbname = "aufgabe_27";
        public static void Start()
        {
            string ConnectionString = "SERVER=" + ip + ";" +
            "PORT=" + port + ";" +
            "DATABASE=" + dbname + ";" +
            "UID=" + username + ";" +
            "PASSWORD=" + password + ";";
            //Öffnen der Verbindung
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            //SQL-Befehl ohne Rückgabetyp ausführen
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS Example (ID INTEGER AUTO_INCREMENT PRIMARY KEY, Something VARCHAR(500));";
            //cmd.ExecuteReader();
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE IF NOT EXISTS Mensch (M_ID INTEGER AUTO_INCREMENT PRIMARY KEY, M_Name VARCHAR(255), M_Nachname VARCHAR(255), M_Alter INTEGER);";
            cmd.ExecuteNonQuery();
            //SQL-Befehle mit Rückgabewerten
            //Definiere zuerst Speicherobjekt
            List<string> stringList = new List<string>();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT M_ID FROM mensch GROUP BY M_ID";
            var reader = command.ExecuteReader();
           
            while (reader.Read())
            {
                if (reader.IsDBNull(0))
                    continue;
                reader.GetString(0); //Per Index
            }
            reader.Close();
            int temp = 0;
            foreach(var element in stringList)
            {
                if (int.TryParse(element, out int zahl))
                    if (zahl > temp)
                        temp = zahl;
            }
            while (true)
            {
                Menu(temp,connection);
            }
        }
        static void Unterricht()
        {
            string ConnectionString = "SERVER=" + ip + ";" +
            "PORT=" + port + ";" +
            "DATABASE=" + dbname + ";" +
            "UID=" + username + ";" +
            "PASSWORD=" + password + ";";
            //Öffnen der Verbindung
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            //SQL-Befehl ohne Rückgabetyp ausführen
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS Example (ID INTEGER AUTO_INCREMENT PRIMARY KEY, Something VARCHAR(500));";
            //cmd.ExecuteReader();
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE IF NOT EXISTS Mensch (M_ID INTEGER AUTO_INCREMENT PRIMARY KEY, M_Name VARCHAR(255), M_Nachname VARCHAR(255), M_Alter INTEGER);";
            cmd.ExecuteNonQuery();
            /*
                                    //SQL-Befehle mit Rückgabewerten
                                    //Definiere zuerst Speicherobjekt
                                    List<string> stringList = new List<string>();
                                    MySqlCommand command = connection.CreateCommand();
                                    command.CommandText = "SELECT ID, Something FROM Example WHERE ID > 10;";
                                    var reader = command.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        if (reader.IsDBNull(0))
                                            continue;
                                        //reader.GetString(0); //Per Index
                                        stringList.Add(reader.GetString("Something")); //Per Name
                                    }
                                    reader.Close();
            */
        }
        static void Menu(int zahl, MySqlConnection connection)
        {
            string input;
            Console.WriteLine("Was möchten Sie tun?");
            Console.WriteLine("[1] Mensch erstellen");
            Console.WriteLine("[2] Mensch bearbeiten");
            Console.WriteLine("[3] Mensch löschen");
            while (true)
            {
                input = Console.ReadLine();
                if (input == "1")
                {
                    Erstellen(zahl, connection);
                    break;
                }
                else if (input == "2")
                {
                    Bearbeiten(connection);
                    break;
                }
                else if (input == "3")
                {
                    Löschen();
                    break;
                }
                else
                    Console.WriteLine("Invalide Eingabe! Erneut Eingabe tätigen.");
            }
            Console.Clear();
        }
        static void Erstellen(int zahl, MySqlConnection connection)
        {
            int id = zahl;
            Console.Clear();
            Console.WriteLine("Vorname?");
            string vname = Console.ReadLine();
            Console.WriteLine("Nachname?");
            string name = Console.ReadLine();
            Console.WriteLine("Alter?");
            string alter = Console.ReadLine();
            //SQL-Befehl ohne Rückgabetyp ausführen
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = string.Format("INSERT INTO mensch(M_ID, M_Name, M_Nachname, M_Alter) VALUES ({0},'{1}','{2}','{3}');", id, vname, name, alter);
            cmd.ExecuteNonQuery();
            return;
        }
        static void Bearbeiten(MySqlConnection connection)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT M_ID, M_Name, M_Nachname, M_Alter FROM mensch";
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0))
                    continue;
                reader.GetString(0); //Per Index
            }
            reader.Close();
        }
        static void Löschen()
        {

        }
    }
}