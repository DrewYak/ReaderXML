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
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                    Console.WriteLine("<{0}>:", reader.Name);
                    break;

                    case XmlNodeType.Text:
                    Console.WriteLine("    {0}", reader.Value);
                    break;

                }
            }
        }
    }
}