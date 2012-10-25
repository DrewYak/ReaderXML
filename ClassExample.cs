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
            Passenger.Print();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)         
                {
                    switch (reader.Name)
                    {
                        case "Passenger":
                        
                        Passenger ThePassenger = new Passenger(0, "", "", "");
                        reader.Read();

                        reader.ReadStartElement("ID");
                        ThePassenger.ID = reader.ReadContentAsInt();
                        reader.ReadEndElement();

                        reader.ReadStartElement("FName");
                        ThePassenger.FirstName = reader.ReadString();
                        reader.ReadEndElement();

                        reader.ReadStartElement("LName");
                        ThePassenger.LastName = reader.ReadString();
                        reader.ReadEndElement();

                        reader.ReadStartElement("TypeOfTicket");
                        ThePassenger.TypeOfTicket = reader.ReadString();
                        reader.ReadEndElement();

                        ThePassenger.Add();
                        
                        break;
                    }
                }
            }
            Console.WriteLine("После считавания из файла:");
            Passenger.Print();
        }
    }
}