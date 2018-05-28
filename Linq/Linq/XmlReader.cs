using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Linq
{
    class XmlReader
    {
        private String xmlFileName;
        private XmlTextReader reader;

        public XmlReader(String fileName)
        {
            this.reader = new XmlTextReader(fileName);
            this.xmlFileName = fileName;
        }

        public void testReading()
        {
            while(reader.Read())
            {
                Console.WriteLine(reader.Name);

            }
            Console.ReadLine();
        }
    }
}
