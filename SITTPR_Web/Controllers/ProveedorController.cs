using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers {
    public class ProveedorController : Controller {
        PaisService pais = new PaisService();
        ProveedorService proveedor = new ProveedorService();
        
        public ActionResult Listar() {
            return View(proveedor.listar());
        }

        public ActionResult Registrar(string mensaje) {
            ViewBag.mensaje = mensaje;

            ViewBag.pais = new SelectList(pais.listarPais(), "codigo", "descripcion");




            return View(new ProveedorEntity());
        }

        [HttpPost]
        public ActionResult Registrar(ProveedorEntity reg) {
            reg.codigo = proveedor.generarCodigo();
            reg.fechaReg = DateTime.Now;
            reg.fechaAct = DateTime.Now;
            reg.ctaBancaria = proveedor.formatoCuenta(reg.ctaBancaria);
            string msg = proveedor.registrar(reg);
            return RedirectToAction("Registrar", "Proveedor", new { mensaje = msg });
        }

        public ActionResult Actualizar(string mensaje, string id) {
            ViewBag.mensaje = mensaje;

            ProveedorEntity reg = proveedor.listar().Where(e => e.codigo == id).FirstOrDefault();

            ViewBag.paisPro = new SelectList(pais.listarPais(), "codigo", "descripcion", reg.pais);

            return View(reg);
        }

        [HttpPost]
        public ActionResult Actualizar(ProveedorEntity reg) {
            reg.fechaAct = DateTime.Now;

            string msg = proveedor.actualizar(reg);

            return RedirectToAction("Actualizar", "Proveedor", new { mensaje = msg });
        }
    }
}