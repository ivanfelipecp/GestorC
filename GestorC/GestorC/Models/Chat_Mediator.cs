using System.Collections.ObjectModel;

namespace GestorC.Models
{
    class Chat_Mediator : Mediator
    {
        Collection<Usuario_Chat> usuarios = new Collection<Usuario_Chat>();

        public Chat_Mediator() { }

        public void agregarUsuario(Usuario_Chat u)
        {
            usuarios.Add(u);
        }

        public void enviarMensaje(string mensaje, string usuario)
        {
            foreach (Usuario_Chat u in usuarios)
            {
                if(u.getUsuario().Correo[0] == usuario)
                {
                    u.enviarMensaje(mensaje);
                }
                else
                {
                    u.recibirMensaje(usuario + "said: " + mensaje);
                }   
            }
        }
    }
}