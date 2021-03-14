using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Omicron.library.DaL.Concrete.EntityFramework.Context;
using Omicron.library.DaL.Interface;
using Omicron.library.Entities.Entity;
using Omicron.library.UI.Models;
using Omicron.library.UI.SeedDatabase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Omicron.library.UI.Controllers
{
    public class HomeController : Controller
    {

        private IBookDal bookDal;
        private IStudentDal studentDal;
        private IBookOrderDal bookOrderDal;
        public HomeController(IBookDal bookDal, IStudentDal studentDal, IBookOrderDal bookOrderDal)
        {
            this.bookDal = bookDal;
            this.studentDal = studentDal;
            this.bookOrderDal = bookOrderDal;
            AddData.Seed(new LibContext());
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> KitapListele()
        {
            return View(await bookDal.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> OgrenciListele()
        {
            return View(await studentDal.GetAllAsync());
        }

        [HttpGet]
        public IActionResult KitapOduncVer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KitapOduncVerAsync(KitapOduncModel kitapOduncModel)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                var student = await studentDal.GetByTcNo(kitapOduncModel.Tc);
                var book = await bookDal.GetByISBNNo(kitapOduncModel.ISBN);
                if (student == null)
                {
                    message = message + "Aranan Öğrenci Bulunamadı ";
                }
                if (book == null)
                {
                    message = message + "Aranılan Kitap Yok ";
                }
                else
                {
                    if (book.Give)
                    {
                        message = message + "Kitap Daha Önce Ödünç Verilmiş ";
                    }
                }

                if (string.IsNullOrEmpty(message))
                {
                    student.BookOrders = new List<BookOrder>();
                    student.BookOrders.Add(new BookOrder()
                    {
                        
                        BookId = book.Id,
                        PickUpDate = DateTime.Now,
                        
                        
                    });;
                    await studentDal.Update(student);
                    book.Give = true;
                    await bookDal.Update(book);
                    return RedirectToAction("index", "home");
                }
                return View(kitapOduncModel);
            }
            else
            return View(kitapOduncModel);
        }

        [HttpGet]
        public IActionResult KitapIadeAl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KitapIadeAl(KitapOduncModel kitapOduncModel)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                var student = await studentDal.GetByTcNo(kitapOduncModel.Tc);
                var book = await bookDal.GetByISBNNo(kitapOduncModel.ISBN);
                if (student == null)
                {
                    message = message + "Aranan Öğrenci Bulunamadı ";
                }
                if (book == null)
                {
                    message = message + "Aranılan Kitap Yok ";
                }
                else
                {
                    if (!book.Give)
                    {
                        message = message + "O Kitap Suanda Kütüphanede İade edilemez";
                    }
                }

                if (string.IsNullOrEmpty(message))
                {
                    var bookOrder = bookOrderDal.GetByIds(book.Id, student.Id);
                    bookOrder.Result.DeliveryDate = DateTime.Now;
                    await bookOrderDal.Update(bookOrder.Result);
                    book.Give = false;
                    await bookDal.Update(book);
                }
                return RedirectToAction("index","home");
            }
            else
                return View(kitapOduncModel);
        }

        [HttpGet]
        public IActionResult EnCokAlinanKitaplar()
        {
            EnCokAlinanKitaplarModel EC = new EnCokAlinanKitaplarModel();
            
            var books = bookDal.GetAllBookTime();
            EC.sayilar = new int[books.Result.Count];
            EC.Books = new List<Book>();
            EC.Books = books.Result;
            int i = 0;
            foreach (var item in books.Result)
            {
                int toplam = 0;
                foreach (var item2 in item.BookOrders)
                {
                    
                    if (item.Id == item2.BookId)
                    {
                        toplam = toplam + item2.DeliveryDate.Value.Minute - item2.PickUpDate.Minute;
                    }
                    EC.sayilar[i] = toplam;
                }
                i++;
            }
            return View(EC);
        }
    }
}
