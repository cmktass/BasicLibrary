using System;
using System.Collections.Generic;
using System.Text;

namespace Omicron.library.Entities.Entity
{
    public class Book
    {
        public int Id { get; set; }

        public Guid ISBN { get; set; }

        public string Name { get; set; }

        public bool Give { get; set; }

        public List<BookOrder> BookOrders { get; set; }

    }
}
