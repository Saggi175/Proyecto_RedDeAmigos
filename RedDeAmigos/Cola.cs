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

        public int CantidadDeSolicitud { get; set; }

        public Cola()
        {
            cima = _ultimo = null;
            CantidadDeSolicitud = 0;
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
            CantidadDeSolicitud++;
        }

        public void PushPorEmail(ListaCircularDoble persona, string email)
        {
            bool correoRepetido = BuscarPorEmail(persona.Buscar(email).Email)!= null;
            
            
            if (!correoRepetido)
            {
                Nodo nuevoNodo = new Nodo(persona.Buscar(email));
                if (EsVacia())
                {
                    cima = _ultimo = nuevoNodo;
                }
                else
                {
                    _ultimo.Siguiente = nuevoNodo;
                    _ultimo = nuevoNodo;
                }
                CantidadDeSolicitud++;
            }
            else
            {
                Console.WriteLine($"\nEste correo ({email}) ya esta registrado en la cola de solicitud ");
            }
           
        }

        public Persona BuscarPorEmail(string email)
        {
            Nodo actual = cima;
            while (actual != null)
            {
                if (actual.Dato.Email == email)
                {
                    return actual.Dato;
                }
                actual = actual.Siguiente;
            }
            return null;
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
                CantidadDeSolicitud--;

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

        public void Imprimir()
        {
            Nodo auxiliar = cima;

            Console.WriteLine("Solicitudes de amistad");

            while (auxiliar != null)
            {
                Console.WriteLine(auxiliar.Dato.Nombre);
                auxiliar = auxiliar.Siguiente;
            }
        }
    }
}
