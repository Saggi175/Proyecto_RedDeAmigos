namespace RedDeAmigos
{
    internal class Program
    {
        const int m = 89;
        static void Main(string[] args)
        {
            ListaCircularDoble personas = new ListaCircularDoble();

            personas.AgregarPorCola(new Persona("Alexander", "Suarez", 20, "809 546 1589", "alexander@gmail.com"));
            personas.AgregarPorCola(new Persona("Julio", "Pichardo", 19, "829 767 5954", "juliopichardo@gmail.com"));

            personas.AgregarOrdenado(new Persona("Robelin", "Concepcion", 17, "809 533 1389", "Robelin@gmail.com"));

            TablaDispersa Directorio = new TablaDispersa(m);
            Directorio.Insertar(personas.getUltimo().Dato);

            personas.Imprimir();
            Console.WriteLine("Cantidad De Personas en la Red Social: " + personas.CantidadDePersonas());
        }
    }
}
