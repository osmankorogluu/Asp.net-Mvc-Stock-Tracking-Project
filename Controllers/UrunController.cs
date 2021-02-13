using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var urunler = db.TblUrunler.Where(x => x.urun == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.TblKategoriler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop = ktg;

                                         
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TblUrunler t)
        {
            var ktgr = db.TblKategoriler.Where(x => x.id == t.TblKategoriler.id).FirstOrDefault();
            t.TblKategoriler = ktgr;
            db.TblUrunler.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kat = (from x in db.TblKategoriler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            var ktg = db.TblUrunler.Find(id);
            ViewBag.urunkategori = kat;
            return View("UrunGetir", ktg);
        }
        public ActionResult UrunGuncelle(TblUrunler p)
        {
            var urun = db.TblUrunler.Find(p.id);
            urun.Marka = p.Marka;
            urun.Ad = p.Ad;
            urun.SatisFiyat = p.SatisFiyat;
            urun.AlisFiyat = p.AlisFiyat;
            urun.Stok = p.Stok;
            var ktg = db.TblKategoriler.Where(x => x.id == p.TblKategoriler.id).FirstOrDefault();
            urun.Kategori = ktg.id;
            db.SaveChanges();
            return RedirectToAction("Index");
                
                
                
        }
        public ActionResult UrunSil(TblUrunler p1)
        {
            var urunbul = db.TblUrunler.Find(p1.id);
            urunbul.urun = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}