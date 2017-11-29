using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers
{
    public class ReclamoController : Controller
    {
        ReclamoService reclamo = new ReclamoService();


        public ActionResult Listar()
        {
            return View(reclamo.listar());
        }

        public ActionResult Generar(string mensaje)
        {
            ViewBag.mensaje = mensaje;

            ViewBag.pais = new SelectList(reclamo.listar(), "codigo", "descripcion");

            return View(new ReclamoEntity());
        }

        [HttpPost]
        public ActionResult Generar(ReclamoEntity reg)
        {
            reg.codigo = reclamo.ToString();
            reg.fechaReg = DateTime.Now.ToShortDateString().ToString();
           string msg = reclamo.generar(reg);
            return RedirectToAction("Generar", "Reclamo", new { mensaje = msg });
        }
    }
}