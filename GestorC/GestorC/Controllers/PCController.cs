using GestorC.Models;
using GestorC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestorC.Controllers
{
    public class PCController : Controller
    {
        // GET: PC
        [HttpGet]
        public ActionResult Index()
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            return View(new VM_Secretaria() { proxy = prox });
        }

        [HttpGet]
        public ActionResult PrevioAgenda(string sesion)
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            return View(new VM_Secretaria() { proxy = prox , sesionSeleccionada = UberController.Instance.getControlador().getSesion(sesion) });
            //return Content("previo");
        }

        [HttpGet]
        public ActionResult AgregarPunto(string id, string sess)
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            prox.aceptarSolicitud(int.Parse(id));
            return RedirectToAction("PrevioAgenda", new { sesion = sess });
        }

        [HttpGet]
        public ActionResult EliminarPunto(string id, string sess)
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            prox.eliminarSolicitud(int.Parse(id));
            return RedirectToAction("PrevioAgenda", new { sesion = sess });
        }

        [HttpGet]
        public ActionResult IniciarSesion(string sess)
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            //prox.eliminarSolicitud(int.Parse(id));
            prox.iniciarSesion(sess);
            return RedirectToAction("Index");
        }
    }
}