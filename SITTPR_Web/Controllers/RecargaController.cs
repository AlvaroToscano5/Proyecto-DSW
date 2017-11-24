using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers
{
    public class RecargaController : Controller
    {
        RecargaService recarga = new RecargaService();

        public ActionResult Recargar(string mensaje)
        {
            ViewBag.mensaje = mensaje;

            return View(new RecargaEntity());
        }

        [HttpPost]
        public ActionResult Recargar(RecargaEntity rec)
        {
            string msg = recarga.recargar(rec);
            return RedirectToAction("Recargar", "Recarga", new { mensaje = msg });
        }
    }
}