using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq
{
    class XMLreader
    {
        private String path;
        private XElement xElement;
        private IEnumerable<XElement> resultBooks;

        public XMLreader()
        {

            this.path = "../../example.xml";

            this.xElement = XElement.Load(path);

            this.resultBooks = xElement.Elements();
        }





        public IEnumerable<XElement> searchByString(String category, String value)
        {
            var searchList = from idp in xElement.Elements("book")
                             where (string)idp.Element(category) == value
                             select idp;
            //searchList = searchList.OrderBy(item => item.Element().Value)

            if (searchList.Count() == 0)
            {
                return null;
            }

            return searchList;
        }


        public IEnumerable<XElement> searchByDouble(String category, double value)
        {
            var searchList = from idp in xElement.Elements("book")
                             where (double)idp.Element(category) == value
                             select idp;

            if (searchList.Count() == 0)
            {
                return null;
            }

            return searchList;
        }

        public IEnumerable<XElement> searchByDoubleLess(String category, double value)
        {
            var searchList = from idp in xElement.Elements("book")
                             where (double)idp.Element(category) <= value
                             select idp;
            if (searchList.Count() == 0)
            {
                return null;
            }


            return searchList;
        }

        public IEnumerable<XElement> searchByDoubleMore(String category, double value)
        {
            var searchList = from idp in xElement.Elements("book")
                             where (double)idp.Element(category) >= value
                             select idp;
            if (searchList.Count() == 0)
            {
                return null;
            }


            return searchList;
        }

    }
}
