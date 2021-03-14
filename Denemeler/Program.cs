using Omicron.library.DaL.Concrete.EntityFramework.Dal;
using System;

namespace Denemeler
{
    class Program
    {
        static void Main(string[] args)
        {
            BookDal book = new BookDal();
            var a=book.Deneme();
        }
    }
}
