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
    }
}