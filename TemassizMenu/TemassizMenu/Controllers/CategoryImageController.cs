using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemassizMenu.Controllers
{
    public class CategoryImageController : Controller
    {
        CategoryImageManager categoryImageManager = new CategoryImageManager();
        CategoryManager categoryManager = new CategoryManager();

        // GET: CategoryImage
        public ActionResult Index()
        {
            List<Category> kategoriListesi = categoryManager.GetAll();
            List<CategoryImage> resimListesi = categoryImageManager.GetAll();
            ViewBag.KategoriListesi = kategoriListesi;
            return View(resimListesi);
        }

        [HttpPost]
        public ActionResult KategoriResmiEkle(CategoryImage categoryImage, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string resimAdi = System.IO.Path.GetFileName(file.FileName);
                string adres = Server.MapPath("~/KategoriResimleri/" + resimAdi);
                file.SaveAs(adres);

                categoryImage.Name = Request.Form["Name"];
                categoryImage.Path = resimAdi;
            }

            if (ModelState.IsValid)
            {
                categoryImageManager.Add(categoryImage);
                TempData["UyariMesaji"] = categoryImage.Name + " isimli kategori resmi eklendi";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult KategoriResmiSil(string id)
        {
            try
            {
                int katID = Convert.ToInt32(id);
                categoryImageManager.Delete(katID);
                TempData["UyariMesaji"] = "Kategori resim silme işlemi başarılı";
                return Json("1");
            }
            catch (Exception ex)
            {
                TempData["UyariMesaji"] = "Kategori resmi silme işlemi sırasında hata oluştu " + ex.Message;
                return Json("2");
            }
        }
    }
}