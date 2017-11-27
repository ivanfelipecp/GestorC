using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Controlador;
using Proyecto1.Modelo;
using System.Collections.ObjectModel;

namespace GestorC.Models
{
    class Proxy : Observer, Subject_Proxy, Usuario_Chat
    {
        Subject_Proxy fachada;
        const int fachadaM = 0;
        const int fachadaSC = 1;
        const int fachadaPC = 2;

        string usuario;
        bool logueado = false;

        ControladorProyecto1 controller;

        Mediator mediatorChat;

        public Proxy(string usuario, string contrasena)
        {
            controller = UberController.Instance.getControlador();

            bool resultado = login(usuario, contrasena);

            if (resultado)
            {
                logueado = true;
                this.usuario = usuario;
            }
            else
            {
                fachada = null;
                logueado = false;
            }

        }

        public bool login(string usuario, string contrasena)
        {
            if (usuario == contrasena)
            {
                if (usuario == "sc")
                {
                    setFachada(fachadaSC);
                    Console.WriteLine("SC conectado/a...");
                    return true;
                }
                else
                {
                    foreach (Miembro m in controller.getMiembrosConsejo())
                    {
                        if (m.Correo.Contains(usuario))
                        {
                            Console.WriteLine(usuario + " / " + controller.PC);
                            if (usuario == controller.PC)
                            {
                                setFachada(fachadaPC);
                                Console.WriteLine("PC conectado/a...");
                            }
                            else
                            {
                                setFachada(fachadaM);
                                Console.WriteLine("Miembro conectado/a...");
                            }

                            return true;

                        }
                    }
                }

            }

            return false;
        }

        public void setFachada(int tipo)
        {
            switch (tipo)
            {
                case fachadaM:
                    fachada = new Facade_M();
                    break;

                case fachadaSC:
                    fachada = new Facade_SC();
                    break;

                case fachadaPC:
                    fachada = new Facade_PC();
                    break;
            }
        }


        public void aceptarSolicitud(int id)
        {
            fachada.aceptarSolicitud(id);
        }

        public void actualizarMiembros(string path)
        {
            fachada.actualizarMiembros(path);
        }

        public void agregarComentario(int idPunto, string correoMiembro, string txt)
        {
            fachada.agregarComentario(idPunto, correoMiembro, txt);
        }

        public void agregarPuntoAgenda(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            fachada.agregarPuntoAgenda(nombre, resultando, considerandos, seAcuerda, tipo);
        }

        public void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            fachada.agregarSolicitud(nombre, resultando, considerandos, seAcuerda, tipo);
        }

        public void agregarVotacion(int id, int aFavor, int enContra, int blanco)
        {
            fachada.agregarVotacion(id, aFavor, enContra, blanco);
        }

        public void asociarActa(string numSesion, string path, string nombreArchivo)
        {
            fachada.asociarActa(numSesion, path, nombreArchivo);
        }

        public void asociarAdjunto(int idPunto, string path, string nombreArchivo, string extension)
        {
            fachada.asociarAdjunto(idPunto, path, nombreArchivo, extension);
        }

        public void cambiarPosicionPunto(int posicionNueva, int posicionVieja)
        {
            fachada.cambiarPosicionPunto(posicionNueva, posicionVieja);
        }

        public void cerrarSesion()
        {
            fachada.cerrarSesion();
        }

        public void crearActa(string numSesion, int tipo, string path)
        {
            fachada.crearActa(numSesion, tipo, path);
        }

        public void crearAcuerdo(PuntoAgenda punto, string destinatario, string path)
        {
            fachada.crearAcuerdo(punto, destinatario, path);
        }

        public void crearAgenda(string sesion, string path)
        {
            fachada.crearAgenda(sesion, path);
        }

        public void eliminarPuntoAgenda(int id)
        {
            fachada.eliminarPuntoAgenda(id);
        }

        public void modificarAsistencia(string correoMiembro, bool estado)
        {
            fachada.modificarAsistencia(correoMiembro, estado);
        }

        public Collection<PuntoAgenda> getSolicitudes()
        {
            return fachada.getSolicitudes();
        }

        public Collection<PuntoAgenda> getPuntosAgenda()
        {
            return fachada.getPuntosAgenda();
        }

        public Prototype_Miembros getAsistencia()
        {
            return fachada.getAsistencia();
        }

        public Collection<Miembro> getMiembrosConsejo()
        {
            return fachada.getMiembrosConsejo();
        }

        public Collection<Comentario> getComentarios(int idPunto)
        {
            return fachada.getComentarios(idPunto);
        }

        public bool haySesion()
        {
            return fachada.haySesion();
        }

        public Collection<string> getAllNumeroSesiones()
        {
            return fachada.getAllNumeroSesiones();
        }

        public void enviarNotificacion(string numeroSesion, DateTime fecha, string correo, string pathMemo)
        {
            fachada.enviarNotificacion(numeroSesion, fecha, correo, pathMemo);
        }

        public void enviarAgenda(string numeroSesion, DateTime fecha, string correo, string agenda)
        {
            fachada.enviarAgenda(numeroSesion, fecha, correo, agenda);
        }

        public void obtenerAgenda(Sesion sesion, string path)
        {
            fachada.obtenerAgenda(sesion, path);
        }

        public void obtenerActa(string numSesion, string path)
        {
            fachada.obtenerActa(numSesion, path);
        }

        public Collection<String> getAdjuntos(int idPunto)
        {
            return fachada.getAdjuntos(idPunto);
        }

        public void obtenerAdjunto(int idPunto, string nombreAdjunto, string path)
        {
            fachada.obtenerAdjunto(idPunto, nombreAdjunto, path);
        }

        public Sesion getSesion()
        {
            return fachada.getSesion();
        }

        public Sesion getSesion(string numero)
        {
            return fachada.getSesion(numero);
        }

        public void notificarCambioQuorum()
        {
            Console.WriteLine(UberController.Instance.getQuorum());
        }

        public void nuevaSesion(string num, DateTime fecha, string lugar)
        {
            fachada.nuevaSesion(num, fecha, lugar);
        }

        public void eliminarSolicitud(int id)
        {
            fachada.eliminarSolicitud(id);
        }

        public void enviarMensaje(string mensaje)
        {
            mediatorChat.enviarMensaje(mensaje, this.usuario);
        }

        public void recibirMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public void setMediator(Mediator m)
        {
            mediatorChat = m;
        }

        public string getUsuario()
        {
            return usuario;
        }
    }
}