using System;
using EgoEngineLibrary.Xml;
using System.IO;

namespace EEXMLConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Expecting 3 arguments:");
                Console.WriteLine();
                Console.WriteLine("EEXMLConverter b/p <infile> <outfile>");
                Console.WriteLine();
                Console.WriteLine("b/p       = convert to binary/plainXML (target format)");
                Console.WriteLine("<infile>  = The file to convert");
                Console.WriteLine("<outfile> = The target filename");
            }
            else
            {
                if (args[0] == "p") ConvertBXML2XML(args[1], args[2]);
                if (args[0] == "b") ConvertXML2BXML(args[1], args[2]);
            }
        }


        private static void ConvertBXML2XML(string infile, string outfile)
        {
            XmlFile file = new XmlFile(File.Open(infile, FileMode.Open, FileAccess.Read, FileShare.Read));
            file.Write(File.Open(outfile, FileMode.Create, FileAccess.Write, FileShare.Read), XMLType.Text);
        }


        private static void ConvertXML2BXML(string infile, string outfile)
        {
            XmlFile file = new XmlFile(File.Open(infile, FileMode.Open, FileAccess.Read, FileShare.Read));
            file.Write(File.Open(outfile, FileMode.Create, FileAccess.Write, FileShare.Read));
        }


    }
}
