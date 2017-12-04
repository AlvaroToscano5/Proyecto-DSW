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
        UsuarioService usuario = new UsuarioService();

        public ActionResult Login(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View(new EmpleadoEntity());
        }

        [HttpPost]
        public ActionResult Login(EmpleadoEntity reg) {
            string acceso = empleado.iniciarSesion(reg.usuario, reg.contraseña);
            string vista = vistas(acceso);
            string msg = "";
            string cod = "";

            if (acceso == "Error") {
                msg = "Credenciales Incorrectas";
            } else if (acceso == "Inactivo") {
                msg = "Empleado Inactivo";
            } else {
                EmpleadoEntity emp = empleado.listar().Where(e => e.usuario == reg.usuario).FirstOrDefault();
                msg = "Bienvenido: " + emp.nombre + " " + emp.apellidos;
                cod = emp.codigo;
            }

            return RedirectToAction(vista, "Menu", new { mensaje = msg, codigo = cod });
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

        public ActionResult LoginU(string mensaje) {
            ViewBag.mensaje = mensaje;

            return View(new UsuarioEntity());
        }

        [HttpPost]
        public ActionResult LoginU(UsuarioEntity reg) {
            string acceso = usuario.iniciarSesion(reg.usuario, reg.contraseña);
            string vista = vistas(acceso);
            string msg = "";
            string nom = "";
            string cod = "";

            if (acceso == "Error") {
                msg = "Credenciales Incorrectas";
            } else if (acceso == "Inactivo") {
                msg = "Empleado Inactivo";
            } else {
                UsuarioEntity usu = usuario.listar().Where(u => u.usuario == reg.usuario).FirstOrDefault();
                msg = "Bienvenido: " + usu.nombre + " " + usu.apellidos;
                nom = usu.nombre + " " + usu.apellidos;
                cod = usu.codigo;
            }

            return RedirectToAction("Usuario", "Menu", new { mensaje = msg, nombre = nom, codigo = cod });
        }

        public ActionResult Administrador(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult Administrador(string codigo) {
            ViewBag.id = codigo;
            ViewBag.administrador = "Administrador";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.administrador }); ;
        }

        public ActionResult GerenteGeneral(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult GerenteGeneral(string codigo) {
            ViewBag.id = codigo;
            ViewBag.gerentegeneral = "GerenteGeneral";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.gerentegeneral }); ;
        }

        public ActionResult AsistenteRRHH(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult AsistenteRRHH(string codigo) {
            ViewBag.id = codigo;
            ViewBag.asistenterrhh = "AsistenteRRHH";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.asistenterrhh }); ;
        }

        public ActionResult GerenteRRHH(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult GerenteRRHH(string codigo) {
            ViewBag.id = codigo;
            ViewBag.gerenterrhh = "GerenteRRHH";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.gerenterrhh }); ;
        }

        public ActionResult AsistenteDC(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult AsistenteDC(string codigo) {
            ViewBag.id = codigo;
            ViewBag.asistentedc = "AsistenteDC";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.asistentedc }); ;
        }

        public ActionResult GerenteDC(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult GerenteDC(string codigo) {
            ViewBag.id = codigo;
            ViewBag.gerentedc = "GerenteDC";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.gerentedc }); ;
        }

        public ActionResult AsistenteST(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult AsistenteST(string codigo) {
            ViewBag.id = codigo;
            ViewBag.asistentest = "AsistenteST";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.asistentest }); ;
        }

        public ActionResult GerenteST(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult GerenteST(string codigo) {
            ViewBag.id = codigo;
            ViewBag.gerentest = "GerenteST";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.gerentest }); ;
        }

        public ActionResult AsistenteCAU(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult AsistenteCAU(string codigo) {
            ViewBag.id = codigo;
            ViewBag.asistentecau = "AsistenteCAU";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.asistentecau }); ;
        }

        public ActionResult GerenteCAU(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult GerenteCAU(string codigo) {
            ViewBag.id = codigo;
            ViewBag.gerentecau = "GerenteCAU";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.gerentecau }); ;
        }

        public ActionResult Cajero(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult Cajero(string codigo) {
            ViewBag.id = codigo;
            ViewBag.cajero = "Cajero";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.cajero }); ;
        }

        public ActionResult EncargadoP(string mensaje, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult EncargadoP(string codigo) {
            ViewBag.id = codigo;
            ViewBag.encargadop = "EncargadoP";

            return RedirectToAction("Perfil", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.encargadop }); ;
        }

        public ActionResult Usuario(string mensaje, string nombre, string codigo) {
            ViewBag.mensaje = mensaje;
            ViewBag.nombre = nombre;
            ViewBag.codigo = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult Usuario(string codigo) {
            ViewBag.id = codigo;
            ViewBag.usuario = "Usuario";

            return RedirectToAction("PerfilU", "Menu", new { codigo = ViewBag.id, titulo = ViewBag.usuario }); ;
        }

        public ActionResult Perfil(string codigo, string titulo) {
            ViewBag.vista = titulo;
            EmpleadoEntity emp = empleado.listar().Where(e => e.codigo == codigo).FirstOrDefault();

            return View(emp);
        }

        [HttpPost]
        public ActionResult Perfil(EmpleadoEntity emp) {
            return RedirectToAction("ActualizarDatos", "Empleado", new { id = emp.codigo });
        }

        public ActionResult PerfilU(string codigo, string titulo) {
            ViewBag.vista = titulo;
            UsuarioEntity usu = usuario.listar().Where(u => u.codigo == codigo).FirstOrDefault();

            return View(usu);
        }

        [HttpPost]
        public ActionResult PerfilU(UsuarioEntity usu) {
            return RedirectToAction("ActualizarDatos", "Usuario", new { id = usu.codigo });
        }
    }
}