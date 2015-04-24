using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3_CordobaMichael
{
    class Library
    {
        private Customer[] customerArray = new Customer[5];
        public Book[] bookArray = new Book[5];
        private int customerIdCounter = 1;
        private int bookIdCounter = 1;

        public bool AddNewCustomer(string customerName)
        {
            if (customerIdCounter <= customerArray.Length)
            {
                customerArray[customerIdCounter - 1] = new Customer(customerName, customerIdCounter);
                customerIdCounter++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddNewBook(string bookTitle, string bookAuthor)
        {
            if (bookIdCounter <= bookArray.Length)
            {
                bookArray[bookIdCounter - 1] = new GeneralBook(bookTitle, bookAuthor, bookIdCounter + 100);
                bookIdCounter++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddNewBook(string bookTitle, string bookAuthor, int edition)
        {
            if (bookIdCounter <= bookArray.Length)
            {
                bookArray[bookIdCounter - 1] = new TextBook(bookTitle, bookAuthor, bookIdCounter + 100, edition);
                bookIdCounter++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IssueBook(int custId, int bookCatalogNum)
        {
            if (bookArray[bookCatalogNum - 101] != null)
            {
                if (customerArray[custId - 1] != null)
                {
                    return bookArray[bookCatalogNum - 101].CheckOut(customerArray[custId - 1]);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ReturnBook(int bookCatalogNum)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                {
                    if (bookArray[i].CatalogNumber == bookCatalogNum)
                    {
                        return bookArray[i].CheckIn();
                    }
                }
            }
            return false;
        }

        public bool RenewBook(int bookCatalogNum)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                {
                    if (bookArray[i].CatalogNumber == bookCatalogNum)
                    {
                        if (bookArray[i] is IRenewable)
                        {
                            Console.WriteLine(bookArray[i] is Book);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public string ToString()
        {
            string s = "";
            for (int i = 1; i < customerIdCounter; i++)
            {
                s = s + customerArray[i - 1].ToString() + "\n";
            }
            s = s + "\n";
            for (int i = 1; i < bookIdCounter; i++)
            {
                s = s + bookArray[i - 1].ToString() + "\n";
            }
            return s;
        }
    }
}
