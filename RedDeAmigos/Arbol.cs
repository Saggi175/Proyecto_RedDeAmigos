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
            raiz.Visitar();
        }
    }
}
