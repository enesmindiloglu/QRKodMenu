using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemassizMenu.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager();
        CategoryManager categoryManager = new CategoryManager();

        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = productManager.GetAll();
            List<Category> kategoriListesi = categoryManager.GetAll();
            ViewBag.KategoriListesi = kategoriListesi;
            return View(products);
        }

        [HttpPost]
        public ActionResult UrunEkle(Product product)
        {
            try
            {
                productManager.Add(product);
                TempData["UyariMesaji"] = product.ProductName + " isimli ürün eklendi";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["UyariMesaji"] = "Ürün ekleme işlemi sırasında hata oluştu";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public JsonResult UrunSil(string id)
        {
            try
            {
                int urunID = Convert.ToInt32(id);
                productManager.Delete(urunID);
                TempData["UyariMesaji"] = "Ürün silme işlemi başarılı";
                return Json("1");
            }
            catch (Exception ex)
            {
                TempData["UyariMesaji"] = "Ürün silme işlemi sırasında hata oluştu " + ex.Message;
                return Json("2");
            }
        }

        [HttpPost]
        public ActionResult UrunDuzenle(Product product)
        {
            productManager.Update(product);
            return RedirectToAction("Index");
        }
    }
}