using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDeAmigos
{
    internal class Arbol
    {
        private NodoArbol raiz;
        public Arbol()
        {
            raiz = null;
        }
        public void BorrarArbol()
        {
            raiz = null;
        }
        public Arbol(NodoArbol r)
        {
            raiz = r;
        }
        public void SetRaiz(NodoArbol r)
        {
            raiz = r;
        }
        public NodoArbol GetRaiz()
        {
            return raiz;
        }
        public NodoArbol RaizArbol()
        {
            if (raiz != null)
                return raiz;
            else
                throw new Exception(" arbol vacio");
        }
        public bool esVacio()
        {
            return raiz == null;
        }


        // Recorrido de un árbol Arbol en preorden
        public void Recorrer()
        {
            raiz.Visitar(0);
        }

        public void ConstruirArbol(Persona raiz, TablaDispersa tablaHash)
        {
            if (raiz == null || tablaHash == null)
                return;

            // Verificar si la persona ya está en el árbol usando la tabla hash
            if (tablaHash.Buscar(raiz.Telefono) != null)
                return;

            // Insertar la persona raíz en la tabla hash y en el árbol
            tablaHash.Insertar(raiz);
            NodoArbol nodoRaiz = new NodoArbol(raiz);

            // Recorrer la lista de amigos de la persona raíz y agregarlos como hijos
            AgregarHijos(nodoRaiz, raiz.amigos, tablaHash);

            // Establecer la raíz del árbol
            if (esVacio())
                SetRaiz(nodoRaiz);
        }

        private void AgregarHijos(NodoArbol nodoPadre, ListaSimple amigos, TablaDispersa tablaHash)
        {
            Nodo amigo = amigos.getPrimero();
            while (amigo != null)
            {
                // Verificar si el amigo ya está en el árbol usando la tabla hash
                if (tablaHash.Buscar(amigo.Dato.Telefono) == null)
                {
                    tablaHash.Insertar(amigo.Dato);
                    NodoArbol nodoHijo = new NodoArbol(amigo.Dato);
                    nodoPadre.AgregarHijo(nodoHijo);
                    AgregarHijos(nodoHijo, amigo.Dato.amigos, tablaHash); // Llamada recursiva para agregar los hijos de este nodo
                }
                amigo = amigo.Siguiente;
            }
        }

        // Agrega este método para imprimir el nodo raíz del árbol después de construirlo
        public void ImprimirArbol()
        {
            if (esVacio())
            {
                Console.WriteLine("El árbol está vacío.");
            }
            else
            {
                Console.WriteLine("Árbol en preorden:");
                Recorrer();
            }
        }
    }
}
