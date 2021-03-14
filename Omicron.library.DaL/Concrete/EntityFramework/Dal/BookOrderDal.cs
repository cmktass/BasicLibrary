using Microsoft.EntityFrameworkCore;
using Omicron.library.DaL.Concrete.EntityFramework.Context;
using Omicron.library.DaL.Interface;
using Omicron.library.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omicron.library.DaL.Concrete.EntityFramework.Dal
{
    public class BookOrderDal : GenericDal<BookOrder>, IBookOrderDal
    {
        public async Task<BookOrder> GetByIds(int BookId, int PersonId)
        {
            using(var db=new LibContext())
            {
                return await db.BookOrders.Where(i => i.BookId == BookId && i.StudentId == PersonId && i.DeliveryDate == null).FirstOrDefaultAsync();
            }
        }
    }
}
