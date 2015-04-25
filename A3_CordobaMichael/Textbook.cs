using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3_CordobaMichael
{
    class TextBook : Book, IRenewable
    {
        private int edition;
        public TextBook(string title, string authors, int catalogNumber, int edition)
            : base(title, authors, catalogNumber)
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
                status = "Checked out to Customer " + c.Id + " Due on " + dueDate.ToString();
            }
            string s = String.Format("{0,-8}{1, -20}{2, -10} {3, -10} Edition: {4}", catalogNumber, title, authors, status, edition);

            return s;
        }

        public override bool Renew()
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
}
