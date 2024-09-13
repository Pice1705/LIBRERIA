using Libreria;
using Libreria.Clases;

class Program
{
    static void Main()
    {

        Users usuario = new Users();
        Librerias libreria = new Librerias();
        TarjetaDeCredito tarjeta = new TarjetaDeCredito();
        List<Libro> pedido = new List<Libro>();


        bool LogIn = false;
        while (!LogIn) //ESTE CICLO SOLICITA A LA CONSOLA EL INGRESO DE UN NOMBRE Y USUARIO PARA EL INICIO DEL PROGRAMA
                       // SI LOS DATOS SON IGUALES A LOS DATOS QUE ESTAN GUARDADOS EN LAS VARIABLES Nombre y Password VA A SEGUIR LEYENDO EL PROGRAMA
                       // DE LO CONTRARIO SE INFORMA QUE SON INCORRECTAS
        {
            Console.WriteLine("Ingrese usuario:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese Contraseña:");
            string password = Console.ReadLine();

            if (nombre != usuario.Nombre.Trim() || password != usuario.Password.Trim())
            {
                Console.WriteLine("Usuario o contraseña incorrectos...");
            }

            else { LogIn = true; }
        }


        // EL PROGRAMA MUESTRA UN MENU DONDE ESTAN LAS SIGUIENTES OPCIONES:
        string opcionMenu = "0";
        while (opcionMenu != "4") //EJECUTAMOS EL MENU EN UN CICLO WHILE QUE SE GESTIONA HASTA QUE EL USUARIO SELECCION LA OPCION 4 ES DECIR SALIR
        {
            Console.Clear();
            Console.WriteLine("1.Agregar libros al carrito\n2.Remover libros\n3.Ver carrito\n4.Salir");
            Console.WriteLine("Ingrese la opcion que desea: ");
            opcionMenu = Console.ReadLine();
        // UTILIZAMOS UN SWITCH PARA LLAMAR A LA FUNCION CORRESPONDIENTE DEPENDIENDO DE LO ELEGIDO
            switch (opcionMenu)
            {
                case "1":
                    Console.WriteLine("Agregar libros al carrito");
                    ComprarLibros();
                    break;

                case "2":
                    EliminarLibrosCarrito();
                    break;
                case "3":
                    ListCarrito(true);
                    break;
                case "4":
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opcion ingresada no valida");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }

        void ListCarrito(bool beep)
        {
            Console.Clear();
            Console.WriteLine("Carrito: \n");
            foreach (var item in pedido)
            {
                Console.WriteLine($"{item.BookCode}, {item.Name}\n");
            }
            Console.Beep();

            if (beep) { Console.ReadKey(); Console.WriteLine("Presione cualquier tecla para continuar..."); }

        }

        void EliminarLibrosCarrito()
        {
            Console.Clear();
            ListCarrito(false);
            Console.WriteLine("Escriba el ID del libro que desea eliminar de su carrito: ");
            string codigo = Console.ReadLine();

            Libro libroEncontrado = null;
            foreach (var item in pedido)
            {
                if (item.BookCode.ToString() == codigo)
                {
                    libroEncontrado = item;
                    break;
                }
            }

            if (libroEncontrado != null)
            {
                Console.WriteLine("Libro encontrado, seguro que desea eliminarlo? (S/N)");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "s")
                {
                    pedido.Remove(libroEncontrado);
                    tarjeta.Saldo += libroEncontrado.Price;
                    Console.WriteLine("Libro eliminado del carrito.");
                }
                else
                {
                    Console.WriteLine("Operación cancelada...");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Libro no encontrado...");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadLine();
            }
        }

        void Listado()
        {
            Console.Clear();
            Console.Beep();
            Console.WriteLine("\nBienvenido a la Libreria del Pelado || CATALOGO DE LIBROS\n");
            Console.WriteLine("NOMBRE --- PRECIO --- TIPO --- CANTIDAD --- ID\n");
            Console.WriteLine($"SALDO DISPONIBLE: {tarjeta.Saldo}\n");
            foreach (var libro in libreria.Lista)
            {
                Console.WriteLine($"{libro.Name}, {libro.Price}, {libro.TipoLibro}, {libro.Cantidad}, {libro.BookCode}\n");
            }
        }

        void ComprarLibros() 
        {
            Listado(); //METODO PARA MOSTRAR LA LISTA DE LIBROS
            double totalCompra = 0;
            int codigoElegido = -1; // Inicialmente se establece en -1 y luego almacena el código del libro que el usuario quiere comprar.
            while (codigoElegido != 0)
            {
                Console.WriteLine("Seleccione los libros que desee comprar (escriba 0 para salir)");
                codigoElegido = int.Parse(Console.ReadLine()); //SELECCION DEL LIBRO A TRAVEZ DEL CODIGO HASTA QUE INGRESE 0 PARA SALIR

                bool encontrado = false;
                foreach (var libro in libreria.Lista) //UTILIZADOS CICLO FOREACH PARA BUSCAR EN LA LISTA DE LIBROS SI EL CODIGO ELEGIDO C
                                                      //COINCIDE CON EL BOOKCODE
                {
                    if (codigoElegido == libro.BookCode) 
                    {
                        encontrado = true; //ESTABLECEMOS ENCONTRADO EN TRUE
                        if (encontrado == true)
                        {
                            Console.WriteLine("Elija cuantos quiere:"); //SI EL LIBRO ES ENCONTRADO PIDE AL USUARIO QUE INGRESE LA CANTIDAD QUE DESEEA COMPRAR
                            int cantidadElegida = int.Parse(Console.ReadLine());
                            if (cantidadElegida <= libro.Cantidad)   //SI LA CANTIDAD ELEGIDA ES MENOR O IGUAL A LA CANTIDAD DISPONIBLE, EL PROCESO DE COMPRA CONTINUA.
                                                                     //DE LO CONTRARIO, SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE LA CANTIDAD ES INVALIDA
                            {
                                Console.WriteLine("Introduzca num tarjeta, CVC"); //INGRESA NUM DE TARJETA Y CODIGO DE SEGURIDAD DE LA TARJETA 
                                string num = Console.ReadLine();
                                string CVC = Console.ReadLine();

                                if (num == tarjeta.NumberTarjeta.ToString() && CVC == tarjeta.SecurityCode.ToString()) //VERIFICACION DE LA TARJETA DE CREDITO
                                    //SE COMPARAN LOS VALORES INGRESADOS CON LOS DATOS ALMACENADOS EN NUMBERTARJETA Y SECURITYCODE
                                {
                                    if (tarjeta.Saldo >= cantidadElegida * libro.Price)
                                        //VERIFICACION DEL SALDO DE LA TARJETA
                                    {
                                        for (int i = 0; i < cantidadElegida; i++)
                                        {
                                            pedido.Add(libro); //Añade el libro al carrito tantas veces como indique la cantidad seleccionada.
                                        }
                                        totalCompra += libro.Price * cantidadElegida; //Actualiza el total de la compra
                                        tarjeta.Saldo -= cantidadElegida * libro.Price; //Resta el precio de la compra del saldo disponible en la tarjeta
                                        libro.Cantidad -= cantidadElegida; //Disminuye la cantidad disponible de ese libro en el inventario de la librería
                                        Console.WriteLine($"Su total es: {totalCompra}");
                                        Console.WriteLine($"Su saldo restante es: {tarjeta.Saldo}");
                                        Console.WriteLine("Libros añadidos al carrito\n");
                                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                        Console.ReadLine();
                                        break;

                                    }

                                    //ERROES DE CADA CICLO
                                    else

                                    //Si el saldo en la tarjeta no es suficiente, se muestra un mensaje de "Saldo insuficiente" y el proceso de compra se interrumpe.
                                    {
                                        Console.WriteLine("Saldo insuficiente...");
                                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                                else
                                //Si los datos de la tarjeta son incorrectos, también se detiene la compra mostrando el mensaje "Datos de tarjeta inválidos".
                                {
                                    Console.WriteLine("Datos de tarjeta invalidos...");
                                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                            else
                            //Si la cantidad de libros solicitada es mayor que la disponible, el programa también muestra un mensaje de error.
                            {
                                Console.WriteLine("Error cantidad invalida...");
                                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                Console.ReadLine();
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Libro no encontrado...");
                            Console.WriteLine("\nPresione cualquier tecla para continuar...");
                            Console.ReadLine();
                            break;
                        }
                    }
                }

            }
        }
    }
}