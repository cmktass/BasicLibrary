using Microsoft.EntityFrameworkCore;
using Omicron.library.DaL.Concrete.EntityFramework.Context;
using Omicron.library.DaL.Interface;
using Omicron.library.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omicron.library.DaL.Concrete.EntityFramework.Dal
{
    public class BookDal : GenericDal<Book>, IBookDal
    {
        public List<Book> Deneme()
        {
            using (var db = new LibContext())
            {
                return (List<Book>)db.Books.Select(i => new Book
                {
                    Name = i.Name,
                    ISBN = i.ISBN,
                });
                
            }
            
        }

        public async Task<List<Book>> GetAllBookTime()
        {
            using(var db=new LibContext())
            {
                return db.Books.Include(i => i.BookOrders).Where(i => i.Give == false).ToList().Where(i=>i.BookOrders.Count>0).ToList();        
            }
        }

        public async Task<Book> GetByISBNNo(Guid ISBN)
        {
           using(var db=new LibContext())
            {
                return await db.Books.Where(i => i.ISBN == ISBN).FirstOrDefaultAsync();
            }
        }
    }
}
