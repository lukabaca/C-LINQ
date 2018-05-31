using System;
using System.Collections.Generic;
using System.Globalization;
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
        private XmlNodeList xmlNodeList;


        public XmlReader(String fileName)
        {
            this.xmlDoc = new XmlDocument();

            this.xmlDoc.Load(fileName);

            this.xmlFileName = fileName;

            xmlNodeList = xmlDoc.GetElementsByTagName("book");
        }

        public void getGenreList()
        {
            HashSet<String> genreList = new HashSet<string>();
            foreach (XmlNode book in xmlNodeList)
            {
                genreList.Add(book["genre"].InnerText);
            }

            foreach (String genreName in genreList)
            {
                Console.WriteLine(genreName);
            }

        }
        public void getBooksByGenre(String genre)
        {

            Boolean flag = false;

            foreach (XmlNode book in xmlNodeList)
            {

                String genreName = book.SelectSingleNode("genre").InnerText;
                if (genreName == genre)
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

                    flag = true;
                }


            }

            if (!flag)
            {
                Console.WriteLine("There is no genre: " + genre);
            }


        }

        public void getBooksBy_Genre_Price(String genre, double price)
        {
            //select by price means in this case >= than price in arguments
            Boolean flag = false;

            foreach (XmlNode book in xmlNodeList)
            {
                String genreName = book.SelectSingleNode("genre").InnerText;

                try
                {
                    double bookPrice = Double.Parse(book.SelectSingleNode("price").InnerText, CultureInfo.InvariantCulture);

                    if (genreName == genre && bookPrice >= price)
                    {
                        String author = book.SelectSingleNode("author").InnerText;
                        String title = book.SelectSingleNode("title").InnerText;
                        String priceBook = book.SelectSingleNode("price").InnerText;
                        String publish_date = book.SelectSingleNode("publish_date").InnerText;
                        String description = book.SelectSingleNode("description").InnerText;

                        Console.WriteLine("Author: " + author);
                        Console.WriteLine("Title: " + title);
                        Console.WriteLine("Price: " + priceBook);
                        Console.WriteLine("Publish date: " + publish_date);
                        Console.WriteLine("Description: " + description);

                        Console.WriteLine("------------------");


                        flag = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Unable to convert string to double");
                }

                

            }

            if (!flag)
            {
                Console.WriteLine("There are no books for your parametres in search");
            }
        }
    }
}
