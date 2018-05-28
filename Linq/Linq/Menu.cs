using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Menu
    {
        private int choice;
        private String input;
        public void printMenu()
        {
            Console.WriteLine("[1] Find by author");
            Console.WriteLine("[2] Find by bookId");
        }

        public int getChoice()
        {
            choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        public String getInput()
        {
            input = Console.ReadLine();

            return input;
        }

    }
}
