using GestorC.Models;
using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorC.ViewModels
{
    public class VM_Secretaria
    {
        public Proxy proxy { get; set; }
        public Sesion sesionSeleccionada { get; set; }


        public UberController GetUberController()
        {
            return UberController.Instance;
        }
    }
}