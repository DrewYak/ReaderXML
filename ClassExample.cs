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

            Passenger.Print();

            Passenger ThePassenger = new Passenger(0, "", "", "");
            while (reader.Read())
            {
                if (reader.Name == "ID")
                {
                    reader.Read();
                    ThePassenger.ID = Convert.ToInt16(reader.Value);
                }
                if (reader.Name == "FName")
                {
                    reader.Read();
                    ThePassenger.FirstName = reader.Value;
                }
                if (reader.Name == "LName")
                {
                    reader.Read();
                    ThePassenger.LastName = reader.Value;
                }
                if (reader.Name == "TypeOfTicket")
                {
                    reader.Read();
                    ThePassenger.TypeOfTicket = reader.Value;
                    ThePassenger.Add();
                }
            
            }

            Passenger.Print();
        }
    }
}