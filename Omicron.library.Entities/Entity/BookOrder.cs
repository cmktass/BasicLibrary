using System;
using System.Collections.Generic;
using System.Text;

namespace Omicron.library.Entities.Entity
{
    public class BookOrder
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
