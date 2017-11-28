using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers {
    public class RecargaController : Controller {
        RecargaService recarga = new RecargaService();
        UsuarioService usuario = new UsuarioService();

        public ActionResult Recargar(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View(new RecargaEntity());
        }

        [HttpPost]
        public ActionResult Recargar(RecargaEntity rec) {
            string msg = "";

            if (usuario.listar().Where(u => u.dni == rec.dni).Count() != 0) {
                rec.codigo = recarga.generarCodigo();
                rec.fechaReg = DateTime.Now.ToShortDateString().ToString();

                UsuarioEntity reg = usuario.listar().Where(u => u.dni == rec.dni).FirstOrDefault();

                rec.usuario = reg.codigo;
                msg = recarga.recargar(rec);
            } else {
                msg = "Dni Ingresado, No Existe";
            }

            
            return RedirectToAction("Recargar", "Recarga", new { mensaje = msg });
        }
    }
}