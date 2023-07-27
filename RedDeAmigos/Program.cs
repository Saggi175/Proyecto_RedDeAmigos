using System.ComponentModel;

namespace RedDeAmigos
{
    public  class Program
    {
        const int m = 89;
        static string Iemail;
        static void Main(string[] args)
        {
            ListaCircularDoble personas = new ListaCircularDoble();
            TablaDispersa directorio = new TablaDispersa(m);
            TablaDispersa tablaHash = new TablaDispersa(100);
            Arbol arbol = new Arbol();

            inicio();

            //Base de datos de personas
            personas.AgregarPorCola(new Persona("Alexander", "Suarez", 20, "809 546 1589", "alexander@gmail.com"));
            directorio.Insertar(personas.Buscar("alexander@gmail.com"));

            personas.AgregarPorCola(new Persona("Julio", "Pichardo", 19, "829 767 5954", "juliopichardo@gmail.com"));
            directorio.Insertar(personas.Buscar("juliopichardo@gmail.com"));

            personas.AgregarOrdenado(new Persona("Samuel", "Alarado", 22, "849 654 3123", "samuelalvarado@gmail.com"));
            directorio.Insertar(personas.Buscar("samuelalvarado@gmail.com"));

            personas.AgregarOrdenado(new Persona("Robelin", "Concepcion", 17, "829 768 5954", "Robelin@gmail.com"));
            directorio.Insertar(personas.Buscar("Robelin@gmail.com"));

            //Envio de solicitud de amistad
            personas.Buscar("alexander@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "juliopichardo@gmail.com");
            personas.Buscar("alexander@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "Robelin@gmail.com");
            personas.Buscar("alexander@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "samuelalvarado@gmail.com");
            personas.Buscar("juliopichardo@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "alexander@gmail.com");
            personas.Buscar("juliopichardo@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "Robelin@gmail.com");
            personas.Buscar("Robelin@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "juliopichardo@gmail.com");

            //Aceptar solicitud de amistad
            personas.Buscar("alexander@gmail.com").amigos.AgregarPorCola(personas.Buscar("alexander@gmail.com").solicitudDeAmistad.Pop().Dato);
            personas.Buscar("alexander@gmail.com").amigos.AgregarPorCola(personas.Buscar("alexander@gmail.com").solicitudDeAmistad.Pop().Dato);
            personas.Buscar("juliopichardo@gmail.com").amigos.AgregarPorCola(personas.Buscar("juliopichardo@gmail.com").solicitudDeAmistad.Pop().Dato);
            personas.Buscar("juliopichardo@gmail.com").amigos.AgregarPorCola(personas.Buscar("juliopichardo@gmail.com").solicitudDeAmistad.Pop().Dato);
            personas.Buscar("Robelin@gmail.com").amigos.AgregarPorCola(personas.Buscar("Robelin@gmail.com").solicitudDeAmistad.Pop().Dato);

            Console.WriteLine("¿Deseas ver las personas en orden ascendente o descendente?\n");
            Console.WriteLine(@"
╔════════════════╗ ╔═════════════════╗  
║ (a) ascendente ║ ║ (d) descendente ║  
╚════════════════╝ ╚═════════════════╝   
");
            string opLista = Console.ReadLine().ToLower();
            NodoDoble personaActual;

            if (opLista == "d")
                personaActual = personas.getUltimo();

            else
                personaActual = personas.getPrimero();

            Console.Clear();
            string op = "s";
     
            while (op.ToLower() != "n")
            {
               

                Console.Write(@$"

╔════════════════════════════════════════════╗
║                                            ║
║                                            ║
                ╔╦╦╦╦╦╦╦╦╦╦╦╦╗
                ╠╬╬╬╬╬╬╬╬╬╬╬╬╣
                ╠╬╬╬╬╬╬╬╬╬╬╬╬╣
                ╠╬╬█╬╬╬╬╬╬█╬╬╣
                ╠╬╬╬╬╬╬╬╬╬╬╬╬╣
                ╠╬╬╬╬╬╬╬╬╬╬╬╬╣
                ╠╬█╬╬╬╬╬╬╬╬█╬╣
                ╠╬██████████╬╣
                ╠╬╬╬╬╬╬╬╬╬╬╬╬╣
                ╚╩╩╩╩╩╩╩╩╩╩╩╩╝
");

                Console.WriteLine($"\tNombre:{personaActual.Dato.Nombre} {personaActual.Dato.Apellido} \t\t\n");
                Console.WriteLine($"\tEdad: {personaActual.Dato.Edad} \t\t\n");
                Console.WriteLine($"\tEmail: {personaActual.Dato.Email} \t\t\n");
                Console.WriteLine($"\tTelefono: {personaActual.Dato.Telefono} \t\t\n");
                Console.WriteLine($"\tCantidad de amigos: {personaActual.Dato.amigos.cantidadDeAmigos} \t\t\n");
                Console.Write($"\tSolicitud pendientes: {personaActual.Dato.solicitudDeAmistad.CantidadDeSolicitud} \t\t\n");

                Console.Write(@$"
║                                            ║
╚════════════════════════════════════════════╝
Cantidad de personas agregadad actualmente: {personas.CantidadDePersonas}
factor de carga del directorio: {directorio.FactorDeCarga(m)}
");
                Console.Write(@"
╔═══════════════╗ ╔═══════════════╗ ╔═════════════════════════════════╗ ╔═══════════════════════════════════════════════╗
║ (s) siguente  ║ ║ (n) parar     ║ ║ (a) agregar a lista de personas ║ ║ (h) personas que te siguen pero no tu a ellos ║
╚═══════════════╝ ╚═══════════════╝ ╚═════════════════════════════════╝ ╚═══════════════════════════════════════════════╝    
╔═══════════════════════════════════╗ ╔══════════════════════════════╗ ╔═══════════════╗ 
║ (e) enviar solicitudad de amistad ║ ║ (v) ver solicitud de amistad ║ ║ (t) ver arbol ║
╚═══════════════════════════════════╝ ╚══════════════════════════════╝ ╚═══════════════╝
╔═══════════════════╗ ╔══════════════════════════════════╗ ╔═════════════════════════════════════╗
║ (l) listar amigos ║ ║ (m) listar amigos correspondidos ║ ║ (p) listar amigos no correspondidos ║
╚═══════════════════╝ ╚══════════════════════════════════╝ ╚═════════════════════════════════════╝
");
                op = Console.ReadLine();

                Console.Clear();
                switch (op.ToLower())
                {
                    case "s":
                        if (opLista == "d")
                            personaActual = personaActual.Anterior;

                        else
                            personaActual = personaActual.Siguiente;

                    break;

                    case "a":

                        Console.Clear();
                        string nombre, apellido, edad, telefono, email;
                        do
                        {
                            
                            Console.WriteLine("Introduce los datos de la persona");
                            Console.Write("Nombre: ");
                            nombre = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Apellido: ");
                            apellido = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("edad: ");
                            edad = Console.ReadLine().PadLeft(3,'0');
                            Console.WriteLine();
                            Console.Write("telefono: ");
                            telefono = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("email: ");
                            email = Console.ReadLine();
                            Console.Clear();

                            if ((!char.IsDigit(edad[0])) || (!char.IsDigit(edad[1])) || (!char.IsDigit(edad[2])))
                            {
                                Console.WriteLine("No se pudo agregar la persona porque la edad debe ser un valor entero\n");
                            }

                        } while ((!char.IsDigit(edad[0]))|| (!char.IsDigit(edad[1]))|| (!char.IsDigit(edad[2])));

                        Persona tempora = new Persona(nombre, apellido, Convert.ToInt32(edad), telefono, email);
                        personas.AgregarPorCola(tempora);
                        directorio.Insertar(tempora);

                    break;

                    case "e":
                        Console.WriteLine("Introduce correo de la persona a la que quieres enviar la solicitud:");
                        Iemail = Console.ReadLine().Replace(" ", "");
                        personas.Buscar(Iemail)?.solicitudDeAmistad.PushPorEmail(personas, personaActual.Dato?.Email);
                        if ((personas.Buscar(Iemail) == null))
                        {
                            Console.WriteLine("EL correo que estas ingresando no existe...");
                            Console.ReadLine();
                        }
                    break;

                    case "v":

                        while (personas.Buscar(personaActual.Dato.Email).solicitudDeAmistad.CantidadDeSolicitud > 0)
                        {
                            Console.Write(@$"
       
╔════════════════════════════════════════════╗
║                                            ║
║                                            ║
                ╔╦╦╦╦╦╦╦╦╦╦╦╦╗
                ╠╬╬╬╬╬╬╬╬╬╬╬╬╣
                ╠╬╬╬╬╬╬╬╬╬╬╬╬╣
                ╠╬╬█╬╬╬╬╬╬█╬╬╣
                ╠╬╬╬╬╬╬╬╬╬╬╬╬╣
                ╠╬╬╬╬╬╬╬╬╬╬╬╬╣
                ╠╬█╬╬╬╬╬╬╬╬█╬╣
                ╠╬██████████╬╣
                ╠╬╬╬╬╬╬╬╬╬╬╬╬╣
                ╚╩╩╩╩╩╩╩╩╩╩╩╩╝

");
                            Console.WriteLine($"\tNombre:{personas.Buscar(personaActual.Dato.Email).solicitudDeAmistad.PeekNodo().Dato.Nombre} {personas.Buscar(personaActual.Dato.Email).solicitudDeAmistad.PeekNodo().Dato.Apellido}\t\t\n");

                            Console.WriteLine($"\tEdad: {personas.Buscar(personaActual.Dato.Email).solicitudDeAmistad.PeekNodo().Dato.Edad} \t\t\n");
                            Console.WriteLine($"\tEmail: {personas.Buscar(personaActual.Dato.Email).solicitudDeAmistad.PeekNodo().Dato.Email} \t\t\n");
                            Console.WriteLine($"\tTelefono: {personas.Buscar(personaActual.Dato.Email).solicitudDeAmistad.PeekNodo().Dato.Telefono} \t\t\n");


                            Console.Write(@$"



║                                            ║
╚════════════════════════════════════════════╝
");

                            Console.Write(@"
╔═══════════════╗ ╔═══════════════╗ ╔══════════╗ 
║ (a) aceptar   ║ ║ (r) rechasar  ║ ║ (m) menu ║ 
╚═══════════════╝ ╚═══════════════╝ ╚══════════╝  
");
                            string aceptar;

                            aceptar = Console.ReadLine();

                            if (aceptar.ToLower() == "a")
                            {
                                personas.Buscar(personas.Buscar(personaActual.Dato.Email).solicitudDeAmistad.Pop().Dato.Email).amigos.AgregarPorCola(personaActual.Dato);
                            }
                            else if (aceptar.ToLower() == "r")
                            {
                                personas.Buscar(personaActual.Dato.Email).solicitudDeAmistad.Pop();
                            }
                            else if (aceptar.ToLower() == "m")
                            {
                                Console.Clear();
                                break;
                            }

                            Console.Clear();

                        }
                        if (personas.Buscar(personaActual.Dato.Email).solicitudDeAmistad.CantidadDeSolicitud <= 0)
                        {
                            Console.WriteLine("No hay mas solicitud de amistad, presiona enter para seguir.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                    break;

                    case "l":

                        Console.Clear();
                        personaActual.Dato.amigos.ImprimirListaDeAmigos();
                        Console.ReadLine();
                        Console.Clear();

                    break;

                    case "m":

                        Console.Clear();
                        Nodo auxiliar = personaActual.Dato.amigos.getPrimero();
                        bool correspodidos = false;

                        while (auxiliar != null)
                        {
                            if(auxiliar.Dato.amigos.BuscarPorEmail(personaActual.Dato.Email)?.Email != null)
                            {

                                Console.Write(@$"       
╔════════════════════════════════════════════╗
║                                            ║
║                                            ║

");
                                Console.WriteLine($"\tNombre:{auxiliar.Dato.Nombre} {auxiliar.Dato.Apellido} \t\t\n");

                                Console.WriteLine($"\tEdad: {auxiliar.Dato.Edad} \t\t\n");
                                Console.WriteLine($"\tEmail: {auxiliar.Dato.Email} \t\t\n");
                                Console.WriteLine($"\tTelefono: {auxiliar.Dato.Telefono} \t\t\n");
                                Console.WriteLine($"\tCantidad de amigos: {auxiliar.Dato.amigos.cantidadDeAmigos} \t\t\n");
                                Console.WriteLine(@$"
║                                            ║
╚════════════════════════════════════════════╝
");
                                correspodidos = true;                                
                            }
                            auxiliar = auxiliar.Siguiente;
                        }

                        if (!correspodidos)
                        {
                            Console.WriteLine("No tienes amigos o No tienes amigos correspondidos");
                        }

                        Console.ReadLine();
                        Console.Clear();

                    break;

                    case "p":

                        Console.Clear();                        
                        Nodo auxiliarExtra = personaActual.Dato.amigos.getPrimero();

                        bool tengoAmigos = false;
                        while (auxiliarExtra != null)
                        {
                            if (auxiliarExtra.Dato.amigos.BuscarPorEmail(personaActual.Dato.Email)?.Email == null)
                            {

                                Console.Write(@$"       
╔════════════════════════════════════════════╗
║                                            ║
║                                            ║

");
                                Console.WriteLine($"\tNombre:{auxiliarExtra.Dato.Nombre} {auxiliarExtra.Dato.Apellido} \t\t\n");

                                Console.WriteLine($"\tEdad: {auxiliarExtra.Dato.Edad} \t\t\n");
                                Console.WriteLine($"\tEmail: {auxiliarExtra.Dato.Email} \t\t\n");
                                Console.WriteLine($"\tTelefono: {auxiliarExtra.Dato.Telefono} \t\t\n");
                                Console.WriteLine($"\tCantidad de amigos: {auxiliarExtra.Dato.amigos.cantidadDeAmigos} \t\t\n");
                                Console.WriteLine(@$"
║                                            ║
╚════════════════════════════════════════════╝
");
                                tengoAmigos = true;

                            }
                            auxiliarExtra = auxiliarExtra.Siguiente;
                        }

                        if (!tengoAmigos && personaActual.Dato.amigos.cantidadDeAmigos > 0)
                        {
                            Console.WriteLine("Todo tus amigos son correspondidos");
                        }
                        else if (!tengoAmigos && personaActual.Dato.amigos.cantidadDeAmigos <= 0)
                        {
                            Console.WriteLine("No tienes amigos");
                        }

                        Console.ReadLine();
                        Console.Clear();

                    break;

                    case "t":

                        Console.Clear();
                        arbol.ConstruirArbol(personaActual.Dato, tablaHash);
                        arbol.ImprimirArbol();
                        Console.ReadLine();
                        Console.Clear();

                    break;

                    case "h":

                        Console.Clear();                       
                        NodoDoble auxiliarDoble = personas.getPrimero();
                        bool seguidosMutuo = false;

                        do
                        {
                            if (auxiliarDoble.Dato.amigos.BuscarPorEmail(personaActual.Dato.Email)?.Email != null && 
                                personaActual.Dato.amigos.BuscarPorEmail(auxiliarDoble.Dato.Email)== null)
                            {

                                Console.Write(@$"       
╔════════════════════════════════════════════╗
║                                            ║
║                                            ║

");
                                Console.WriteLine($"\tNombre:{auxiliarDoble.Dato.Nombre} {auxiliarDoble.Dato.Apellido} \t\t\n");

                                Console.WriteLine($"\tEdad: {auxiliarDoble.Dato.Edad} \t\t\n");
                                Console.WriteLine($"\tEmail: {auxiliarDoble.Dato.Email} \t\t\n");
                                Console.WriteLine($"\tTelefono: {auxiliarDoble.Dato.Telefono} \t\t\n");
                                Console.WriteLine($"\tCantidad de amigos: {auxiliarDoble.Dato.amigos.cantidadDeAmigos} \t\t\n");
                                Console.WriteLine(@$"
║                                            ║
╚════════════════════════════════════════════╝
");
                                seguidosMutuo = true;

                            }
                            auxiliarDoble = auxiliarDoble.Siguiente;
                        } while (auxiliarDoble != personas.getPrimero());

                        if (!seguidosMutuo && personaActual.Dato.amigos.cantidadDeAmigos > 0)
                        {
                            Console.WriteLine("Sigues a todo los que te siguen o Nadie te sigue");
                        }
                        else if (!seguidosMutuo && personaActual.Dato.amigos.cantidadDeAmigos <= 0)
                        {
                            Console.WriteLine("No tienes amigos");
                        }

                        Console.ReadLine();
                        Console.Clear();

                    break;

                }
                if (op.ToLower() == "s")
                    Console.Clear();
            }
        }  

        private static void inicio()
        {
            
            Console.WriteLine(@"
            ██████╗ ███████╗██████╗     ██████╗ ███████╗     █████╗ ███╗   ███╗██╗ ██████╗  ██████╗ ███████╗
            ██╔══██╗██╔════╝██╔══██╗    ██╔══██╗██╔════╝    ██╔══██╗████╗ ████║██║██╔════╝ ██╔═══██╗██╔════╝
            ██████╔╝█████╗  ██║  ██║    ██║  ██║█████╗      ███████║██╔████╔██║██║██║  ███╗██║   ██║███████╗
            ██╔══██╗██╔══╝  ██║  ██║    ██║  ██║██╔══╝      ██╔══██║██║╚██╔╝██║██║██║   ██║██║   ██║╚════██║
            ██║  ██║███████╗██████╔╝    ██████╔╝███████╗    ██║  ██║██║ ╚═╝ ██║██║╚██████╔╝╚██████╔╝███████║
            ╚═╝  ╚═╝╚══════╝╚═════╝     ╚═════╝ ╚══════╝    ╚═╝  ╚═╝╚═╝     ╚═╝╚═╝ ╚═════╝  ╚═════╝ ╚══════╝
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
