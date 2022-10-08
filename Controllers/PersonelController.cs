using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticart.Models.Sınıflar;

namespace Ticart.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            var urn = c.Personels.Find(p.PersonelID);
            urn.PersonelAd = p.PersonelAd;
            urn.PersonelSoyad = p.PersonelSoyad;
            urn.PersonelGorsel = p.PersonelGorsel;
            urn.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int ID)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var deger = c.Personels.Find(ID);
            return View("PersonelGetir", deger);
        }

        public ActionResult PersonelSil(int ID)
        {

            var kate = c.Personels.Find(ID);
            c.Personels.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}