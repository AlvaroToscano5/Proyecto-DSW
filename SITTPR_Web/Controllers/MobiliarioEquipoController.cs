using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers {
    public class MobiliarioEquipoController : Controller {
        MobiliarioService mobiliario = new MobiliarioService();
        EquipoService equipo = new EquipoService();
        ProveedorService proveedor = new ProveedorService();
        TipoService tipo = new TipoService();
        EstadoService estado = new EstadoService();
        EstacionService estacion = new EstacionService();

        public ActionResult ListarM() {
            return View(mobiliario.listar());
        }

        public ActionResult ListarE() {
            return View(equipo.listar());
        }

        public ActionResult RegistrarE(string mensaje) {
            ViewBag.mensaje = mensaje;

            ViewBag.proveedor = new SelectList(proveedor.listar(), "codigo", "razsocial");
            ViewBag.tipo = new SelectList(tipo.listarTipoEqMob(), "codigo", "descripcion");

            return View(new EquipoEntity());
        }

        [HttpPost]
        public ActionResult RegistrarE(EquipoEntity reg) {
            reg.codigo = equipo.generarCodigo();
            reg.fechaReg = DateTime.Now.ToShortDateString().ToString();
            reg.fechaAct = DateTime.Now.ToShortDateString().ToString();
            reg.estado = "EEM01";
            string msg = equipo.registrar(reg);
            return RedirectToAction("RegistrarE", "MobiliarioEquipo", new { mensaje = msg });
        }

        public ActionResult ActualizarE(string mensaje, string id) {
            ViewBag.mensaje = mensaje;

            EquipoEntity reg = equipo.listar().Where(e => e.codigo == id).FirstOrDefault();

            ViewBag.proveedorEq = new SelectList(proveedor.listar(), "codigo", "razsocial", reg.proveedor);
            ViewBag.tipoEq = new SelectList(tipo.listarTipoEqMob(), "codigo", "descripcion", reg.tipo);
            ViewBag.estadoEq = new SelectList(estado.listarEstadoMobEquip(), "codigo", "descripcion", reg.estado);

            return View(reg);
        }

        [HttpPost]
        public ActionResult ActualizarE(EquipoEntity reg) {
            reg.fechaAct = DateTime.Now.ToShortDateString().ToString();

            string msg = equipo.actualizar(reg);

            return RedirectToAction("ActualizarE", "MobiliarioEquipo", new { mensaje = msg });
        }

        public ActionResult RegistrarM(string mensaje) {
            ViewBag.mensaje = mensaje;

            ViewBag.proveedor = new SelectList(proveedor.listar(), "codigo", "razsocial");
            ViewBag.tipo = new SelectList(tipo.listarTipoEqMob(), "codigo", "descripcion");
            ViewBag.estacion = new SelectList(estacion.listarEstacion(), "codigo", "descripcion");

            return View(new MobiliarioEntity());
        }

        [HttpPost]
        public ActionResult RegistrarM(MobiliarioEntity reg) {
            reg.codigo = mobiliario.generarCodigo();
            reg.fechaReg = DateTime.Now.ToShortDateString().ToString();
            reg.fechaAct = DateTime.Now.ToShortDateString().ToString();
            reg.estado = "EEM01";
            string msg = mobiliario.registrar(reg);
            return RedirectToAction("RegistrarM", "MobiliarioEquipo", new { mensaje = msg });
        }

        public ActionResult ActualizarM(string mensaje, string id) {
            ViewBag.mensaje = mensaje;

            MobiliarioEntity reg = mobiliario.listar().Where(e => e.codigo == id).FirstOrDefault();

            ViewBag.proveedorMob = new SelectList(proveedor.listar(), "codigo", "razsocial", reg.proveedor);
            ViewBag.tipoMob = new SelectList(tipo.listarTipoEqMob(), "codigo", "descripcion", reg.tipo);
            ViewBag.estadoMob = new SelectList(estado.listarEstadoMobEquip(), "codigo", "descripcion", reg.estado);
            ViewBag.estacionMob = new SelectList(estacion.listarEstacion(), "codigo", "descripcion", reg.estacion);

            return View(reg);
        }

        [HttpPost]
        public ActionResult ActualizarM(MobiliarioEntity reg) {
            reg.fechaAct = DateTime.Now.ToShortDateString().ToString();

            string msg = mobiliario.actualizar(reg);

            return RedirectToAction("ActualizarM", "MobiliarioEquipo", new { mensaje = msg });
        }
    }
}