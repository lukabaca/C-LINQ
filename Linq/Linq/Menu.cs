using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq
{
    class Menu
    {
        private XMLreader fileReader;
        private IEnumerable<XElement> resultBooks;

        private String category;
        private String stringValue;

        private double doubleValue;
        public void printResult()
        {
            foreach (XElement xEle in resultBooks)
            {
                Console.WriteLine("Autor: " + xEle.Element("author").Value);
                Console.WriteLine("Tytuł: " + xEle.Element("title").Value);
                Console.WriteLine("Kategoria: " + xEle.Element("genre").Value);
                Console.WriteLine("Cena: " + xEle.Element("price").Value);
                Console.WriteLine("Data publikacji: " + xEle.Element("publish_date").Value);
                Console.WriteLine("Opis: " + xEle.Element("description").Value);
                Console.WriteLine("------------");
                Console.WriteLine();

            }
        }
        public void showMenu()
        {
            int choose = 0;
            do
            {
                try
                {
                    fileReader = new XMLreader();
                    Console.WriteLine("------MENU------");
                    Console.WriteLine("1.Szukaj po string: ");
                    Console.WriteLine("2.Szukaj po double: ");

                    Console.WriteLine("0.Wyjdź");
                    Console.WriteLine();
                    try
                    {
                        choose = Convert.ToInt32(Console.ReadLine());

                        if (choose != 0)
                        {
                            makeChoice(choose);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Źle podane dane!");
                        choose = -1;
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Xml file was not found");
                    choose = 0;
                }


            } while (choose != 0);

        }

        private void makeChoice(int choose)
        {


            switch (choose)
            {
                case 1:
                    Console.WriteLine("Podaj kategorie: ");
                    category = Console.ReadLine();

                    Console.WriteLine("Podaj wartosc: ");
                    stringValue = Console.ReadLine();

                    resultBooks = fileReader.searchByString(category, stringValue);
                    if (resultBooks != null)
                    {
                        printResult();
                    }
                    else
                    {
                        Console.WriteLine("Brak wynikow");
                    }
                    break;
                case 2:

                    Console.WriteLine("Podaj kategorie: ");
                    category = Console.ReadLine();

                    Console.WriteLine("Podaj wartosc: ");
                    String toParse = Console.ReadLine();
                    toParse.Trim();
                    try
                    {
                        doubleValue = Double.Parse(toParse);
                        resultBooks = fileReader.searchByDoubleMore(category, doubleValue);
                        if (resultBooks != null)
                        {
                            printResult();
                        }
                        else
                        {
                            Console.WriteLine("Brak wynikow");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

            }

        }
    }
}
