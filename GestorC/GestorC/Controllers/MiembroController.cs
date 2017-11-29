using GestorC.Models;
using GestorC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestorC.Controllers
{
    public class MiembroController : Controller
    {
        // GET: Miembro
        [HttpGet]
        public ActionResult Index()
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            return View(new VM_Secretaria() { proxy = prox });
        }

        [HttpGet]
        public ActionResult PrevioAgenda(string sesion)
        {
            //UberController.Instance.getControlador().ag
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            return View(new VM_Secretaria() { proxy = prox , sesionSeleccionada = UberController.Instance.getControlador().getSesion(sesion) });
        }

        [HttpPost]
        public ActionResult PrevioAgenda(string nombre, string resultandos, string considerandos, string acuerda, string sess)
        {
            //return Content(nombre + resultandos + considerandos + acuerda);
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            prox.agregarSolicitud(nombre,resultandos,considerandos,acuerda,'S');
            return RedirectToAction("Index","Miembro");
        }

        [HttpGet]
        public ActionResult Durante(string sesion)
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            return View(new VM_Secretaria() { proxy = prox , sesionSeleccionada = UberController.Instance.getControlador().getSesion(sesion) });
        }
    }
}