﻿using System;
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
        private static Collection<Observer> observers;
        private static bool cargado;
        private static Chat_Mediator chat;
        private static ControladorProyecto1 controlador;
        private static Collection<Proxy> proxys;

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
                    observers = new Collection<Observer>();
                    chat = new Chat_Mediator();
                    proxys = new Collection<Proxy>();
                }
                return instance;
            }
        }

        public void setQuorum(int n)
        {
            cantQuorum += n;
        }

        public void addUsuario(Proxy prox)
        {
            chat.agregarUsuario(prox);
            observers.Add(prox);
            proxys.Add(prox);
        }

        public Proxy getProxy(string correo)
        {
            foreach(Proxy p in proxys)
            {
                if(p.getUsuario().Correo[0] == correo)
                {
                    return p;
                }
            }
            return null;
        }

        public Collection<Proxy> getProxys()
        {
            return proxys;
        }

        public Chat_Mediator getChat()
        {
            return chat;
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