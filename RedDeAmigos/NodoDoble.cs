using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDeAmigos
{
    internal class NodoDoble
    {
        public int Dato { get; set; }
        public NodoDoble? Siguiente { get; set; }
        public NodoDoble? Anterior { get; set; }

        public NodoDoble(int dato)
        {
            Dato = dato;
            Anterior = Siguiente = null;

        }
    }
}
