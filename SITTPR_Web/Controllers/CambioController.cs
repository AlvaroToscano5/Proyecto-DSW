using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace SITTPR_Web.Controllers {
    public class CambioController : Controller  {
        CambioService cambio = new CambioService();
                        
        public ActionResult Index(){
            if (Session["carrito"] == null)
            {
                Session["carrito"] = new List<DetMobCambio>();
            }

            ViewBag.contador = contador();
            return View(cambio.listarMobiliario());
        }

        public ActionResult Select(String codigo) {
            MobiliarioEntity reg = cambio.listarMobiliario().Where(
                M => M.codigo == codigo).FirstOrDefault();

            return View(reg);
        }      

        int contador() {
            return ((List<DetMobCambio>)Session["carrito"]).Count();
        }

        public ActionResult Agregar(String codigo) {
            //recupero el registro del Mobiliario seleccionado
            MobiliarioEntity reg = cambio.listarMobiliario().Where(
               M => M.codigo == codigo).FirstOrDefault();
            //definir un registro y agregarlo al carrito
            DetMobCambio item = new DetMobCambio();
            item.codigoMob = codigo;
            item.estacionMob = reg.estacion;
            item.tipoMob = reg.tipo;
            item.nombreMob = reg.descripcion;

            List<DetMobCambio> carrito = (List<DetMobCambio>)Session["carrito"];
            carrito.Add(item);

            return RedirectToAction("Index");
        }

        public ActionResult Compra() {
            if (Session["carrito"] == null) {
                return View("Index");
            } else {                
                return View((List<DetMobCambio>)Session["carrito"]);
            }
        }

        public ActionResult Delete(String codigo) {            
            List<DetMobCambio> listado = (List<DetMobCambio>)Session["carrito"];
                        
            DetMobCambio reg = listado.Where(
                M => M.codigoMob == codigo).FirstOrDefault();
            
            listado.Remove(reg);
            return RedirectToAction("Compra");
        }


        public ActionResult ListarEquipo() {
            if (Session["cambioE"] == null) {
                Session["cambioE"] = new List<DetEqCambio>();
            }

            ViewBag.contador = contadorE();
            return View(cambio.listarEquipo());
        }

        int contadorE() {
            return ((List<DetEqCambio>)Session["cambioE"]).Count();
        }
    }
}