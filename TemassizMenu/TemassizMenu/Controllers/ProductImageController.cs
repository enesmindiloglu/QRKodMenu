using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemassizMenu.Controllers
{
    public class ProductImageController : Controller
    {
        ProductImageManager productImageManager = new ProductImageManager();
        ProductManager productManager = new ProductManager();

        // GET: ProductImage
        public ActionResult Index()
        {
            List<ProductImage> resimListesi = productImageManager.GetAll();
            List<Product> urunListesi = productManager.GetAll();
            ViewBag.UrunListesi = urunListesi;
            return View(resimListesi);
        }

        [HttpPost]
        public ActionResult UrunResmiEkle(ProductImage productImage, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string resimAdi = System.IO.Path.GetFileName(file.FileName);
                string adres = Server.MapPath("~/UrunResimleri/" + resimAdi);
                file.SaveAs(adres);

                productImage.Name = Request.Form["Name"];
                productImage.Path = resimAdi;
            }

            if (ModelState.IsValid)
            {
                productImageManager.Add(productImage);
                TempData["UyariMesaji"] = productImage.Name + " isimli ürün resmi eklendi";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult UrunResmiSil(string id)
        {
            try
            {
                int urunResimID = Convert.ToInt32(id);
                productImageManager.Delete(urunResimID);
                TempData["UyariMesaji"] = "Ürün resim silme işlemi başarılı";
                return Json("1");
            }
            catch (Exception ex)
            {
                TempData["UyariMesaji"] = "Ürün resmi silme işlemi sırasında hata oluştu " + ex.Message;
                return Json("2");
            }
        }
    }
}