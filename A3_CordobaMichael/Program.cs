using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3_CordobaMichael
{
    class Customer
    {
        private int id;
        private string name;

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Customer(string name, int id)
        {
            this.id = id; this.name = name;
        }

        public string ToString()
        {
            return String.Format("{0,-5}{1,-10}", id, name);
        }
    }

    class Book
    {
        private int catalogNumber;
        private string title;
        private string authors;
        Customer c;

        public int CatalogNumber { get; }

        public Book(string title, string authors, int catalogNumber)
        {
            this.title = title;
            this.authors = authors;
            this.catalogNumber = catalogNumber;
        }

        public string ToString()
        {
            string s = String.Format(catalogNumber + " " + title + " " + authors + " ");

            return s;
        }

        public bool CheckOut(Customer c)
        {
            bool status = false;

            return status;
        }

        public bool CheckIn()
        {
            bool status = false;

            return status;
        }

    }

    class Library
    {
        private Customer[] customerArray = new Customer[5];
        private Book[] bookArray = new Book[5];

        public bool AddNewCustomer(string customerName)
        {

            return false;
        }

        public bool AddNewBook(string bookTitle, string bookAuthor)
        {

            return false;
        }

        public string ToString()
        {
            string s = String.Format("Hello World");

            return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer("Tom", 1);
            Customer c2 = new Customer("Mary", 2);

            Book b1 = new Book("Java by Example", "Deitel", 1);
            Book b2 = new Book("C# by Example", "Murach", 2);

            Console.WriteLine("-------Testing ToString()-------------\n");
            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());
            Console.WriteLine();
            Console.WriteLine(b1.ToString());
            Console.WriteLine(b2.ToString());
            Console.WriteLine();

            Console.WriteLine("-------Testing CheckOut()-------------\n");
            Console.WriteLine("b1.CheckOut(c1): " + b1.CheckOut(c1));
            Console.WriteLine("b1.CheckOut(c2): " + b1.CheckOut(c2));
            Console.WriteLine();

            Console.WriteLine(b1.ToString());
            Console.WriteLine(b2.ToString());
            Console.WriteLine();

            Console.WriteLine("-------Testing CheckIn()-------------\n");
            Console.WriteLine("b1.CheckIn: " + b1.CheckIn());
            Console.WriteLine("b2.CheckIn: " + b2.CheckIn());
            Console.WriteLine();


            Console.WriteLine(b1.ToString());
            Console.WriteLine(b2.ToString());
            Console.WriteLine();

            Console.WriteLine("-------Testing AddNewCustomer()-------------\n");
            Library library = new Library();

            Console.WriteLine("Add Customer Fred: " + library.AddNewCustomer("Fred"));
            Console.WriteLine("Add Customer Bob: " + library.AddNewCustomer("Bob"));
            Console.WriteLine("Add Customer Kyle: " + library.AddNewCustomer("Kyle"));
            Console.WriteLine();

            Console.WriteLine("-------Testing AddNewBook()-------------\n");
            Console.WriteLine("Add Book Learning C#: " + library.AddNewBook("Learning C#", "Liberty"));
            Console.WriteLine("Add Book Introduction to C#: " + library.AddNewBook("Introduction to C#", "Deitel"));
            Console.WriteLine("Add Book Advanced C#: " + library.AddNewBook("Advanced C#", "Murach"));
            Console.WriteLine();

            Console.WriteLine("-------Testing Library.ToString()-------------\n");
            Console.WriteLine(library.ToString());

            Console.WriteLine("-------Testing AddNewCustomer()-------------\n");
            Library library1 = new Library();
            Console.WriteLine("Add Customer C1: " + library1.AddNewCustomer("C1"));
            Console.WriteLine("Add Customer C2: " + library1.AddNewCustomer("C2"));
            Console.WriteLine("Add Customer C3: " + library1.AddNewCustomer("C3"));
            Console.WriteLine("Add Customer C4: " + library1.AddNewCustomer("C4"));
            Console.WriteLine("Add Customer C5: " + library1.AddNewCustomer("C5"));
            Console.WriteLine("Add Customer C6: " + library1.AddNewCustomer("C6"));
            Console.WriteLine();

            Console.WriteLine("-------Testing AddNewCustomer()-------------\n");
            Console.WriteLine("Add Book B1: " + library1.AddNewBook("B1", "A1"));
            Console.WriteLine("Add Book B2: " + library1.AddNewBook("B2", "A1"));
            Console.WriteLine("Add Book B3: " + library1.AddNewBook("B3", "A1"));
            Console.WriteLine("Add Book B4: " + library1.AddNewBook("B4", "A1"));
            Console.WriteLine("Add Book B5: " + library1.AddNewBook("B5", "A1"));
            Console.WriteLine("Add Book B6: " + library1.AddNewBook("B6", "A1"));
            Console.WriteLine();


            Console.ReadLine();

        }


    }
}
