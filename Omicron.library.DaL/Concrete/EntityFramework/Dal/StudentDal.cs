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
    public class StudentDal : GenericDal<Student>, IStudentDal
    {
        public async Task<Student> GetByTcNo(int tc)
        {
           using(var db=new LibContext())
            {
                return await db.Students.Where(i => i.Tc == tc).FirstOrDefaultAsync();
            }
        }
    }
}
