using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDeAmigos
{
    internal class NodoDoble
    {
        public Persona Dato { get; set; }
        public NodoDoble? Siguiente { get; set; }
        public NodoDoble? Anterior { get; set; }

        public NodoDoble(Persona dato)
        {
            Dato = dato;
            Anterior = Siguiente = null;
        }
    }
}
