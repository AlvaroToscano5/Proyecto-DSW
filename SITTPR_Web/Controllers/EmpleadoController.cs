using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers {
    public class EmpleadoController : Controller {
        TipoService tipo = new TipoService();
        EstadoService estado = new EstadoService();
        EstacionService estacion = new EstacionService();
        AreaService area = new AreaService();
        EmpleadoService empleado = new EmpleadoService();
        EstaticosService estaticos = new EstaticosService();

        public ActionResult Listar() {
            return View(empleado.listar());
        }

        public ActionResult Registrar(string mensaje) {
            ViewBag.mensaje = mensaje;

            ViewBag.sexo = new SelectList(estaticos.generos(), "codigo", "descripcion");
            ViewBag.tipo = new SelectList(tipo.listarTipoEmpleado(), "codigo", "descripcion");
            ViewBag.estacion = new SelectList(estacion.listarEstacion(), "codigo", "descripcion");
            ViewBag.area = new SelectList(area.listarArea(), "codigo", "descripcion");

            return View(new EmpleadoEntity());
        }

        [HttpPost]
        public ActionResult Registrar(EmpleadoEntity reg) {
            reg.codigo = empleado.generarCodigo();
            reg.usuario = empleado.generarUsuario(reg.nombre, reg.apellidos);
            reg.contraseña = reg.dni;
            reg.correo = reg.usuario + "@atu.com";
            reg.fechaReg = DateTime.Now;
            reg.fechaAct = DateTime.Now;
            reg.estado = "EEU01";

            string msg = empleado.registrar(reg);
            return RedirectToAction("Registrar", "Empleado", new { mensaje = msg });
        }

        public ActionResult Actualizar(string mensaje, string id) {
            ViewBag.mensaje = mensaje;

            EmpleadoEntity reg = empleado.listar().Where(e => e.codigo == id).FirstOrDefault();

            ViewBag.tipoEmp = new SelectList(tipo.listarTipoEmpleado(), "codigo", "descripcion", reg.tipo);
            ViewBag.estadoEmp = new SelectList(estado.listarEstadoEmpUsu(), "codigo", "descripcion", reg.estado);
            ViewBag.estacionEmp = new SelectList(estacion.listarEstacion(), "codigo", "descripcion", reg.estacion);
            ViewBag.areaEmp = new SelectList(area.listarArea(), "codigo", "descripcion", reg.area);

            return View(reg);
        }

        [HttpPost]
        public ActionResult Actualizar(EmpleadoEntity reg) {
            reg.fechaAct = DateTime.Now;

            string msg = empleado.actualizar(reg);

            return RedirectToAction("Actualizar", "Empleado", new { mensaje = msg });
        }
    }
}