using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        IletisimRepository repo = new IletisimRepository();
        public ActionResult Index()
        {
            var iletisim = repo.List();
            return View(iletisim);
        }
    }
}