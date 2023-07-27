using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDeAmigos
{
    internal class NodoArbol
    {
        private Persona dato;
        private NodoArbol _primerHijo;
        private NodoArbol _ultimoHijo;
        public NodoArbol Siguiente;

        public NodoArbol(Persona valor)
        {
            dato = valor;
            Siguiente = _primerHijo = _ultimoHijo = null;

        }

        public NodoArbol(Persona valor, NodoArbol primogenito)
        {
            dato = valor;
            _primerHijo = primogenito;
            _ultimoHijo = primogenito;
            Siguiente = null;
        }

        public Persona ValorNodo() { return dato; }

        public NodoArbol Primogenito() { return _primerHijo; }

        public void Visitar(int nivel)
        {
            string indentacion = new string(' ', nivel * 4);
            Console.WriteLine(indentacion + "└─ " + dato.Nombre + " " + dato.Apellido);

            if (_primerHijo != null)
            {
                NodoArbol hijoActual = _primerHijo;
                while (hijoActual != null)
                {
                    hijoActual.Visitar(nivel + 1);
                    hijoActual = hijoActual.Siguiente;
                }
            }
        }

        public void NuevoValor(Persona d) { dato = d; }

        public void AgregarHijo(NodoArbol nuevoHijo)
        {
            if (_primerHijo == null)
            {
                _primerHijo = _ultimoHijo = nuevoHijo;
            }
            else
            {
                _ultimoHijo.Siguiente = nuevoHijo;
                _ultimoHijo = nuevoHijo;
            }
        }

        protected void VisitarHijos()
        {
            if (_primerHijo == null)
                return;

            NodoArbol aux = _primerHijo;
            while (aux != null)
            {
                aux.Visitar(0);
                aux = aux.Siguiente;
            }
        }
    }
}
