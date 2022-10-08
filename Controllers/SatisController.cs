using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticart.Models.Sınıflar;

namespace Ticart.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        // GET: Satıs
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd +" "+x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr1 = deger2;
            ViewBag.dgr1 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket p)
        {
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisSil(int ID)
        {

            var kate = c.SatisHarekets.Find(ID);
            c.SatisHarekets.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}