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

            personas.Imprimir();
            Directorio.Imprimir();

            Console.WriteLine("Cantidad De Personas en la Red Social: " + personas.CantidadDePersonas());
        }
    }
}
