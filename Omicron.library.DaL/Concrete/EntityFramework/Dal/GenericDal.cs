using Microsoft.EntityFrameworkCore;
using Omicron.library.DaL.Concrete.EntityFramework.Context;
using Omicron.library.DaL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omicron.library.DaL.Concrete.EntityFramework.Dal
{
    public class GenericDal<TEntity> : IGenericDal<TEntity> where TEntity : class, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using(var db=new LibContext())
            {
                db.Set<TEntity>().Add(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using (var db = new LibContext())
            {
                return await db.Set<TEntity>().ToListAsync();
            }
        }
        public async Task Update(TEntity entity)
        {
            using (var db = new LibContext())
            {
               db.Set<TEntity>().Update(entity);
               await db.SaveChangesAsync();

            }
        }
    }
}
