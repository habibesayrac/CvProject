using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {

        HakkimdaRepository repo = new HakkimdaRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TBLHakkimda p)
        {
            var hakkimda = repo.Find(x=>x.ID == p.ID);
            hakkimda.Ad = p.Ad;
            hakkimda.Soyad= p.Soyad;
            hakkimda.Adres = p.Adres;
            hakkimda.Telefon = p.Telefon;
            hakkimda.Mail = p.Mail;
            hakkimda.Aciklama = p.Aciklama;
            hakkimda.Resim = p.Resim;
            repo.TUpdate(hakkimda);
            return RedirectToAction("Index");
        }
    }
}