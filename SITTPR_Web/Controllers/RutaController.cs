using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers {
    public class RutaController : Controller {
        TipoService tipo = new TipoService();
        RutaService ruta = new RutaService();
        EquipoService equipo = new EquipoService();
        EstaticosService estaticos = new EstaticosService();
        
        public ActionResult Listar() {
            return View(ruta.listar());
        }

        public ActionResult Registrar(string mensaje) {
            ViewBag.mensaje = mensaje;

            ViewBag.turno = new SelectList(estaticos.turno(), "codigo", "descripcion");
            ViewBag.tipo = new SelectList(tipo.listarTipoRuta(), "codigo", "descripcion");
            ViewBag.empleado = new SelectList(estaticos.empleados(), "codigo", "descripcion");
            ViewBag.equipo = new SelectList(equipo.listar(), "codigo", "descripcion");

            return View(new RutaEntity());
        }

        [HttpPost] 
		public ActionResult Registrar(RutaEntity ru) {
            ru.codigo = ruta.generarCodigo();
            ru.fechaReg = DateTime.Now;
            ru.horaPartida = ru.horaPartida + ".00";

            EquipoEntity reg = equipo.listar().Where(e => e.codigo == ru.equipo).FirstOrDefault();

            ru.placa = reg.placa;

            string msg = ruta.registrar(ru);
            return RedirectToAction("Registrar", "Ruta", new { mensaje = msg });
        }
    }
}