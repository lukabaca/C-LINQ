using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Book
    {
        private String author;
        private String title;
        private String genre;

        private double price;
        private String publish_date;
        private String description;

        public Book(String author, String title, String genre, double price, String publish_date, String description)
        {
            this.author = author;
            this.title = title;
            this.genre = genre;

            this.price = price;
            this.publish_date = publish_date;
            this.description = description;
        }

        public override string ToString()
        {
            return "Author: " + author + "\n" + "Title: " + title + "\n" + "Genre: " + genre + "\n" + "Price: " + price + "\n" + "Publish date: " + publish_date + "\n" + "Description: " + description + "\n" + "------------------" + "\n";
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }

            set
            {
                genre = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public string Publish_date
        {
            get
            {
                return publish_date;
            }

            set
            {
                publish_date = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
    }
}
