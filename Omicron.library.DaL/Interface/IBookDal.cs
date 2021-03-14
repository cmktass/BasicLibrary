using Omicron.library.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omicron.library.DaL.Interface
{
    public interface IBookDal:IGenericDal<Book>
    {
        Task<Book> GetByISBNNo(Guid ISBN);

        Task<List<Book>> GetAllBookTime();

       List<Book> Deneme();
    }
}
