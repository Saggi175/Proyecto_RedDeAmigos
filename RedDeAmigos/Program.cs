namespace RedDeAmigos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaCircularDoble personas = new ListaCircularDoble();

            personas.AgregarPorCola(new Persona("Alexander", "Suarez", 20, "809 546 1589", "alexander@gmial.com"));
            personas.AgregarPorCola(new Persona("Alexander", "Suarez", 20, "809 546 1589", "alexander@gmial.com"));

            personas.AgregarOrdenado(new Persona("Bruno", "Suarez", 20, "809 546 1589", "Bruno@gmial.com"));

            

            personas.Imprimir();
            Console.WriteLine(personas.CantidadDePersonas());

        }
    }
}
