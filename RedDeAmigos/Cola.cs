using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDeAmigos
{
    internal class Cola
    {
        private Nodo cima;
        private Nodo _ultimo;

        public Cola()
        {
            cima = _ultimo = null;
        }

        public bool EsVacia()
        {
            return cima == null;
        }

        public void Push(Persona valor)
        {
            Nodo nuevoNodo = new Nodo(valor);

            if (EsVacia())
            {
                cima = _ultimo = nuevoNodo;
            }
            else
            {
                _ultimo.Siguiente = nuevoNodo;
                _ultimo = nuevoNodo;
            }
        }

        public Nodo Pop()
        {
            Nodo auxiliar = cima;

            if (EsVacia())
            {
                throw new Exception("La cola esta vacia");
            }
            else
            {
                cima = cima.Siguiente;
                auxiliar.Siguiente = null;

                return auxiliar;
            }
        }

        public Nodo PeekNodo()
        {
            Nodo nuevoNodo = new Nodo(cima.Dato);

            if (EsVacia())
                return null;

            return nuevoNodo;
        }

        //public int PeeKValor()
        //{
        //    if (EsVacia())
        //        return -1;

        //    return cima.Dato;
        //}

        public void Imprimir()
        {
            Nodo auxiliar = cima;

            while (auxiliar != null)
            {
                Console.Write(auxiliar.Dato + " -> ");
                auxiliar = auxiliar.Siguiente;
            }
            Console.WriteLine("Null");
        }
    }
}
