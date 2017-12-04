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
        EstacionService estacion = new EstacionService();
        EstaticosService estaticos = new EstaticosService();

        public ActionResult Listar() {
            return View(reclamo.listar());
        }

        public ActionResult Generar(string mensaje) {
            ViewBag.mensaje = mensaje;

            ViewBag.estacion = new SelectList(estacion.listarEstacion(), "codigo", "descripcion");
            ViewBag.empleado = new SelectList(estaticos.empleados(), "codigo", "descripcion");

            return View(new ReclamoEntity());
        }

        [HttpPost]
        public ActionResult Generar(ReclamoEntity rec) {
            rec.codigo = reclamo.generarCodigo();

            UsuarioEntity usu = usuario.listar().Where(u => u.dni == rec.dni).FirstOrDefault();
            
            rec.nombre = usu.nombre;
            rec.apellido = usu.apellidos;
            rec.tipo = usu.tipo;
            rec.fechaReg = DateTime.Now;
            rec.fechaAct = DateTime.Now;
            rec.estado = "Por Revisar";
            rec.usuario = usu.codigo;

            string msg = reclamo.generar(rec);
            return RedirectToAction("Generar", "Reclamo", new { mensaje = msg });
        }
    }
}