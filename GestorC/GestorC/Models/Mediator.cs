using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorC.Models
{
    public interface Mediator
    {
        void agregarUsuario(Usuario_Chat u);

        void enviarMensaje(string mensaje, string usuario);
    }
}