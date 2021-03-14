using Microsoft.EntityFrameworkCore;
using Omicron.library.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omicron.library.DaL.Concrete.EntityFramework.Context
{
    public class LibContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=OMLibDB;Integrated Security=SSPI;");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BookOrder> BookOrders { get; set; }
    }
}
