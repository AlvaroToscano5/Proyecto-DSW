using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers {
    public class MenuController : Controller {
        EmpleadoService empleado = new EmpleadoService();

        public ActionResult Login(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View(new EmpleadoEntity());
        }

        [HttpPost]
        public ActionResult Login(EmpleadoEntity reg) {
            string acceso = empleado.iniciarSesion(reg.usuario, reg.contraseña);
            string vista = vistas(acceso);
            string msg = "";

            if (acceso == "Error") {
                msg = "Credenciales Incorrectas";
            } else if (acceso == "Inactivo") {
                msg = "Empleado Inactivo";
            } else {
                EmpleadoEntity emp = empleado.listar().Where(e => e.usuario == reg.usuario).FirstOrDefault();
                msg = "Bienvenido: " + emp.nombre + " " + emp.apellidos;
            }

            return RedirectToAction(vista, "Menu", new { mensaje = msg });
        }

        public string vistas(string acceso) {
            string vista = "";

            if (acceso == "Error") {
                vista = "Login";
            } if (acceso == "Inactivo") {
                vista = "Login";
            } if (acceso == "Administrador") {
                vista = "Administrador";
            } if (acceso == "GerenteGeneral") {
                vista = "GerenteGeneral";
            } if (acceso == "AsistenteRRHH") {
                vista = "AsistenteRRHH";
            } if (acceso == "GerenteRRHH") {
                vista = "GerenteRRHH";
            } if (acceso == "AsistenteDC") {
                vista = "AsistenteDC";
            } if (acceso == "GerenteDC") {
                vista = "GerenteDC";
            } if (acceso == "AsistenteST") {
                vista = "AsistenteST";
            } if (acceso == "GerenteST") {
                vista = "GerenteST";
            } if (acceso == "AsistenteCAU") {
                vista = "AsistenteCAU";
            } if (acceso == "GerenteCAU") {
                vista = "GerenteCAU";
            } if (acceso == "Cajero") {
                vista = "Cajero";
            } if (acceso == "EncargadoP") {
                vista = "EncargadoP";
            }

            return vista;
        }

        public ActionResult Administrador(string mensaje) {
            ViewBag.mensaje = mensaje; 

            return View();
        }

        public ActionResult GerenteGeneral(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View();
        }

        public ActionResult AsistenteRRHH(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View();
        }

        public ActionResult GerenteRRHH(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View();
        }

        public ActionResult AsistenteDC(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View();
        }

        public ActionResult GerenteDC(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View();
        }

        public ActionResult AsistenteST(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View();
        }

        public ActionResult GerenteST(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View();
        }

        public ActionResult AsistenteCAU(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View();
        }

        public ActionResult GerenteCAU(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View();
        }

        public ActionResult Cajero(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View();
        }

        public ActionResult EncargadoP(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View();
        }
    }
}