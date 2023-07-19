using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDeAmigos
{
    class Persona
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public String Telefono { get; set; }

        public string Email { get; set; }

        public Cola solicitudDeAmistad;

        public ListaSimple amigos;

        public Persona(string nombre, string apellido, int edad, string telefono, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Telefono = telefono;
            Email = email;
            amigos = new ListaSimple();
            solicitudDeAmistad = new Cola();
        }
    }
}
