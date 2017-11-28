using GestorC.Models;
using GestorC.ViewModels;
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
        public ActionResult PrevioAgenda()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PrevioAgenda(string encabezado, string cuerpo)
        {
            // aqui se hace algo con encabezado y cuerpo, luego se envia al otro view

            return RedirectToAction("");
        }

        [HttpGet]
        public ActionResult PrevioNotificar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PrevioNotificar(string cuerpo, string encabezado, HttpPostedFileBase file1)
        {
            /* if (file1 != null)
            {
                var fileName = Path.GetFileName(file1.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads/"), fileName);
                file1.SaveAs(path);
                return Content(file1.ToString());
            } */
            
            return Content(cuerpo +"-"+ encabezado + "-" + "file");
        }

        [HttpGet]
        public ActionResult PrevioCrear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PrevioCrear(int numero, string lugar, DateTime fecha)
        {
            return Content(numero + lugar + fecha.ToString());
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
            // getiamos la sesion
            //return Content(sesion);

            return View();
        }

        [HttpPost] // acta
        public ActionResult Descargar(string sesion, int tipo)
        {
            // Con sesion tenemos el número
            // proxy(sesion,tipo,Server.MapPath("~")+"\\App_Data\\actas")
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
        public ActionResult AsociarActa(string sesion, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads/"), fileName);
                file.SaveAs(path);
                // proxy.asociarActa(sesion,path,Path.GetFileNameWithoutExtension(file.FileName))
                return Content(path);
            }
            return Content("es nulo");
        }

    }
}