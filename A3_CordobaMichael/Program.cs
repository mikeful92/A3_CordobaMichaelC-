using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3_CordobaMichael
{
    interface IRenewable
    {
        bool Renew();
    }


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
            if(c == null){
                status = "Available";
            }
            else{
                status = "Checked out to Customer " + c.Id + "Due on " + dueDate.ToString();
            }
            string s = String.Format("{0,-8}{1, -20}{2, -20}{3}", catalogNumber ,title,authors,status);

            return s;
        }

        public bool CheckOut(Customer c)
        {
            if(this.c == null){
                this.c = c;
                this.dueDate = findDueDate();
                return true;
            }
            else{
                return false;
            }
        }

        public bool CheckIn()
        {
            if(c != null){
                c = null;
                return true;
            }
            else{
                return false;
            }
        }

        public abstract DateTime findDueDate();
    }

    class TextBook : Book, IRenewable
    {
        private int edition;
        public TextBook(string title, string authors, int catalogNumber, int edition) : base(title, authors, catalogNumber)
        {
            this.edition = edition;
        }
        public override DateTime findDueDate()
        {
            DateTime due = DateTime.Now.AddDays(30);
            return due;
        }
        public override string ToString()
        {
            string status;
            if (c == null)
            {
                status = "Available";
            }
            else
            {
                status = "Checked out to Customer " + c.Id + "Due on " + dueDate.ToString();
            }
            string s = String.Format("{0,-8}{1, -20}{2, -20}{3} Edition: {4}", catalogNumber, title, authors, status, edition);

            return s;
        }

        public bool Renew()
        {
            if (c == null)
            {
                return false;
            }
            else
            {
                dueDate = dueDate.AddDays(15);
                return true;
            }
        }
    }

    class GeneralBook : Book
    {
        public GeneralBook(string title, string authors, int catalogNumber) : base(title, authors, catalogNumber) { }
        public override DateTime findDueDate()
        {
            DateTime due = DateTime.Now.AddDays(7);
            return due;
        }
    }

    class Library
    {
        private Customer[] customerArray = new Customer[5];
        private Book[] bookArray = new Book[5];
        private int customerIdCounter = 1;
        private int bookIdCounter = 1;

        public bool AddNewCustomer(string customerName)
        {
            if(customerIdCounter <= customerArray.Length){
                customerArray[customerIdCounter-1] = new Customer(customerName, customerIdCounter);
                customerIdCounter++;
                return true;
            }
            else{
                return false;
            }
        }

        public bool AddNewBook(string bookTitle, string bookAuthor)
        {
            if(bookIdCounter <= bookArray.Length){
                bookArray[bookIdCounter - 1] = new GeneralBook(bookTitle, bookAuthor, bookIdCounter+100);
                bookIdCounter++;
                return true;
            }
            else{
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
            for(int i = 1; i < customerIdCounter; i++){
                s = s + customerArray[i-1].ToString() + "\n";
            }
            s = s + "\n";
            for (int i = 1; i  < bookIdCounter; i++)
            {
                s = s + bookArray[i-1].ToString() + "\n";
            }
            return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Console.WriteLine("Add Customer Fred: " + library.AddNewCustomer("Fred"));
            Console.WriteLine("Add Customer Bob: " + library.AddNewCustomer("Bob"));
            Console.WriteLine("Add Customer Kyle: " + library.AddNewCustomer("Kyle"));
            Console.WriteLine();

            Console.WriteLine("Add Book Learning C#: " + library.AddNewBook("Learning C#", "Liberty", 2));
            Console.WriteLine("Add Book Introduction to C#: " + library.AddNewBook("Introduction to C#", "Deitel", 1));
            Console.WriteLine("Add Book Harry Potter: " + library.AddNewBook("Harry Potter", "Rowling"));
            Console.WriteLine("Add Book Advanced C#: " + library.AddNewBook("Advanced C#", "Murach", 4));
            Console.WriteLine();

            Console.WriteLine(library.ToString());

            Console.WriteLine("Issuing Books...");
            Console.WriteLine("library.IssueBook(2, 101): " + library.IssueBook(2, 101));
            Console.WriteLine("library.IssueBook(1, 103): " + library.IssueBook(1, 103));
            Console.WriteLine("library.IssueBook(3, 101): " + library.IssueBook(3, 101));
            Console.WriteLine("library.IssueBook(1, 104): " + library.IssueBook(1, 104));
            Console.WriteLine("library.IssueBook(4, 102): " + library.IssueBook(4, 102));
            Console.WriteLine("library.IssueBook(2, 105): " + library.IssueBook(2, 105));

            Console.WriteLine();
            Console.WriteLine(library.ToString());

            Console.WriteLine("Renewing Books...");
            Console.WriteLine("library.RenewBook(101): " + library.RenewBook(101));
            Console.WriteLine("library.RenewBook(102): " + library.RenewBook(102));
            Console.WriteLine("library.RenewBook(103): " + library.RenewBook(103));
            Console.WriteLine("library.ReturnBook(106): " + library.ReturnBook(106));
            Console.WriteLine();
            Console.WriteLine(library.ToString());

            Console.WriteLine("Returning Books...");
            Console.WriteLine("library.ReturnBook(103): " + library.ReturnBook(103));
            Console.WriteLine("library.ReturnBook(103): " + library.ReturnBook(103));
            Console.WriteLine("library.ReturnBook(102): " + library.ReturnBook(102));
            Console.WriteLine("library.ReturnBook(105): " + library.ReturnBook(105));
            Console.WriteLine();


            Console.WriteLine(library.ToString());


            Console.ReadLine();


        }


    }
}
