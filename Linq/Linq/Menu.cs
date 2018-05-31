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
            Console.WriteLine("[0] Exit");
            Console.WriteLine("[1] Find by genre");
            Console.WriteLine("[2] Get all book genres");
            Console.WriteLine("[3] Find by genre and price (it will find >= price book)");
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
