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

            while (reader.Read())
            {
                Console.WriteLine("Name: {0}", reader.Name);
                Console.WriteLine("Value: {0}", reader.Value);
                Console.WriteLine("ValueType: {0}", reader.ValueType);
            }
        }
    }
}