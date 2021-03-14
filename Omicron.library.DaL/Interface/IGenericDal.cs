using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omicron.library.DaL.Interface
{
    public interface IGenericDal<TEntity> where TEntity:class,new()
    {
        Task AddAsync(TEntity entity);

        Task<List<TEntity>> GetAllAsync();

        Task Update(TEntity entity);
    }
}
