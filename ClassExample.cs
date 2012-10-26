using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ReadXML
{
    class Example
    {
        private const string filename = "TrainsAndAnotherStuff.xml";

        public static void Main()
        {
            Console.WriteLine("До считывания из файла: ");
            Passenger.Print();

            Passenger.AddDataFromFile(filename);

            Console.WriteLine("После считывания из файла:");
            Passenger.Print();
        }
    }
}