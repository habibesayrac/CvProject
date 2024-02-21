using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TBLSosyalMedya> repo = new GenericRepository<TBLSosyalMedya>();

        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TBLSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalMedyaDuzenle(int id)
        {
            var sosyalmedya = repo.Find(x=>x.ID==id);
            return View(sosyalmedya);
        }
        [HttpPost]
        public ActionResult SosyalMedyaDuzenle(TBLSosyalMedya p)
        {
            var sosyalmedya = repo.Find(x => x.ID == p.ID);
            sosyalmedya.Ad = p.Ad;
            sosyalmedya.Link = p.Link;
            sosyalmedya.ikon = p.ikon;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalMedyaSil(int id)
        {
            var sosyalmedya = repo.Find(x => x.ID == id);
            if (sosyalmedya.Durum == true)
            {
                sosyalmedya.Durum = false;

            }
            else
            {
                sosyalmedya.Durum = true;
            }

            repo.TUpdate(sosyalmedya);
            return RedirectToAction("Index");

        }

    }
}