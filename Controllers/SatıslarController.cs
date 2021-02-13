using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatıslarController : Controller
    {
        // GET: Satıslar
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var satıslar = db.TblSatıslar.ToList();
            return View(satıslar);
        }
        [HttpGet]
        public ActionResult YeniSatıs()
        {
           
            
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatıs(TblSatıslar p)
        {
            return View();
        }


    }
}