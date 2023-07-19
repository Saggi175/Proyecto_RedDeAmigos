using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDeAmigos
{
    internal class ListaSimple
    {
        private Nodo _primero;
        private Nodo _ultimo;
        private int cantidadDeAmigos;
        public ListaSimple()
        {
            _primero = _ultimo = null;
            cantidadDeAmigos = 0;
        }
        public bool EsVacia()
        {
            return _primero == null;
        }
        public void AgregarPorCabeza(Persona valor)
        {
            Nodo nuevoNodo = new Nodo(valor);

            if (EsVacia())
            {
                _primero = _ultimo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = _primero;
                _primero = nuevoNodo;
            }
            cantidadDeAmigos++;
        }
        public void AgregarPorCola(Persona valor)
        {
            bool correoRepetido = BuscarPorTelefono(valor.Email) != null;

            if (!correoRepetido)
            {
                Nodo nuevoNodo = new Nodo(valor);
                if (EsVacia())
                {
                    _primero = _ultimo = nuevoNodo;
                }
                else
                {
                    _ultimo.Siguiente = nuevoNodo;
                    _ultimo = nuevoNodo;
                }
                cantidadDeAmigos++;
            }
            else
            {
                Console.WriteLine("\nEste correo ya esta registrado");
            }

            

        }
        public void Imprimir()
        {
            Nodo auxliar = _primero;
            while (auxliar != null)
            {
                Console.Write(auxliar.Dato + " -> ");
                auxliar = auxliar.Siguiente;
            }
            Console.WriteLine("Null");

        }
        public void EliminarPorValor(string email)//Creo que debo cambiar este tipo persona por un estrin que representa un email o numero de telefono.
        {
            Nodo auxiliar = _primero;
            if (EsVacia())
                return;

            if (auxiliar.Dato.Email == email)
            {
                Nodo tmp = _primero;
                _primero = tmp.Siguiente;
                tmp.Siguiente = null;
                tmp.Dato = null;
                cantidadDeAmigos--;

            }
            else
            {
                while (auxiliar != null)
                {
                    if (auxiliar.Siguiente != null && auxiliar.Siguiente.Dato.Email == email)
                    {
                        Nodo tmp = auxiliar.Siguiente;

                        auxiliar.Siguiente = tmp.Siguiente;
                        tmp.Dato = null;
                        tmp.Siguiente = null;

                        if (auxiliar == _ultimo)
                            _ultimo = auxiliar;

                        cantidadDeAmigos--;

                        return;

                    }
                    auxiliar = auxiliar.Siguiente;
                }

            }


        }
        public void AgregarPorPosicin(int posicion, Persona valor)
        {
            Nodo nuevoNodo = new Nodo(valor);

            if (posicion == 0)
            {
                nuevoNodo.Siguiente = _primero;
                _primero = nuevoNodo;
            }
            else
            {
                Nodo actual = _primero;
                int contador = 0;

                while (actual != null && contador < posicion - 1)
                {
                    actual = actual.Siguiente;
                    contador++;
                }

                if (actual != null)
                {
                    nuevoNodo.Siguiente = actual.Siguiente;
                    actual.Siguiente = nuevoNodo;

                    if (actual.Siguiente == _ultimo)
                    {
                        _ultimo = nuevoNodo;
                    }
                }
            }
            cantidadDeAmigos++;

        }
        public void AgregarOrdenado(Persona valor)
        {
            Nodo nuevoNodo = new Nodo(valor);

            if (EsVacia())
            {
                _primero = _ultimo = nuevoNodo;
            }
            else
            {
                if (nuevoNodo.Dato.Nombre.CompareTo(_primero.Dato.Nombre) < 0)
                {
                    nuevoNodo.Siguiente = _primero;
                    _primero = nuevoNodo;
                }
                else
                {
                    Nodo auxiliar = _primero;
                    while (auxiliar.Siguiente != null && nuevoNodo.Dato.Nombre.CompareTo(auxiliar.Dato.Nombre) <= 0)
                    {
                        auxiliar = auxiliar.Siguiente;
                    }

                    nuevoNodo.Siguiente = auxiliar.Siguiente;
                    auxiliar.Siguiente = nuevoNodo;

                    if (nuevoNodo.Siguiente == null)
                    {
                        _ultimo = nuevoNodo;
                    }
                }
            }
            cantidadDeAmigos++;

        }
        public void EliminarPorPosicion(int posicion)
        {
            Nodo auxilar = _primero;
            if (EsVacia())
            {
                throw new Exception("La lista esta vacia");
            }
            else
            {
                if (posicion == 0)
                {
                    Nodo tmp = _primero;
                    _primero = tmp.Siguiente;
                    tmp.Dato = null;
                    tmp.Siguiente = null;

                    if (_primero == null)
                        _ultimo = null;
                }
                else
                {
                    Nodo actual = _primero;
                    int contador = 0;

                    while (actual != null && contador < posicion - 1)
                    {
                        actual = actual.Siguiente;
                    }

                    if (actual != null && actual.Siguiente != null)
                    {
                        actual.Siguiente = actual.Siguiente.Siguiente;

                        if (actual.Siguiente == null)
                            _ultimo = actual;
                    }
                }
            }cantidadDeAmigos--;
        }

        public Nodo RetornarNodo()
        {
            return _primero;
        }

        public Persona BuscarPorTelefono(string valor)
        {
            Nodo actual = _primero;
            while (actual != null)
            {
                if (actual.Dato.Telefono.ToString() == valor)
                {
                    return actual.Dato;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        public Persona Buscar(string valor)
        {
            Nodo actual = _primero;
            while (actual != null)
            {
                if (actual.Dato.Email.ToString() == valor)
                {
                    return actual.Dato;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
    }  
}
