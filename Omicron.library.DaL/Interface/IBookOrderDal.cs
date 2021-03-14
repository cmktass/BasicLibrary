using Omicron.library.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omicron.library.DaL.Interface
{
    public interface IBookOrderDal:IGenericDal<BookOrder>
    {
        Task<BookOrder> GetByIds(int BookId, int PersonId);

        
    }
}
