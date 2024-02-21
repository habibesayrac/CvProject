using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHakkimda.ToList();

            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TBLSosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TBLDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitimler = db.TBLEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yetenek()
        {
            var yetenek = db.TBLYeteneklerim.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Hobi()
        {
            {
                var hobi = db.TBLHobilerim.ToList();
                return PartialView(hobi);
            }
        }
        public PartialViewResult Sertifika()
        {
            {
                var sertifika = db.TBLSertifikalarim.ToList();
                return PartialView(sertifika);
            }
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            {
                return PartialView();
            }
        }
        [HttpPost]
        public PartialViewResult Iletisim(TBLİletisim t)
        {
            {
                t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                db.TBLİletisim.Add(t);
                db.SaveChanges();
                return PartialView();
            }
        }

    }
}