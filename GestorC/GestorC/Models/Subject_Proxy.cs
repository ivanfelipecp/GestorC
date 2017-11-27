using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Modelo;
using Proyecto1.Controlador;
using System.Collections.ObjectModel;

namespace GestorC.Models
{
    public interface Subject_Proxy
    {
        void nuevaSesion(String num, DateTime fecha, string lugar);

        void cerrarSesion();

        void actualizarMiembros(String path);


        void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, char tipo);

        void agregarPuntoAgenda(string nombre, string resultando, string considerandos, string seAcuerda, char tipo);

        void agregarComentario(int idPunto, string correoMiembro, string txt);

        void eliminarSolicitud(int id);

        void eliminarPuntoAgenda(int id);

        void aceptarSolicitud(int id);

        void agregarVotacion(int id, int aFavor, int enContra, int blanco);

        void crearAgenda(string sesion, string path);

        void crearActa(int tipo, string path);

        void modificarAsistencia(string correoMiembro, bool estado);

        Collection<PuntoAgenda> getSolicitudes();

        Collection<PuntoAgenda> getPuntosAgenda();

        Prototype_Miembros getAsistencia();

        Collection<Miembro> getMiembrosConsejo();

        Collection<Comentario> getComentarios(int idPunto);

        bool haySesion();

        void cambiarPosicionPunto(int posicionNueva, int posicionVieja);

        Collection<string> getAllNumeroSesiones();

        void enviarNotificacion(string numeroSesion, DateTime fecha, string correo, string pathMemo);

        void enviarAgenda(string numeroSesion, DateTime fecha, string correo, string agenda);

        void obtenerAgenda(Sesion sesion, string path);

        void asociarActa(string numSesion, string path, string nombreArchivo);

        void obtenerActa(string numSesion, string path);

        void asociarAdjunto(int idPunto, string path, string nombreArchivo, string extension);

        Collection<String> getAdjuntos(int idPunto);

        void obtenerAdjunto(int idPunto, string nombreAdjunto, string path);

        void crearAcuerdo(PuntoAgenda punto, string destinatario, string path);

        Sesion getSesion();

        Sesion getSesion(string numero);



        //private Facade_M miembro_C;
        //private Facade_PC presidente_C;
        //private Facade_SC secretaria_C;

        //int acceso = 0;
        //public Subject_Proxy()
        //{
        //    miembro_C = new Facade_M();
        //    presidente_C = new Facade_PC();
        //    secretaria_C = new Facade_SC();
        //}


        //public int Acceso
        //{
        //    get
        //    {
        //        return acceso;
        //    }

        //    set
        //    {
        //        acceso = value;
        //        Acceso_Consejo();
        //    }
        //}

        //private void Acceso_Consejo()
        //{
        //    switch (acceso)
        //    {
        //        case 0:
        //            Console.WriteLine("sesion de miembros");
        //            miembro_C.acceso_Miembro();
        //            break;
        //        case 1:
        //            Console.WriteLine("sesion de presidente");
        //            presidente_C.acceso_Presidente();
        //            break;
        //        case 2:
        //            Console.WriteLine("sesion de secretaria");
        //            secretaria_C.acceso_Secretaria();
        //            break;
        //        default:
        //            break;
        //    }

        //}
    }
}