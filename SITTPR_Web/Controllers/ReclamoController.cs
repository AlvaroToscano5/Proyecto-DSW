using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers {
    public class ReclamoController : Controller {
        ReclamoService reclamo = new ReclamoService();
        UsuarioService usuario = new UsuarioService();

        public ActionResult Listar() {
            return View(reclamo.listar());
        }

        public ActionResult Generar(string mensaje) {
            ViewBag.mensaje = mensaje;

            ViewBag.pais = new SelectList(reclamo.listar(), "codigo", "descripcion");
            //   ViewBag.estacion = new SelectList(estacion.listar(), "codigo", "descripcion");

            return View(new ReclamoEntity());
        }

        [HttpPost]
        public ActionResult Generar(ReclamoEntity reg) {

            UsuarioEntity usu = usuario.listar().Where(u => u.dni == reg.dni).FirstOrDefault();


            reg.usuario = usu.codigo;
            reg.nombre = usu.nombre;
            reg.apellido = usu.apellidos;
            reg.tipo = usu.tipo;
            reg.fechaReg = DateTime.Now;
            reg.fechaAct = DateTime.Now;





            string msg = reclamo.generar(reg);
            return RedirectToAction("Generar", "Reclamo", new { mensaje = msg });
        }
    }
}