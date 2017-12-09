using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers {
    public class MantenimientoController : Controller {
        MantenimientoService mantenimiento = new MantenimientoService();

        public ActionResult ListarM()
        {
            if (Session["carrito"] == null)
            {
                Session["carrito"] = new List<DetMobMantenimiento>();
            }

            ViewBag.contador = contador();
            return View(mantenimiento.listarMobiliario());
        }

        public ActionResult Select(String codigo)
        {
            MobiliarioEntity reg = mantenimiento.listarMobiliario().Where(
                M => M.codigo == codigo).FirstOrDefault();

            return View(reg);
        }

        int contador()
        {
            return ((List<DetMobMantenimiento>)Session["carrito"]).Count();
        }

        public ActionResult Agregar(String codigo) {
            //recupero el registro del Mobiliario seleccionado
            MobiliarioEntity reg = mantenimiento.listarMobiliario().Where(
               M => M.codigo == codigo).FirstOrDefault();
            //definir un registro y agregarlo al carrito
            DetMobMantenimiento item = new DetMobMantenimiento();
            item.codigoMob = codigo;
            item.estacionMob = reg.estacion;
            item.tipoMob = reg.tipo;
            item.nombreMob = reg.descripcion;

            List<DetMobMantenimiento> carrito = (List<DetMobMantenimiento>)Session["carrito"];
            carrito.Add(item);

            return RedirectToAction("ListarM");
        }

        public ActionResult Mantenimiento(string mensaje) {
            ViewBag.mensaje = mensaje;

            if (Session["carrito"] == null)
            {
                return View("Index");
            }
            else
            {
                return View((List<DetMobMantenimiento>)Session["carrito"]);
            }
        }

        [HttpPost]
        public ActionResult Mantenimiento()
        {
            string msg = "Mantenimiento Realizado con Exito";
            return RedirectToAction("Mantenimiento", "Mantenimiento", new { mensaje = msg });
        }

        public ActionResult Delete(String codigo) {
            List<DetMobMantenimiento> listado = (List<DetMobMantenimiento>)Session["carrito"];

            DetMobMantenimiento reg = listado.Where(
                M => M.codigoMob == codigo).FirstOrDefault();

            listado.Remove(reg);
            return RedirectToAction("Compra");
        }

        public ActionResult ListarE()
        {
            if (Session["cambioE"] == null)
            {
                Session["cambioE"] = new List<DetEqCambio>();
            }

            ViewBag.contador = contadorE();
            return View(mantenimiento.listarEquipo());
        }

        int contadorE()
        {
            return ((List<DetEqCambio>)Session["cambioE"]).Count();
        }
    }
}