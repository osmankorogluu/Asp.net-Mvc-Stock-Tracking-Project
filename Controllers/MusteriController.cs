using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {

           
            var musteriliste = db.Tblmusteri.Where(x=>x.Durum1==true).ToList().ToPagedList(sayfa, 3);
            return View(musteriliste);
            
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(Tblmusteri p)
        {
            db.Tblmusteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(Tblmusteri p)
        {
            var musteribul = db.Tblmusteri.Find(p.id);
            musteribul.Durum1 = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.Tblmusteri.Find(id);
        
            return View("MusteriGetir", mus);
        }
        public ActionResult MusteriGuncelle(Tblmusteri t)
        {
            var mus = db.Tblmusteri.Find(t.id);
            mus.Ad = t.Ad;
            mus.Soyad = t.Soyad;
            mus.Sehir = t.Sehir;
            mus.Bakiye = t.Bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
