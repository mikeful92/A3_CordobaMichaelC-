using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_CordobaMichael
{
    class GeneralBook : Book
    {
        public GeneralBook(string title, string authors, int catalogNumber) : base(title, authors, catalogNumber) { }
        public override DateTime findDueDate()
        {
            DateTime due = DateTime.Now.AddDays(7);
            return due;
        }
    }
}
