﻿using System.ComponentModel;

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

            Persona persona1 = new Persona("Juan", "Pérez", 30, "111111", "juan@example.com");
            Persona persona2 = new Persona("María", "Gómez", 28, "222222", "maria@example.com");
            Persona persona3 = new Persona("Pedro", "López", 25, "333333", "pedro@example.com");
            Persona persona4 = new Persona("Jesus", "López", 25, "444444", "pedro@example.com");
            Persona persona5 = new Persona("Marco", "López", 25, "555555", "pedro@example.com");

            persona1.amigos.AgregarPorCola(persona2);
            persona1.amigos.AgregarPorCola(persona3);

            persona2.amigos.AgregarPorCola(persona4);
            persona4.amigos.AgregarPorCola(persona5);
            persona4.amigos.AgregarPorCola(persona1);


            //persona2.amigos.AgregarPorCola(persona1);

            // Construir el árbol con la persona raíz y la tabla hash

            //arbol.ConstruirArbol(persona1, tablaHash);
            //arbol.ImprimirArbol();


            //inicio();

            personas.AgregarPorCola(new Persona("Alexander", "Suarez", 20, "809 546 1589", "alexander@gmail.com"));
            directorio.Insertar(personas.Buscar("alexander@gmail.com"));

            personas.AgregarPorCola(new Persona("Julio", "Pichardo", 19, "829 767 5954", "juliopichardo@gmail.com"));
            directorio.Insertar(personas.Buscar("juliopichardo@gmail.com"));

            personas.AgregarOrdenado(new Persona("Samuel", "Alarado", 22, "849 654 3123", "samuelalvarado@gmail.com"));
            directorio.Insertar(personas.Buscar("samuelalvarado@gmail.com"));

            personas.AgregarOrdenado(new Persona("Robelin", "Concepcion", 17, "829 768 5954", "Robelin@gmail.com"));
            directorio.Insertar(personas.Buscar("Robelin@gmail.com"));

            Console.WriteLine(directorio.FactorDeCarga(m));

            //personas.Imprimir();
            //personas.ImprimirReversa();

            //Directorio.Imprimir();
            //Console.WriteLine("Cantidad De Personas en la Red Social: " + personas.CantidadDePersonas());

            personas.Buscar("alexander@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "juliopichardo@gmail.com"); // se esta enviando la solicitud de amistad
            personas.Buscar("alexander@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "Robelin@gmail.com");
            personas.Buscar("alexander@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "samuelalvarado@gmail.com");
            personas.Buscar("juliopichardo@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "alexander@gmail.com");
            personas.Buscar("juliopichardo@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "Robelin@gmail.com");
            personas.Buscar("Robelin@gmail.com").solicitudDeAmistad.PushPorEmail(personas, "juliopichardo@gmail.com");


            personas.Buscar("alexander@gmail.com").amigos.AgregarPorCola(personas.Buscar("alexander@gmail.com").solicitudDeAmistad.Pop().Dato); // esto seria lo que tendriamos que usar para aceptar solicitud

            personas.Buscar("alexander@gmail.com").amigos.AgregarPorCola(personas.Buscar("alexander@gmail.com").solicitudDeAmistad.Pop().Dato); // esto seria lo que tendriamos que usar para aceptar solicitud
            personas.Buscar("juliopichardo@gmail.com").amigos.AgregarPorCola(personas.Buscar("juliopichardo@gmail.com").solicitudDeAmistad.Pop().Dato); // esto seria lo que tendriamos que usar para aceptar solicitud
            personas.Buscar("juliopichardo@gmail.com").amigos.AgregarPorCola(personas.Buscar("juliopichardo@gmail.com").solicitudDeAmistad.Pop().Dato); // esto seria lo que tendriamos que usar para aceptar solicitud
            personas.Buscar("Robelin@gmail.com").amigos.AgregarPorCola(personas.Buscar("Robelin@gmail.com").solicitudDeAmistad.Pop().Dato); // esto seria lo que tendriamos que usar para aceptar solicitud


            //arbol.ConstruirArbol(personas.Buscar("alexander@gmail.com"), tablaHash);
            //arbol.ImprimirArbol();

            Console.WriteLine("\n");
            personas.ImprimirAmigosEnComun();

            //personas.Buscar("alexander@gmail.com").amigos.Imprimir();


            //Si dice que ya hay un corroe intruducido cuando ejecuta, es a posta, para probar que no se puedan repatir correos

            //personas.Buscar("alexander@gmail.com").solicitudDeAmistad.Imprimir();// esto es una prebua, no es la vesion final


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
           // Console.Clear();
           

            while (op.ToLower() != "n")
            {
               // Console.Clear();

                Console.Write(@$"
Cantidad de personas agregadad actualmente: {personas.CantidadDePersonas}
factor de carga del directorio: {directorio.FactorDeCarga(m)}
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
");
                Console.Write(@"
╔═══════════════╗ ╔═══════════════╗ ╔═════════════════════════════════╗ 
║ (s) siguente  ║ ║ (n) parar     ║ ║ (a) agregar a lista de personas ║ 
╚═══════════════╝ ╚═══════════════╝ ╚═════════════════════════════════╝     
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
                        Console.WriteLine("Introduce los datos de la persona");
                        Console.Write("Nombre: ");
                        nombre = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Apellido: ");
                        apellido = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("edad: ");
                        edad = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("telefono: ");
                        telefono = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("email: ");
                        email = Console.ReadLine();
                        Persona tempora = new Persona(nombre, apellido, Convert.ToInt32(edad), telefono, email);
                        Console.Clear();
                        personas.AgregarPorCola(tempora);
                        directorio.Insertar(tempora);
                        

                        break;

                    case "e":
                        Console.WriteLine("Introduce correo de la persona a la que quieres enviar la solicitud:");
                        Iemail = Console.ReadLine().Replace(" ", "");
                        personas.Buscar(Iemail).solicitudDeAmistad.PushPorEmail(personas, personaActual.Dato.Email);
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
                                //personas.Buscar(personaActual.Dato.Email).amigos.AgregarPorCola(personas.Buscar(personaActual.Dato.Email).solicitudDeAmistad.Pop().Dato);
                                personas.Buscar(personas.Buscar(personaActual.Dato.Email).solicitudDeAmistad.Pop().Dato.Email).amigos.AgregarPorCola(personaActual.Dato);
                                //creo que estaba al reves, porque el que envia la solicitud es quien se hace amigo
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
                            Console.WriteLine("No hay mas solicitud de amistad, presiona enter para segir.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        break;

                    case "l":
                        Console.Clear();
                        personaActual.Dato.amigos.ImprimirListaDeAmigos();
                        Console.ReadLine();
                        break;

                    case "m":
                        Console.Clear();
                        //personaActual.Dato.amigos.ImprimirListaDeAmigosMutuos( personaActual.Dato.Email);
                        Nodo auxiliar = personaActual.Dato.amigos.getPrimero();

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
                            }
                            auxiliar = auxiliar.Siguiente;
                        }
                         
                        Console.ReadLine();
                        Console.Clear();

                    break;

                    case "p":
                        Console.Clear();
                        Console.Clear();
                        //personaActual.Dato.amigos.ImprimirListaDeAmigosMutuos( personaActual.Dato.Email);
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
                        
                        arbol.ConstruirArbol(personaActual.Dato, tablaHash);
                        arbol.ImprimirArbol();
                
                        break;



                }
                if (op.ToLower() == "s")


                    Console.Clear();
            }




        }

        

        private static void inicio()
        {
            titulo(@"
            ██████╗ ███████╗██████╗     ██████╗ ███████╗     █████╗ ███╗   ███╗██╗ ██████╗  ██████╗ ███████╗
            ██╔══██╗██╔════╝██╔══██╗    ██╔══██╗██╔════╝    ██╔══██╗████╗ ████║██║██╔════╝ ██╔═══██╗██╔════╝
            ██████╔╝█████╗  ██║  ██║    ██║  ██║█████╗      ███████║██╔████╔██║██║██║  ███╗██║   ██║███████╗
            ██╔══██╗██╔══╝  ██║  ██║    ██║  ██║██╔══╝      ██╔══██║██║╚██╔╝██║██║██║   ██║██║   ██║╚════██║
            ██║  ██║███████╗██████╔╝    ██████╔╝███████╗    ██║  ██║██║ ╚═╝ ██║██║╚██████╔╝╚██████╔╝███████║
            ╚═╝  ╚═╝╚══════╝╚═════╝     ╚═════╝ ╚══════╝    ╚═╝  ╚═╝╚═╝     ╚═╝╚═╝ ╚═════╝  ╚═════╝ ╚══════╝
            ",1);
            

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

        static void titulo(string frase, int frames)
        {
            int a = 0;

            while (a != frase.Length)
            {

                Console.Write(frase[a]);
                a++;
                Thread.Sleep(frames);

            }

            Console.WriteLine();
        }
    }
   


}
