using FA.Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.Bookstore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(BookStoreContext bookStoreContext)
        {
            //bookStoreContext = new BookStoreContext();
            var bookStoreCount = bookStoreContext.Books.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}