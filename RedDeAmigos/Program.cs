namespace RedDeAmigos
{
    internal class Program
    {
        const int m = 89;

        static void Main(string[] args)
        {
            ListaCircularDoble personas = new ListaCircularDoble();
            TablaDispersa Directorio = new TablaDispersa(m);


            //inicio();



            



            

            personas.AgregarPorCola(new Persona("Alexander", "Suarez", 20, "809 546 1589", "alexander@gmail.com"));
            Directorio.Insertar(personas.Buscar("alexander@gmail.com"));

            personas.AgregarPorCola(new Persona("Julio", "Pichardo", 19, "829 767 5954", "juliopichardo@gmail.com"));
            Directorio.Insertar(personas.Buscar("juliopichardo@gmail.com"));

            personas.AgregarOrdenado(new Persona("Samuel", "Alarado", 22, "849 654 3123", "samuelalvarado@gmail.com"));
            Directorio.Insertar(personas.Buscar("samuelalvarado@gmail.com"));

            personas.AgregarOrdenado(new Persona("Robelin", "Concepcion", 17, "829 768 5954", "Robelin@gmail.com"));
            Directorio.Insertar(personas.Buscar("Robelin@gmail.com"));

            //personas.Imprimir();
            personas.ImprimirReversa();

            //Directorio.Imprimir();
            //Console.WriteLine("Cantidad De Personas en la Red Social: " + personas.CantidadDePersonas());

            personas.Buscar("alexander@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "juliopichardo@gmail.com"); // se esta agragando un amigo por email
            personas.Buscar("alexander@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "Robelin@gmail.com");
            personas.Buscar("alexander@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "samuelalvarado@gmail.com");
            personas.Buscar("alexander@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "juliopichardo@gmail.com");


            personas.Buscar("alexander@gmail.com").amigos.AgregarPorCola(personas.Buscar("alexander@gmail.com").solicitudDeAmistad.Pop().Dato); // esto seria lo que tendriamos que usar para aceptar solicitud

            personas.Buscar("alexander@gmail.com").amigos.Imprimir();

            //Si dice que ya hay un corroe intruducido cuando ejecuta, es a posta, para probar que no se puedan repatir correos

            //personas.Buscar("alexander@gmail.com").solicitudDeAmistad.Imprimir();// esto es una prebua, no es la vesion final


            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                          Menú de Opciones                                ║");
            Console.WriteLine("╟──────────────────────────────────────────────────────────────────────────╢");
            Console.WriteLine("║ 1. Agregar una persona nueva                                             ║");
            Console.WriteLine("║ 2. Agregar un amigo a la persona visualizada                             ║");
            Console.WriteLine("║ 3. Imprimir amigos aceptados de la persona visualizada                   ║");
            Console.WriteLine("║ 4. Imprimir amigos mutuos de la persona visualizada                      ║");
            Console.WriteLine("║ 5. Imprimir personas que tienen a la persona visualizada como amigo      ║");
            Console.WriteLine("║ 6. Trabajar con la cola de solicitudes de amistad                        ║");
            Console.WriteLine("║ 7. Armar árbol con la persona visualizada como raíz y imprimir el árbol  ║");
            Console.WriteLine("║ 8. Imprimir listado de personas en orden ascendente                      ║");
            Console.WriteLine("║ 9. Imprimir listado de personas en orden descendente                     ║");
            Console.WriteLine("║ 10. Imprimir factor de carga del directorio telefónico                   ║");
            Console.WriteLine("║ 0. Salir                                                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");


            NodoDoble personaActual = personas.getPrimero();

            Console.WriteLine();



        }

        private static void inicio()
        {
            Console.WriteLine(@"
                                   ___________________________________
                          ________|                                   |_______
                          \       |    Bienvenido a la Red de amigos  |      /
                           \      |                                   |     /
                           /      |___________________________________|     \
                          /__________)                        (______________\
            ");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\t\tCargando Red de amigos...");

            int totalSteps = 100;
            for (int currentStep = 0; currentStep <= totalSteps; currentStep++)
            {
                // Calcula el porcentaje completado
                int percentage = (int)((double)currentStep / totalSteps * 100);

                // Borra la línea anterior y muestra la nueva línea de progreso
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write($"\t\tProgreso: [{new string('█', percentage / 2).PadRight(50)}] {percentage}%");

                // Simula una pausa para ver el progreso
                System.Threading.Thread.Sleep(100);
            }

            Console.Clear();
        }
    }
   


}
