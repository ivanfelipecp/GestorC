using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Controlador;
using Proyecto1.Modelo;
using System.Collections.ObjectModel;

namespace GestorC.Models
{
    public class UberController : Subject_Observer
    {
        private static UberController instance;
        private static int cantQuorum;
        private Collection<Observer> observers = new Collection<Observer>();
        private static bool cargado;
        private static ControladorProyecto1 controlador;

        private UberController() { }

        public static UberController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UberController();
                    cantQuorum = 0;
                    cargado = false;
                    controlador = new ControladorProyecto1();
                }
                return instance;
            }
        }

        public ControladorProyecto1 getControlador()
        {
            return controlador;
        }

        public int getQuorum()
        {
            return cantQuorum;
        }

        public void modificarQuorum(bool accion)
        {
            if (accion)
            {
                cantQuorum++;
            }
            else
            {
                cantQuorum--;
            }

            notificarObservadores();
        }

        public void cargarQuorum()
        {
            cargado = true;
        }

        public bool isCargado()
        {
            return cargado;
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
    }
}