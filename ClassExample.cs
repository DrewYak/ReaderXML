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
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            XmlNodeList ListID              = doc.GetElementsByTagName("ID");
            XmlNodeList ListFName           = doc.GetElementsByTagName("FName");
            XmlNodeList ListLName           = doc.GetElementsByTagName("LName");
            XmlNodeList ListTipeOfTicket    = doc.GetElementsByTagName("TypeOfTicket");

            for (int i = 0; i < ListID.Count; i++)
            {
                Passenger ThePassenger      = new Passenger(0, "", "", "");

                ThePassenger.ID             = Convert.ToInt32(ListID[i].InnerText);
                ThePassenger.FirstName      = ListFName[i].InnerText;
                ThePassenger.LastName       = ListLName[i].InnerText;
                ThePassenger.TypeOfTicket   = ListTipeOfTicket[i].InnerText;

                ThePassenger.Add();
            }

            Console.WriteLine("После считавания из файла:");
            Passenger.Print();
        }
    }
}