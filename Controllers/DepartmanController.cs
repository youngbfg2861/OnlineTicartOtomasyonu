using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticart.Models.Sınıflar;

namespace Ticart.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {

            return View();
        }

        public ActionResult DepartmanSil(int ID)
        {

            var deger = c.Departmans.Find(ID);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGuncelle(Departman p)
        {
            var urn = c.Departmans.Find(p.DepartmanID);
            urn.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int ID)
        {

            var deger = c.Departmans.Find(ID);
            return View("DepartmanGetir", deger);
        }

        public ActionResult DepartmanDetay(int ID)
        {
            var degerler = c.Personels.Where(x=>x.PersonelID==ID).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanID == ID).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " +y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }

    }
}