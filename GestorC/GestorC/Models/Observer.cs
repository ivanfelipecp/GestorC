using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorC.Models
{
    public interface Observer
    {
        void notificarCambioQuorum();
    }
}