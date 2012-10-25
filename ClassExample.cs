using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ReadXML
{
    class Example
    {
        private const String filename = "TrainsAndAnotherStuff.xml";

        public static void Main()
        {
            XmlTextReader reader;
            reader = new XmlTextReader(filename);
            
            reader.WhitespaceHandling = WhitespaceHandling.None;

            Console.WriteLine("До считывания из файла: ");
            Console.WriteLine("********Начало********");
            Passenger.Print();
            Console.WriteLine("********Конец*********\n");

            Passenger ThePassenger = new Passenger(0, "", "", "");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)         
                {
                    switch (reader.Name)
                    {
                        case "ID":
                        reader.Read();
                        ThePassenger.ID = Convert.ToInt32(reader.Value);
                        break;
                        
                        case "FName":
                        reader.Read();
                        ThePassenger.FirstName = reader.Value;
                        break;
                        
                        case "LName":
                        reader.Read();
                        ThePassenger.LastName = reader.Value;
                        break;

                        case "TypeOfTicket":
                        reader.Read();
                        ThePassenger.TypeOfTicket = reader.Value;
                        ThePassenger.Add();
                        break;
                    }
                }
            }
            Console.WriteLine("После считавания из файла:");
            Console.WriteLine("********Начало********");
            Passenger.Print();
            Console.WriteLine("********Конец*********");
        }
    }
}