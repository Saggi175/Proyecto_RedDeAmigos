namespace RedDeAmigos
{
    internal class Program
    {
        const int m = 89;

        static void Main(string[] args)
        {
            ListaCircularDoble personas = new ListaCircularDoble();
            TablaDispersa Directorio = new TablaDispersa(m);

            personas.AgregarPorCola(new Persona("Alexander", "Suarez", 20, "809 546 1589", "alexander@gmail.com"));
            Directorio.Insertar(personas.Buscar("alexander@gmail.com"));

            personas.AgregarPorCola(new Persona("Julio", "Pichardo", 19, "829 767 5954", "juliopichardo@gmail.com"));
            Directorio.Insertar(personas.Buscar("juliopichardo@gmail.com"));
            
            personas.AgregarOrdenado(new Persona("Samuel", "Alarado", 22, "849 654 3123", "samuelalvarado@gmail.com"));
            Directorio.Insertar(personas.Buscar("samuelalvarado@gmail.com"));

            personas.AgregarOrdenado(new Persona("Robelin", "Concepcion", 17, "829 768 5954", "Robelin@gmail.com"));
            Directorio.Insertar(personas.Buscar("Robelin@gmail.com"));

            //personas.Imprimir();
            //Directorio.Imprimir();
            //Console.WriteLine("Cantidad De Personas en la Red Social: " + personas.CantidadDePersonas());

            personas.Buscar("alexander@gmail.com").amigos.AgregaPorEmail(personas, "juliopichardo@gmail.com"); // se esta agragando un amigo por email
            personas.Buscar("alexander@gmail.com").amigos.AgregaPorEmail(personas, "Robelin@gmail.com"); // se esta agragando un amigo por email
            personas.Buscar("alexander@gmail.com").amigos.AgregaPorEmail(personas, "samuelalvarado@gmail.com"); // se esta agragando un amigo por email
            personas.Buscar("alexander@gmail.com").amigos.AgregaPorEmail(personas, "alexander@gmail.com"); // se esta agragando un amigo por email
            personas.Buscar("alexander@gmail.com").amigos.AgregaPorEmail(personas, "alexander@gmail.com"); // se esta agragando un amigo por email

            //Si dice que ya hay un corroe intruducido cuando ejecuta, es a posta, para probar que no se puedan repatir correos

            personas.Buscar("alexander@gmail.com").amigos.Imprimir();// esto es una prebua, no es la vesion final

        }
    }
}
