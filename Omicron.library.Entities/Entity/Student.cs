using System;
using System.Collections.Generic;
using System.Text;

namespace Omicron.library.Entities.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public int Tc { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<BookOrder> BookOrders { get; set; }
    }
}
