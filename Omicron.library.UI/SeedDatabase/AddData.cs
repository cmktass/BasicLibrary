using Microsoft.EntityFrameworkCore;
using Omicron.library.DaL.Concrete.EntityFramework.Context;
using Omicron.library.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omicron.library.UI.SeedDatabase
{
    public static class AddData
    {
        private static Book[] Books =
        {
            new Book()
            {
                Name="1984",ISBN=Guid.NewGuid(),Give=false
            },
            new Book()
            {
                Name="Satranç",ISBN=Guid.NewGuid(),Give=false
            },
            new Book()
            {
                Name="BlockChain",ISBN=Guid.NewGuid(),Give=false
            },
            new Book()
            {
                Name="Sapiens",ISBN=Guid.NewGuid(),Give=false
            },
        };
        private static Student[] Students =
       {
            new Student()
            {
                Name="Ali",Surname="Surme",Tc=578575785
            },
             new Student()
            {
                Name="Veli",Surname="Görme",Tc=3575678
            },
              new Student()
            {
                Name="Ahmet",Surname="Eskici",Tc=53453786
            },
               new Student()
            {
                Name="Mehmet",Surname="Yenici",Tc=278225876
            },
        };
        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if(context is LibContext)
                {
                    LibContext context1 = context as LibContext;
                    if (context1.Books.Count() == 0)
                    {
                        context1.Books.AddRange(Books);
                    }
                    if (context1.Students.Count() == 0)
                    {
                        context1.Students.AddRange(Students);
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
