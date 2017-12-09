using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SITTPR_Web.Controllers {
    public class HomeController : Controller {

        public ActionResult Index()  {
            return View();
        }

        public ActionResult Troncal() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Alimentadores() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AboutMetropolitano() {
            return View();
        }

        public ActionResult CorredorAzul()
        {
            return View();
        }

        public ActionResult CorredorRojo() {
            return View();
        }

        public ActionResult CorredorMorado() {
            return View();
        }

        public ActionResult AboutCorredores() {
            return View();
        }

        public ActionResult Rutas() {
            return View();
        }

        public ActionResult AboutTren() {
            return View();
        }
    }
}