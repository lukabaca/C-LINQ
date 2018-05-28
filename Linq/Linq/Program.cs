using System;
using System.Collections.Generic;
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
                                xml.getElementsByGenre("Fantasy");
                                break;
                        }
                        case 2:
                        {
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
            Console.ReadLine();
            
        }
    }
}
