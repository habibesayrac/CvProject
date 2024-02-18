using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        SertifikaRepository repo = new SertifikaRepository();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
         return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TBLSertifikalarim p)
        {
            if (!ModelState.IsValid)
            {
                return View("Sertifika Ekle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x=>x.ID== id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x=>x.ID== id);       
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TBLSertifikalarim p)
        {
            var sertifika = repo.Find(x=>x.ID== p.ID);
            sertifika.Tarih = p.Tarih;
            sertifika.Aciklama = p.Aciklama;
            repo.TUpdate(sertifika);       
            return RedirectToAction("Index");
        }
    }
}