using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Modelo;
using Proyecto1.Controlador;
using System.Collections.ObjectModel;

namespace GestorC.Models
{
    public class Facade_SC : Subject_Observer, Subject_Proxy
    {
        ControladorProyecto1 controller;

        Collection<Observer> observers = new Collection<Observer>();

        public Facade_SC()
        {
            controller = UberController.Instance.getControlador();
        }

        public void acceso_Secretaria()
        {
            Console.WriteLine("acceso al dashboard de dorita");
        }

        public void log_out()
        {
            Console.WriteLine("Log out");
        }

        public void nuevaSesion(String num, DateTime fecha, string lugar)
        {
            controller.nuevaSesion(num, fecha, lugar);
        }

        public void cerrarSesion()
        {
            controller.cerrarSesion();

        }

        public void actualizarMiembros(String path)
        {
            controller.actualizarMiembros(path);
        }

        public void agregarComentario(int idPunto, string correoMiembro, string txt)
        {
            controller.agregarComentario(idPunto, correoMiembro, txt);
        }

        public void agregarVotacion(int id, int aFavor, int enContra, int blanco)
        {
            controller.agregarVotacion(id, aFavor, enContra, blanco);
        }

        public void crearAgenda(string sesion, string path)
        {
            controller.crearAgenda(sesion, path);
        }
        public void crearActa(string numSesion, int tipo, string path)
        {
            controller.crearActa(numSesion, tipo, path);
        }

        public void modificarAsistencia(string correoMiembro, bool estado)
        {
            controller.modificarAsistencia(correoMiembro, estado);
            UberController.Instance.modificarQuorum(estado);
        }

        public void enviarNotificacion(string numeroSesion, DateTime fecha, string correo, string pathMemo)
        {
            controller.enviarNotificacion(numeroSesion, fecha, correo, pathMemo);
        }

        public void enviarAgenda(string numeroSesion, DateTime fecha, string correo, string agenda)
        {
            controller.enviarAgenda(numeroSesion, fecha, correo, agenda);
        }

        public void obtenerAgenda(Sesion sesion, string path)
        {
            controller.obtenerAgenda(sesion, path);
        }

        public void asociarActa(string numSesion, string path, string nombreArchivo)
        {
            controller.asociarActa(numSesion, path, nombreArchivo);
        }

        public void obtenerActa(string numSesion, string path)
        {
            controller.obtenerActa(numSesion, path);
        }

        public void crearAcuerdo(PuntoAgenda punto, string destinatario, string path)
        {
            controller.crearAcuerdo(punto, destinatario, path);
        }

        public void registrarObserver(Observer o)
        {
            observers.Add(o);
        }

        public void eliminarObserver(Observer o)
        {
            observers.Remove(o);
        }

        public void notificarObservadores()
        {
            if (observers.Any())
            {
                foreach (Observer o in observers)
                {
                    o.notificarCambioQuorum();
                }
            }
        }

        public void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            throw new NotImplementedException();
        }

        public void agregarPuntoAgenda(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            throw new NotImplementedException();
        }

        public void eliminarSolicitud(int id)
        {
            throw new NotImplementedException();
        }

        public void eliminarPuntoAgenda(int id)
        {
            throw new NotImplementedException();
        }

        public void aceptarSolicitud(int id)
        {
            throw new NotImplementedException();
        }

        public Collection<PuntoAgenda> getSolicitudes()
        {
            throw new NotImplementedException();
        }

        public Collection<PuntoAgenda> getPuntosAgenda()
        {
            throw new NotImplementedException();
        }

        public Prototype_Miembros getAsistencia()
        {
            throw new NotImplementedException();
        }

        public Collection<Miembro> getMiembrosConsejo()
        {
            throw new NotImplementedException();
        }

        public Collection<Comentario> getComentarios(int idPunto)
        {
            throw new NotImplementedException();
        }

        public bool haySesion()
        {
            throw new NotImplementedException();
        }

        public void cambiarPosicionPunto(int posicionNueva, int posicionVieja)
        {
            throw new NotImplementedException();
        }

        public Collection<string> getAllNumeroSesiones()
        {
            throw new NotImplementedException();
        }

        public void asociarAdjunto(int idPunto, string path, string nombreArchivo, string extension)
        {
            throw new NotImplementedException();
        }

        public Collection<string> getAdjuntos(int idPunto)
        {
            throw new NotImplementedException();
        }

        public void obtenerAdjunto(int idPunto, string nombreAdjunto, string path)
        {
            throw new NotImplementedException();
        }

        public Sesion getSesion()
        {
            throw new NotImplementedException();
        }

        public Sesion getSesion(string numero)
        {
            throw new NotImplementedException();
        }

        public void iniciarSesion(string sesion)
        {
            throw new NotImplementedException();
        }
    }
}