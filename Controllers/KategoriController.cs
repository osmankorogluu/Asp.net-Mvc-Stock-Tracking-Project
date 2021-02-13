using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var kategori = db.TblKategoriler.ToList();
            return View(kategori);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TblKategoriler p)
        {
            db.TblKategoriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.TblKategoriler.Find(id);
            db.TblKategoriler.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");       
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TblKategoriler.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(TblKategoriler k)
        {
            var ktg = db.TblKategoriler.Find(k.id);
            ktg.Ad = k.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

            
    }
}