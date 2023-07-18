using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDeAmigos
{
    internal class Nodo
    {
        public Persona Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Persona dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}
