using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemassizMenu.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager();
        ProductManager productManager = new ProductManager();

        // GET: Category
        public ActionResult Index()
        {
            List<Category> kategoriListesi = categoryManager.GetAll();
            return View(kategoriListesi);
        }

        [HttpPost]
        public ActionResult KategoriEkle(Category category)
        {
            try
            {
                categoryManager.Add(category);
                TempData["UyariMesaji"] = category.CategoryName + " isimli kategori eklendi";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["UyariMesaji"] = "Kategori ekleme işlemi sırasında hata oluştu";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public JsonResult KategoriSil(string id)
        {
            try
            {
                int katID = Convert.ToInt32(id);
                List<Product> urunListesi = productManager.GetAllByCategoryID(katID);
                if (urunListesi.Count > 0)
                {
                    TempData["UyariMesaji"] = "Bu kategoriye bağlı ürünler mevcut olduğundan silinemez";
                    return Json("1");
                }
                else
                {
                    categoryManager.Delete(katID);
                    TempData["UyariMesaji"] = "Kategori silme işlemi başarılı";
                    return Json("1");
                }
            }
            catch (Exception ex)
            {
                TempData["UyariMesaji"] = "Kategori silme işlemi sırasında hata oluştu " + ex.Message;
                return Json("2");
            }

        }

        [HttpPost]
        public ActionResult KategoriDuzenle(Category category)
        {
            categoryManager.Update(category);
            return RedirectToAction("Index");
        }
    }
}