using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        YetenekRepository repo = new YetenekRepository();
        public ActionResult Index()
        {
            var yetenek = repo.List();
            return View(yetenek);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TBLYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            TBLYeteneklerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
           var yetenek = repo.Find(x=>x.ID == id);
            return View(yetenek);
        } 
        [HttpPost]
        public ActionResult YetenekGetir(TBLYeteneklerim p)
        {
           var yetenek = repo.Find(x=>x.ID == p.ID);
            yetenek.Yetenek = p.Yetenek;
            yetenek.Oran = p.Oran;
            repo.TUpdate(yetenek);
            return RedirectToAction("Index");
        }
    }
}