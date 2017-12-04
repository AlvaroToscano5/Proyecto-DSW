using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers {
    public class UsuarioController : Controller {
        UsuarioService usuario = new UsuarioService();
        TipoService tipo = new TipoService();
        EstadoService estado = new EstadoService();
        EstaticosService estaticos = new EstaticosService();

        public ActionResult Listar() {
            return View(usuario.listar());
        }

        public ActionResult ListarCaja() {
            return View(usuario.listar());
        }

        public ActionResult Registrar(string mensaje) {
            ViewBag.mensaje = mensaje;

            ViewBag.sexo = new SelectList(estaticos.generos(), "codigo", "descripcion");
            ViewBag.tipo = new SelectList(tipo.listarTipoUsuario(), "codigo", "descripcion");

            return View(new UsuarioEntity());
        }

        [HttpPost]
        public ActionResult Registrar(UsuarioEntity reg) {
            reg.codigo = usuario.generarCodigo();
            reg.usuario = usuario.generarUsuario(reg.nombre, reg.apellidos);
            reg.contraseña = reg.dni;
            reg.saldo = 0;
            reg.fechaReg = DateTime.Now;
            reg.fechaAct = DateTime.Now;
            reg.estado = "EEU01";

            string msg = usuario.registrar(reg);
            return RedirectToAction("Registrar", "Usuario", new { mensaje = msg });
        }

        public ActionResult Actualizar(string mensaje, string id) {
            ViewBag.mensaje = mensaje;

            UsuarioEntity reg = usuario.listar().Where(e => e.codigo == id).FirstOrDefault();

            ViewBag.tipoUsu = new SelectList(tipo.listarTipoUsuario(), "codigo", "descripcion", reg.tipo);
            ViewBag.estadoUsu = new SelectList(estado.listarEstadoEmpUsu(), "codigo", "descripcion", reg.estado);

            return View(reg);
        }

        [HttpPost]
        public ActionResult Actualizar(UsuarioEntity reg) {
            reg.fechaAct = DateTime.Now;

            string msg = usuario.actualizar(reg);

            return RedirectToAction("Actualizar", "Usuario", new { mensaje = msg });
        }

        public ActionResult ActualizarTipo(string mensaje, string id) {
            ViewBag.mensaje = mensaje;

            UsuarioEntity reg = usuario.listar().Where(e => e.codigo == id).FirstOrDefault();

            ViewBag.tipoUsu = new SelectList(tipo.listarTipoUsuario(), "codigo", "descripcion", reg.tipo);

            return View(reg);
        }

        [HttpPost]
        public ActionResult ActualizarTipo(UsuarioEntity reg) {

            string msg = usuario.actualizarTipo(reg);

            return RedirectToAction("ActualizarTipo", "Usuario", new { mensaje = msg });
        }

        public ActionResult ActualizarDatos(string mensaje, string id) {
            ViewBag.mensaje = mensaje;

            UsuarioEntity reg = usuario.listar().Where(u => u.codigo == id).FirstOrDefault();

            return View(reg);
        }

        [HttpPost]
        public ActionResult ActualizarDatos(UsuarioEntity reg) {
            reg.fechaAct = DateTime.Now;

            string msg = usuario.actualizarDatos(reg);

            return RedirectToAction("PerfilU", "Menu", new { mensaje = msg, codigo = reg.codigo });
        }
    }
}