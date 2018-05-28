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
        private XmlDocument xmlDoc;

       

        public XmlReader(String fileName)
        {
            this.xmlDoc = new XmlDocument();

            this.xmlDoc.Load(fileName);

            this.xmlFileName = fileName;
        }

        public void getElementsByGenre(String genre)
        {
            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName("book");
            HashSet<String> listOfGenres = new HashSet<String>();

            

            foreach(XmlNode book in xmlNodeList)
            {

                String genreName = book.SelectSingleNode("genre").InnerText;
                if(genreName == genre)
                {
                    String author = book.SelectSingleNode("author").InnerText;
                    String title = book.SelectSingleNode("title").InnerText;
                    String price = book.SelectSingleNode("price").InnerText;
                    String publish_date = book.SelectSingleNode("publish_date").InnerText;
                    String description = book.SelectSingleNode("description").InnerText;

                    Console.WriteLine("Author: " + author);
                    Console.WriteLine("Title: " + title);
                    Console.WriteLine("Price: " + price);
                    Console.WriteLine("Publish date: " + publish_date);
                    Console.WriteLine("Description: " + description);

                    Console.WriteLine("------------------");
                }
                //Console.WriteLine("Author: " + book.Attributes.GetNamedItem("title").Value);
                /*
                listOfGenres.Add(book["genre"].InnerText);
                XmlNodeList childNode = book.ChildNodes;
                foreach(XmlNode node in childNode)
                {
                    Console.WriteLine(node.InnerText + "\\");
                }
                */

                
            }
            /*
            foreach (String str in listOfGenres)
            {
                if(str == genre)
                {
                   Console.WriteLine()
                }
                Console.WriteLine(str);
            }
            */


        }

        public void testNodes()
        {

        }
    }
}
