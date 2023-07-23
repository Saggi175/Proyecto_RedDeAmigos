using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDeAmigos
{
     class ListaCircularDoble
    {
        private NodoDoble _primero;
        private NodoDoble _ultimo;
        public int CantidadDePersonas { get; set;  }

        public NodoDoble getUltimo()
        {
            return _ultimo;
        }
        public NodoDoble getPrimero()
        {
            return _primero;
        }
        public ListaCircularDoble()
        {
            _primero = _ultimo = null;
            CantidadDePersonas = 0;
        }

        public bool EsVacia()
        {
            return _primero == null;
        }

        public void AgregarPorCabeza(Persona valor)
        {
            NodoDoble nuevoNodo = new NodoDoble(valor);

            bool esRepetido = Buscar(valor.Email) != null;

            if(!esRepetido)
            {
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
                CantidadDePersonas++;
            }
            else
            {
                Console.WriteLine($"El correo ({valor.Email}) ya se encuentra registrado ");
            }
        }

        public void AgregarPorCola(Persona valor)
        {
            bool esRepetido = Buscar(valor.Email) != null;

           if(!esRepetido)
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
                CantidadDePersonas++;
            }
           else
            {
                Console.WriteLine($"El correo ({valor.Email}) ya se encuentra registrado ");
            }
        }

        public void Imprimir()
        {
            NodoDoble auxiliar = _primero;
            if (!EsVacia())
            {
                do
                {
                    Console.WriteLine(auxiliar.Dato.Email);
                    auxiliar = auxiliar.Siguiente;
                }
                while (auxiliar != _primero);
            }
        }

        public void ImprimirReversa()
        {
            NodoDoble auxiliar = _ultimo;
            if (!EsVacia())
            {
                do
                {
                    Console.WriteLine(auxiliar.Dato.Email);
                    auxiliar = auxiliar.Anterior;
                }
                while (auxiliar != _ultimo);
            }
        }

        public void AgregarOrdenado(Persona valor)
        {
            NodoDoble nuevoNodo = new NodoDoble(valor);

            bool esRepetido = Buscar(valor.Email) != null;

            if (!esRepetido)
            {
                if (EsVacia())
                {
                    _primero = _ultimo = nuevoNodo;
                    nuevoNodo.Siguiente = nuevoNodo;
                    nuevoNodo.Anterior = nuevoNodo;
                }
                else
                {
                    if (nuevoNodo.Dato.Nombre.CompareTo(_primero.Dato.Nombre) < 0)
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

                        while (auxiliar.Siguiente != _primero && nuevoNodo.Dato.Nombre.CompareTo(auxiliar.Dato.Nombre) >= 0)
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
                CantidadDePersonas++;
            }
            else
            {
                Console.WriteLine($"El correo ({valor.Email}) ya se encuentra registrado ");
            }
        }

        public void EliminarPorValor(string email)
        {
            if (EsVacia())
            {
                throw new Exception("La lista esta vacia");
            }
            else if (_primero.Dato.Email == email)
            {
                NodoDoble tmp = _primero;
                tmp.Anterior.Siguiente = tmp.Siguiente;
                tmp.Siguiente.Anterior = tmp.Anterior;
                _primero = tmp.Siguiente;
                _primero.Anterior = null;
                tmp.Siguiente = null;
                tmp.Anterior = null;
                tmp.Dato = null;
                CantidadDePersonas--;
                return;

                //_primero = _primero.Siguiente;
                //_primero.Anterior = _ultimo;
                //_ultimo.Siguiente = _primero;
            }
            else
            {
                NodoDoble auxiliar = _primero;
                while (auxiliar.Siguiente != _primero && email.CompareTo(auxiliar.Siguiente.Dato.Email) != 0 )
                {
                    auxiliar = auxiliar.Siguiente;
                }

                NodoDoble tmp = auxiliar.Siguiente;
                tmp.Siguiente.Anterior = tmp;
                auxiliar.Siguiente = tmp.Siguiente;
                CantidadDePersonas--;

                if (tmp.Siguiente != null)
                    tmp.Siguiente.Anterior = auxiliar;

                tmp.Siguiente = null;
                tmp.Anterior = null;
                tmp.Dato = null;

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
                CantidadDePersonas--;

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
                CantidadDePersonas--;
            }
        }

        public void AgregarEnPosicion(Persona valor, int posicion)
        {
            NodoDoble nuevoNodo = new NodoDoble(valor);

            bool esRepetido = Buscar(valor.Email) != null;

            if (!esRepetido)
            {
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
                CantidadDePersonas++;
            }
            else
            {
                Console.WriteLine($"El correo ({valor.Email}) ya se encuentra registrado ");
            }
        }

        public Persona Buscar(string valor)
        {
            if(_primero != null)
            {

                NodoDoble actual = _primero;
                do
                {
                    if (actual.Dato.Email.ToString() == valor)
                    {
                        return actual.Dato;
                    }
                    actual = actual.Siguiente;
                }
                while (actual != _primero);
            }
            return null;
        }
        public void ImprimirAmigosEnComun()
        {
            Console.WriteLine("Personas que comparten amistad:");

            NodoDoble actual = _primero;

            do
            {
                Nodo amigoActual = actual.Dato.amigos.RetornarNodo();

                while (amigoActual != null)
                {
                    if (amigoActual.Dato.amigos.BuscarPorEmail(actual.Dato.Email) != null)
                    {
                        Console.WriteLine($"{actual.Dato.Nombre} - {amigoActual.Dato.Nombre} comparten amistad");
                    }
                    amigoActual = amigoActual.Siguiente;
                }
                actual = actual.Siguiente;

                //if (actual == _primero) // Evitar bucle infinito en una lista circular
                //{
                //    break;
                //}

            } while (actual != _primero) ;
        }
    }
}
