using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GestorC.Models
{
    interface Usuario_Chat
    {
        void enviarMensaje(string mensaje);

        void recibirMensaje(string mensaje);

        void setMediator(Mediator m);

        string getUsuario();
    }
}