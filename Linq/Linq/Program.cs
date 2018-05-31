using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String fileName = "example.xml";
                /*
                XmlReader xmlReader = new XmlReader("example.xml");
                xmlReader.testReading();
                */

                XmlReader xml = new XmlReader(fileName);

                Menu menu = new Menu();
                int choice = 0;
                
                

                do
                {
                    menu.printMenu();
                    choice = menu.getChoice();


                    switch(choice)
                    {
                        case 1:
                        {
                                Console.WriteLine("Write genre of book");
                                String genreName = menu.getInput();
                                xml.getBooksByGenre(genreName);
                                break;
                        }
                        case 2:
                        {
                                xml.getGenreList();
                                break;
                        }
                        case 3:
                        {
                                Console.WriteLine("Write genre of book");
                                String genreName = menu.getInput();

                                Console.WriteLine("Give price of book");
                                
                                try
                                {
                                    double price = Double.Parse(menu.getInput(), CultureInfo.InvariantCulture);
                                    Console.WriteLine("------------------");
                                    xml.getBooksBy_Genre_Price(genreName, price);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    Console.WriteLine("Unable to convert string to double");
                                }

                                break;
                           }

                        default: break;

                    }

                    Console.Out.Flush();
                } while (choice != 0);



            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("File was not found");
            }
            catch(XmlException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Bye bye");
            Console.ReadLine();
            
        }
    }
}
