using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GestorC.Models
{
    interface Subject_Observer
    {
        void registrarObserver(Observer o);

        void eliminarObserver(Observer o);

        void notificarObservadores();
    }
}
