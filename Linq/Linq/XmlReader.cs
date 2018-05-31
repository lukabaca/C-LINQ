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
        public List<Book> getBooksByGenre(String genre)
        {

            Boolean flag = false;

            List<Book> bookList = new List<Book>();

            foreach (XmlNode book in xmlNodeList)
            {

                String genreName = book.SelectSingleNode("genre").InnerText;
                if (genreName == genre)
                {
                    double price;

                    String author = book.SelectSingleNode("author").InnerText;
                    String title = book.SelectSingleNode("title").InnerText;

                    try
                    {
                        price = Double.Parse(book.SelectSingleNode("price").InnerText, CultureInfo.InvariantCulture);
                    }catch(Exception e)
                    {
                        Console.WriteLine("Couldn't parse book price to double");
                        price = -1;
                    }

                    String publish_date = book.SelectSingleNode("publish_date").InnerText;
                    String description = book.SelectSingleNode("description").InnerText;

                    Book book_ = new Book(author, title, genre, price, publish_date, description);
                    bookList.Add(book_);

                    flag = true;
                }


            }

            if (!flag)
            {
                Console.WriteLine("There is no genre: " + genre);
            }

            return bookList;

        }

        public List<Book> getBooksBy_Genre_Price(String genre, double price)
        {
            //select by price means in this case >= than price in arguments
            Boolean flag = false;

            List<Book> bookList = new List<Book>();

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

                        Book book_ = new Book(author, title, genre, bookPrice, publish_date, description);
                        bookList.Add(book_);

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

            return bookList;
        }
    }
}
