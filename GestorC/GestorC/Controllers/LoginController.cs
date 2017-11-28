using GestorC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestorC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string password)
        {
            Proxy proxy = new Proxy();
            
            int n = proxy.login(correo, password);
            if (proxy.isLogueado() && n > -1)
            {
                int pc = proxy.getFachadaPC();
                int sc = proxy.getFachadaSC();
                int m =  proxy.getFachadaM();
                Session["current"] = correo;

                UberController.Instance.addUsuario(proxy);
                //return Content(UberController.Instance.getProxys().Count.ToString());

                if (n == proxy.getFachadaPC())
                {
                    return Content("PC");
                }
                else if(n == sc){

                    return RedirectToAction("Index","Secretaria");
                }
                else
                {
                    return Content("M");
                }
            }
            return RedirectToAction("Index", "Login", new { msg = "Usuario incorrecto"});
        }

        [HttpGet]
        public ActionResult Prueba1()
        {
            Proxy prox = Session["current"] as Proxy;
            return View(prox);
        }
    }
}