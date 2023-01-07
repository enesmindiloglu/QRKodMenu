using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemassizMenu.Controllers
{
    public class HomeController : Controller
    {

        CategoryManager categoryManager = new CategoryManager();
        ProductManager productManager = new ProductManager();

        // GET: Home
        public ActionResult Index()
        {
            List<Category> kategoriListesi = categoryManager.GetAll();
            return View(kategoriListesi);
        }

        public ActionResult Kategoriler()
        {
            List<Category> kategoriListesi = categoryManager.GetAll();
            return View(kategoriListesi);
        }

        public ActionResult Menu(int id)
        {
            List<Product> urunListesi = productManager.GetAllByCategoryID(id);
            return View(urunListesi);
        }
    }
}