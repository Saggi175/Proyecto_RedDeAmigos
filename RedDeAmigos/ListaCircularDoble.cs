using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDeAmigos
{
    internal class ListaCircularDoble
    {
        private NodoDoble _primero;
        private NodoDoble _ultimo;
        private int cantidadDePersonas;

        public ListaCircularDoble()
        {
            _primero = _ultimo = null;
            cantidadDePersonas = 0;
        }
        public bool EsVacia()
        {
            return _primero == null;
        }
        public void AgregarPorCabeza(int valor)
        {
            NodoDoble nuevoNodo = new NodoDoble(valor);
            if (EsVacia())
            {
                _primero = _ultimo = nuevoNodo;
                _primero.Siguiente = _ultimo;
                _primero.Anterior = _ultimo;
                _ultimo.Siguiente = _primero;
                _ultimo.Anterior = _primero;
            }
            else
            {
                nuevoNodo.Siguiente = _primero;
                nuevoNodo.Anterior = _primero.Anterior;
                _primero.Anterior = nuevoNodo;
                _primero = nuevoNodo;
                _ultimo.Siguiente = nuevoNodo;
            }

            cantidadDePersonas++;

        }
        public void AgregarPorCola(int valor)
        {
            NodoDoble nuevoNodo = new NodoDoble(valor);
            if (EsVacia())
            {
                _primero = _ultimo = nuevoNodo;
                _primero.Siguiente = _ultimo;
                _primero.Anterior = _ultimo;
                _ultimo.Siguiente = _primero;
                _ultimo.Anterior = _primero;
            }
            else
            {
                nuevoNodo.Anterior = _ultimo;
                nuevoNodo.Siguiente = _ultimo.Siguiente;
                _ultimo.Siguiente = nuevoNodo;
                _ultimo = nuevoNodo;
                _primero.Anterior = _ultimo;
            }

            cantidadDePersonas++;

        }
        public void Imprimir()
        {
            NodoDoble auxiliar = _primero;
            if (!EsVacia())
            {
                do
                {
                    Console.Write(auxiliar.Dato + " -> ");
                    auxiliar = auxiliar.Siguiente;
                }
                while (auxiliar != _primero);
                Console.WriteLine("Null");
            }
        }
        public void ImprimirReversa()
        {
            NodoDoble auxiliar = _ultimo;
            if (!EsVacia())
            {
                do
                {
                    Console.Write(auxiliar.Dato + " -> ");
                    auxiliar = auxiliar.Anterior;
                }
                while (auxiliar != _ultimo);
                Console.WriteLine("Null");
            }
        }
        public void AgregarOrdenado(int valor)
        {
            NodoDoble nuevoNodo = new NodoDoble(valor);

            if (EsVacia())
            {
                _primero = _ultimo = nuevoNodo;
                nuevoNodo.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = nuevoNodo;
            }
            else
            {
                if (nuevoNodo.Dato < _primero.Dato)
                {
                    nuevoNodo.Siguiente = _primero;
                    nuevoNodo.Anterior = _ultimo;
                    _primero.Anterior = nuevoNodo;
                    _primero = nuevoNodo;
                    _ultimo.Siguiente = nuevoNodo;
                }
                else
                {
                    NodoDoble auxiliar = _primero;

                    while (auxiliar.Siguiente != _primero && nuevoNodo.Dato >= auxiliar.Siguiente.Dato)
                    {
                        auxiliar = auxiliar.Siguiente;
                    }

                    nuevoNodo.Siguiente = auxiliar.Siguiente;
                    nuevoNodo.Anterior = auxiliar;
                    auxiliar.Siguiente = nuevoNodo;
                    nuevoNodo.Siguiente.Anterior = nuevoNodo;
                    if (nuevoNodo.Siguiente == _primero)
                    {
                        _ultimo = nuevoNodo;
                    }
                }
            }

            cantidadDePersonas++;

        }
        public void EliminarPorValor(int valor)
        {
            if (EsVacia())
            {
                throw new Exception("La lista esta vacia");
            }
            else if (_primero.Dato == valor)
            {
                NodoDoble tmp = _primero;
                tmp.Anterior.Siguiente = tmp.Siguiente;
                tmp.Siguiente.Anterior = tmp.Anterior;
                _primero = tmp.Siguiente;
                _primero.Anterior = null;
                tmp.Siguiente = null;
                tmp.Anterior = null;
                tmp.Dato = 0;
                cantidadDePersonas--;
                return;



                //_primero = _primero.Siguiente;
                //_primero.Anterior = _ultimo;
                //_ultimo.Siguiente = _primero;

            }
            else
            {
                NodoDoble auxiliar = _primero;
                while (auxiliar.Siguiente != _primero && valor >= auxiliar.Siguiente.Dato)
                {
                    auxiliar = auxiliar.Siguiente;
                }

                NodoDoble tmp = auxiliar.Siguiente;
                tmp.Siguiente.Anterior = tmp;
                auxiliar.Siguiente = tmp.Siguiente;
                cantidadDePersonas--;

                if (tmp.Siguiente != null)
                    tmp.Siguiente.Anterior = auxiliar;

                tmp.Siguiente = null;
                tmp.Anterior = null;
                tmp.Dato = 0;

                if (auxiliar.Siguiente == _primero)
                    _ultimo = auxiliar;

            }
        }
        public void EliminarPorPosicion(int posicion)
        {
            if (EsVacia())
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            if (posicion == 0)
            {
                _primero.Siguiente.Anterior = _primero.Anterior;
                _primero.Anterior.Siguiente = _primero.Siguiente;
                _primero = _primero.Siguiente;
                cantidadDePersonas--;


                if (_primero == null)
                {
                    _ultimo = null;
                }
            }
            else
            {
                NodoDoble aux = _primero;
                int contador = 0;

                while (aux != null && contador < posicion - 1)
                {
                    aux = aux.Siguiente;
                    contador++;
                }

                if (aux != null && aux.Siguiente != null)
                {

                    aux.Siguiente = aux.Siguiente.Siguiente;
                    aux.Siguiente.Anterior = aux;

                    if (aux.Siguiente == null)
                    {
                        _ultimo = aux;
                    }
                }

                cantidadDePersonas--;

            }
        }
        public void AgregarEnPosicion(int n, int posicion)
        {
            NodoDoble nuevoNodo = new NodoDoble(n);

            if (posicion == 0)
            {
                if (EsVacia())
                {
                    _primero = _ultimo = nuevoNodo;
                }
                else
                {
                    nuevoNodo.Siguiente = _primero;
                    nuevoNodo.Anterior = _primero.Anterior;
                    _primero.Anterior.Siguiente = nuevoNodo;
                    _primero.Anterior = nuevoNodo;
                    _primero = nuevoNodo;

                }

            }
            else
            {
                NodoDoble aux = _primero;
                int contador = 0;

                while (aux != null && contador < posicion - 1)
                {
                    aux = aux.Siguiente;
                    contador++;
                }

                if (aux != null)
                {
                    nuevoNodo.Siguiente = aux.Siguiente;
                    aux.Siguiente = nuevoNodo;

                    if (aux == _ultimo)
                    {
                        _ultimo = nuevoNodo;
                    }
                }
            }

            cantidadDePersonas++;

        }
        public int CantidadDePersonas()
        {
            return cantidadDePersonas;
        }
    }
}
