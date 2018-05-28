using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XmlReader xmlReader = new XmlReader("example.xml");
                xmlReader.testReading();
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("File was not found");
            }
            Console.ReadLine();
            
        }
    }
}
