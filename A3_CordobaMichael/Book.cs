using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3_CordobaMichael
{
    abstract class Book
    {
        protected int catalogNumber;
        protected string title;
        protected string authors;
        protected DateTime dueDate;
        protected Customer c;

        public int CatalogNumber
        {
            get { return catalogNumber; }
        }

        public Book(string title, string authors, int catalogNumber)
        {
            this.title = title;
            this.authors = authors;
            this.catalogNumber = catalogNumber;
        }

        public virtual string ToString()
        {
            string status;
            if (c == null)
            {
                status = "Available";
            }
            else
            {
                status = "Checked out to Customer " + c.Id + " Due on " + dueDate.ToString();
            }
            string s = String.Format("{0,-8}{1, -20}{2, -10} {3, -10}", catalogNumber, title, authors, status);

            return s;
        }

        public bool CheckOut(Customer c)
        {
            if (this.c == null)
            {
                this.c = c;
                this.dueDate = findDueDate();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIn()
        {
            if (c != null)
            {
                c = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract DateTime findDueDate();
    }
}
