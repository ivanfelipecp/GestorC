using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Controlador;
using Proyecto1.Modelo;
using System.Collections.ObjectModel;

namespace GestorC.Models
{
    public class UberController
    {
        Gestor g;
        string PCmiembro;

        public UberController()
        {
            this.g = new Gestor();
            g.cargarDatos();

            if (g.haySesion() && !Quorum.Instance.isCargado())
            {
                foreach (char c in g.getSesion().MiembrosAsistencia.ListaAsistencia)
                {
                    if (c == 'P')
                    {
                        Quorum.Instance.modificarQuorum(true);
                    }
                }
                Quorum.Instance.cargarQuorum();
            }

            PC = "aj@gmail.com";

        }

        public String PC
        {
            get
            {
                return PCmiembro;
            }

            set
            {
                PCmiembro = value;
            }
        }

        public void nuevaSesion(String num, DateTime fecha, string lugar)
        {
            g.nuevaSesion(num, fecha, lugar);
        }

        public void cerrarSesion()
        {
            g.cerrarSesion();

        }

        public void actualizarMiembros(String path)
        {
            g.actualizarMiembros(path);
        }


        public void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            g.agregarSolicitud(nombre, resultando, considerandos, seAcuerda, tipo);
        }

        public void agregarPuntoAgenda(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            g.agregarPuntoAgenda(nombre, resultando, considerandos, seAcuerda, tipo);
        }

        public void agregarComentario(int idPunto, string correoMiembro, string txt)
        {
            g.agregarComentario(idPunto, correoMiembro, txt);
        }

        public void eliminarSolicitud(int id)
        {
            g.eliminarSolicitud(id);
        }

        public void eliminarPuntoAgenda(int id)
        {
            g.eliminarPuntoAgenda(id);
        }

        public void aceptarSolicitud(int id)
        {
            g.aceptarSolicitud(id);
        }

        public void agregarVotacion(int id, int aFavor, int enContra, int blanco)
        {
            g.agregarVotacion(id, aFavor, enContra, blanco);
        }

        public void crearAgenda(string sesion, string path)
        {
            g.crearAgenda(sesion, path);
        }
        public void crearActa(int tipo, string path)
        {
            g.crearActa(tipo, path);
        }

        public void modificarAsistencia(string correoMiembro, bool estado)
        {
            g.modificarAsistencia(correoMiembro, estado);
        }

        public Collection<PuntoAgenda> getSolicitudes()
        {
            return g.getSolicitudes();
        }

        public Collection<PuntoAgenda> getPuntosAgenda()
        {
            return g.getPuntosAgenda();
        }

        public Prototype_Miembros getAsistencia()
        {
            return g.getAsistencia();
        }

        public Collection<Miembro> getMiembrosConsejo()
        {
            return g.getMiembrosConsejo();
        }

        public Collection<Comentario> getComentarios(int idPunto)
        {
            return g.getComentarios(idPunto);
        }

        public bool haySesion()
        {
            return g.haySesion();
        }

        public void cambiarPosicionPunto(int posicionNueva, int posicionVieja)
        {
            g.cambiarPosicionPunto(posicionNueva, posicionVieja);
        }

        public Collection<string> getAllNumeroSesiones()
        {
            return g.getAllNumeroSesiones();
        }

        public void enviarNotificacion(string numeroSesion, DateTime fecha, string correo, string pathMemo)
        {
            g.enviarNotificacion(numeroSesion, fecha, correo, pathMemo);
        }

        public void enviarAgenda(string numeroSesion, DateTime fecha, string correo, string agenda)
        {
            g.enviarAgenda(numeroSesion, fecha, correo, agenda);
        }

        public void obtenerAgenda(Sesion sesion, string path)
        {
            g.obtenerAgenda(sesion, path);
        }

        public void asociarActa(string numSesion, string path, string nombreArchivo)
        {
            g.asociarActa(numSesion, path, nombreArchivo);
        }

        public void obtenerActa(string numSesion, string path)
        {
            g.obtenerActa(numSesion, path);
        }

        public void asociarAdjunto(int idPunto, string path, string nombreArchivo, string extension)
        {
            g.asociarAdjunto(idPunto, path, nombreArchivo, extension);
        }

        public Collection<String> getAdjuntos(int idPunto)
        {
            return g.getAdjuntos(idPunto);
        }

        public void obtenerAdjunto(int idPunto, string nombreAdjunto, string path)
        {
            g.obtenerAdjunto(idPunto, nombreAdjunto, path);
        }

        public void crearAcuerdo(PuntoAgenda punto, string destinatario, string path)
        {
            g.crearAcuerdo(punto, destinatario, path);
        }

        public Sesion getSesion()
        {
            return g.getSesion();
        }

        public Sesion getSesion(string numero)
        {
            return g.getSesion(numero);
        }
    }
}