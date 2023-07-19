using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDeAmigos
{
    internal class TablaDispersa
    {
        private int _tamanoTabla;
        private ListaSimple[] tabla;

        public TablaDispersa(int tamanoTabla)
        {
            _tamanoTabla = tamanoTabla;
            tabla = new ListaSimple[tamanoTabla];

            for (int i = 0; i < tamanoTabla; i++)
            {
                tabla[i] = new ListaSimple();
            }
        }

        public void Insertar(Persona persona)
        {
            bool esRepetido = Buscar(persona.Telefono) != null;
            if(!esRepetido)
            {
                int posicion = Direccion(persona.Telefono);
                tabla[posicion].AgregarPorCola(persona);
            }
            else
            {
                Console.WriteLine($"El telefono ({persona.Telefono}) ya se encuentra registrado ");
            }
        }

        public Persona Buscar(string clave)
        {
            int posicion = Direccion(clave);
            return tabla[posicion].Buscar(clave);
        }

        public void Eliminar(string clave)
        {
            int posicion = Direccion(clave);
            tabla[posicion].EliminarPorValor(clave);
        }

        private int Direccion(string clave)
        {
            int i = 0;
            long p, d;
            d = TransformaCadena(clave);
            p = d % _tamanoTabla;

            while (!tabla[p].EsVacia() && tabla[p].Buscar(clave) == null)
            {
                i++;
                p = p + i * i;
                p = p % _tamanoTabla;
            }

            return (int)p;
        }

        private long TransformaCadena(string c)
        {
            long d = 0;
            for (int j = 0; j < c.Length; j++)
            {
                d = d * 27 + (int)c[j];
            }
            if (d < 0)
                d = -d;

            return d;
        }
        public void Imprimir()
        {
            for (int i = 0; i < _tamanoTabla; i++)
            {
                ListaSimple lista = tabla[i];
                Nodo actual = lista.RetornarNodo();

                //Console.WriteLine("Posición {0}:", i);

                while (actual != null)
                {
                    Console.WriteLine("Numeros: {0}", actual.Dato.Telefono);
                    
                    Console.WriteLine("------------------");

                    actual = actual.Siguiente;
                }

                //Console.WriteLine();
            }
        }

    }
}
