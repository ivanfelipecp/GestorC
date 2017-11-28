using GestorC.Models;
using GestorC.ViewModels;
using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestorC.Controllers
{
    public class SecretariaController : Controller
    {
        
        // GET: Secretaria
        [HttpGet]
        public ActionResult Index()
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);

            return View(new VM_Secretaria() { proxy = prox});
        }

        [HttpGet]
        public ActionResult PrevioAgenda(string sesion)
        {

            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            // return Content(sesion);
            return View(new VM_Secretaria() { proxy = prox, sesionSeleccionada = UberController.Instance.getControlador().getSesion(sesion) });
        }

        [HttpPost]
        public ActionResult PrevioAgendaPost(string sesion)
        {
            // aqui se hace algo con encabezado y cuerpo, luego se envia al otro view
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);

            /* if (file1 != null)
            {
                var fileName = Path.GetFileName(file1.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads/"), fileName);
                file1.SaveAs(path);
                return Content(file1.ToString());
            } */

            UberController.Instance.getControlador().crearAgenda(sesion, Path.Combine(Server.MapPath("~/App_Data/agendas")));
            DateTime fecha = UberController.Instance.getControlador().getSesion(sesion).Fecha;
            UberController.Instance.getControlador().enviarAgenda(sesion, fecha, "fauriciocr@gmail.com", Path.Combine(Server.MapPath("~/App_Data/agendas/Agenda Sesión Ordinaria-"+sesion+".pdf")));
            return RedirectToAction("Index","Secretaria");
        }

        /*[HttpGet]
        public ActionResult PrevioNotificar()
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);

            return View(new VM_Secretaria() { proxy = prox });
            
        }

        [HttpPost]
        public ActionResult PrevioNotificar(string cuerpo, string encabezado)
        {
            /* if (file1 != null)
            {
                var fileName = Path.GetFileName(file1.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads/"), fileName);
                file1.SaveAs(path);
                return Content(file1.ToString());
            } 
            //UberController.Instance.getControlador().no
            return Content(cuerpo +"-"+ encabezado + "-" + "file");
        }*/

        [HttpGet]
        public ActionResult PrevioCrear()
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            return View(new VM_Secretaria() { proxy = prox });
        }

        [HttpPost]
        public ActionResult PrevioCrear(int numero, string lugar, DateTime fecha)
        {
            UberController.Instance.getControlador().nuevaSesion(numero.ToString() + "-" + fecha.Year.ToString(), fecha, lugar);
            UberController.Instance.getControlador().enviarNotificacion(numero.ToString(), fecha, "fauriciocr@gmail.com",Path.Combine(Server.MapPath("~/App_Data/uploads/MEMO_JUSTIFICACION_DE_AUSENCIAS_AL_CONSEJO.doc")));
            return RedirectToAction("Index");
            //aaca
        }

        [HttpPost]
        public ActionResult ActualizarMiembros(HttpPostedFileBase file)
        {
            if(file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads/"), fileName);
                file.SaveAs(path);
                UberController.Instance.getControlador().actualizarMiembros(path);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Durante(string sesion)
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            // return Content(sesion);
            return View(new VM_Secretaria() { proxy = prox, sesionSeleccionada = UberController.Instance.getControlador().getSesion(sesion)});
        }

        [HttpGet]
        public ActionResult Asistencia(string correo, bool estado)
        {
            return Content(correo + estado.ToString());
        }

        [HttpPost]
        public ActionResult Votacion(string id, int favor, int contra, int abstenciones)
        {
            return Content(id.ToString() + favor.ToString() + contra.ToString() + abstenciones.ToString());
        }

        [HttpPost]
        public ActionResult Comentario(string correo, string comentario)
        {
            return Content(correo + comentario);
        }

        [HttpGet]
        public ActionResult Despues(string sesion)
        {
            Proxy prox = UberController.Instance.getProxy(Session["current"] as string);
            // return Content(sesion);
            return View(new VM_Secretaria() { proxy = prox, sesionSeleccionada = UberController.Instance.getControlador().getSesion(sesion) });
        }

        [HttpPost] // acta
        public ActionResult Descargar(int tipo, string sesion)
        {

            // Con sesion tenemos el número
            // proxy(sesion,tipo,Server.MapPath("~")+"\\App_Data\\actas")
            UberController.Instance.getControlador().crearActa(sesion, tipo, Server.MapPath("~/App_Data/actas"));
            string e = "";
            switch (tipo)
            {
                case 1:
                    e = ".doc";
                    break;
                case 2:
                    e = ".xml";
                    break;
            }
            return RedirectToAction("Download", "Secretaria", new { filename = "Acta Sesión Ordinaria - "+sesion+e, path = "~\\App_Data\\actas\\"});
            // return Content(Server.MapPath("~"));
        }
        
        [HttpGet]
        public FilePathResult Download(string filename, string path)
        {
            string contentType = "application/unknown";
            return new FilePathResult(path + filename, contentType)
            {
                FileDownloadName = filename

            };
        }

        [HttpPost]
        public ActionResult AsociarActa(HttpPostedFileBase file, string sess)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads/"), fileName);
                file.SaveAs(path);
                UberController.Instance.getControlador().asociarActa(sess, path, Path.GetFileNameWithoutExtension(file.FileName));
                // proxy.asociarActa(sesion,path,Path.GetFileNameWithoutExtension(file.FileName))
                return RedirectToAction("Despues","Secretaria", new { sesion = sess});
            }
            return Content("No time 4 validations");
        }

        [HttpGet]
        public ActionResult Acuerdo(string idPunto, string destinatario, string sesion)
        {
            PuntoAgenda p = UberController.Instance.getControlador().getPunto(int.Parse(idPunto), sesion);
            UberController.Instance.getControlador().crearAcuerdo(p, destinatario, Server.MapPath("~/App_Data/acuerdos"));


            return RedirectToAction("Download","Secretaria", new { filename = "Acuerdo Punto - " + p.Nombre + ".pdf", path = Server.MapPath("~/App_Data/acuerdos/")});
        }

    }
}