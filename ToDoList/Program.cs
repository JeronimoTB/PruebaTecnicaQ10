using System;
using System.Collections.Generic;

namespace ToDoList
{
    class Program
    {
        static List<Tareas> tareas = new List<Tareas>(); // Inicializa la lista de tareas generica

        static void Main(string[] args)
        {
            // Muestra repetidamente el menu hasta que el usuario elija salir
            while (true)
            {
                // Limpia la consola para mostrar el menú actualizado
                Console.Clear();

                // Muestra el menú principal de la aplicación
                Console.WriteLine("Aplicación de Lista de Tareas");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Listar Tareas");
                Console.WriteLine("3. Marcar Tarea como Completada");
                Console.WriteLine("4. Eliminar Tarea");
                Console.WriteLine("5. Salir");

                // Se Solicita al usuario que elija una opción del menú
                Console.Write("Elige una opción: ");
                var choice = Console.ReadLine();

                // Se crea un switch para manejar la entrada de datos del usuario segun el menu
                switch (choice)
                {
                    case "1":
                        AgregarTarea();
                        break;
                    case "2":
                        ListarTareas();
                        break;
                    case "3":
                        TareaCompletada();
                        break;
                    case "4":
                        EliminarTarea();
                        break;
                    case "5":
                        return;
                    default:
                        // Si la opción ingresada no es válida, muestra un mensaje de error
                        Console.WriteLine("Opción inválida. Presiona Enter para intentar de nuevo.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AgregarTarea()
        {
            // Asegura que se repita el proceso hasta que se ingrese una descripción válida
            while (true)
            {
                Console.Clear();

                Console.Write("Ingresa la descripción de la tarea: ");
                var descripcion = Console.ReadLine();

                // Valida si la descripción es nula o está vacía
                if (string.IsNullOrEmpty(descripcion))
                {
                    Console.WriteLine("Descripción inválida. Presiona Enter para intentar de nuevo.");
                    Console.ReadLine();
                    continue; // Repite el bucle para solicitar una nueva descripción
                }

                DateTime? fechaLimite = null; // Se especifica la fecha límite como nula

                // Asegura que se repita el proceso hasta que se ingrese una fecha límite válida
                while (true)
                {
                    Console.Write("Ingresa la fecha límite (yyyy-mm-dd) o deja vacío: ");
                    var fechaLimiteInput = Console.ReadLine();

                    // Se valida la entrada del usuario como una fecha
                    if (string.IsNullOrWhiteSpace(fechaLimiteInput))
                    {
                        // Si la entrada está vacía, se considera como una fecha nula
                        fechaLimite = null;
                        break; // Sale del bucle para usar la fecha límite nula
                    }

                    if (DateTime.TryParse(fechaLimiteInput, out DateTime fecha))
                    {
                        // Se verifica que la fecha sea una fecha futura
                        if (fecha > DateTime.Today)
                        {
                            fechaLimite = fecha;
                            break; // Sale del bucle si la fecha es válida
                        }
                        else
                        {
                            // Mensaje de error si la fecha no es futura
                            Console.WriteLine("La fecha límite debe ser una fecha futura. Presiona Enter para intentar de nuevo.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        // Mensaje de error si el formato de la fecha no es válido
                        Console.WriteLine("Formato de fecha inválido. Presiona Enter para intentar de nuevo.");
                        Console.ReadLine();
                    }
                }

                tareas.Add(new Tareas(descripcion, fechaLimite));
                Console.WriteLine("Tarea agregada exitosamente. Presiona Enter para continuar.");
                Console.ReadLine();
                break; // Sale del bucle principal una vez que la tarea ha sido agregada exitosamente
            }
        }



        static void ListarTareas()
        {

            // Verificar si la lista de tareas está vacía
            if (tareas.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No hay tareas para listar. Presiona Enter para continuar.");
                Console.ReadLine();
                return; // Salir del método si no hay tareas
            }

            Console.Clear();
            Console.WriteLine("Listado de Tareas:");
            //Cuenta cuantas tareas hay almacenadas en la lista generica
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
            Console.WriteLine("Presiona Enter para continuar.");
            Console.ReadLine();
        }

        //Esta funcion esta hecha para visualizar la lista al usar otros metodos como agregar, eliminar o marcarCompletado
        //Con el fin de que el usuario pueda visualizar y no cometer errores
        static void VerTareas()
        {
            Console.Clear();
            Console.WriteLine("Listado de Tareas:");
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }

        static void TareaCompletada()
        {
            Console.Clear();
            VerTareas();

            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas para marcar como completadas. Presiona Enter para continuar.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingresa el número de la tarea que quieres marcar como completada: ");
            string entrada = Console.ReadLine();

            // Intentar convertir la entrada a un número entero
            if (int.TryParse(entrada, out int numeroTarea))
            {
                // Verificar si el número es válido
                if (numeroTarea > 0 && numeroTarea <= tareas.Count)
                {
                    // Marcar la tarea como completada
                    tareas[numeroTarea - 1].Estado = true; //numeroTarea -1 es para acceder al índice correcto en la lista.
                    Console.WriteLine("Tarea marcada como completada con éxito. Presiona Enter para continuar.");
                }
                else
                {
                    Console.WriteLine("Número de tarea no válido. Debe estar entre 1 y " + tareas.Count + ". Presiona Enter para intentar de nuevo.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Ingresa un número entero. Presiona Enter para intentar de nuevo.");
            }
            Console.ReadLine();
        }

        static void EliminarTarea()
        {
            Console.Clear();
            VerTareas();

            // Verificar si la lista de tareas está vacía
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas para eliminar. Presiona Enter para continuar.");
                Console.ReadLine();
                return; // Salir del método si no hay tareas
            }

            Console.Write("Ingresa el número de la tarea que deseas eliminar: ");
            string entrada = Console.ReadLine();

            // Intentar convertir la entrada a un número entero
            if (int.TryParse(entrada, out int numeroTarea))
            {
                // Verificar que el número de tarea sea válido
                if (numeroTarea > 0 && numeroTarea <= tareas.Count)
                {
                    // Restar 1 del número ingresado para obtener el índice correcto
                    int indiceTarea = numeroTarea - 1;

                    // Eliminar la tarea en el índice especificado
                    tareas.RemoveAt(indiceTarea);
                    Console.WriteLine("Tarea eliminada con éxito. Presiona Enter para continuar.");
                }
                else
                {
                    Console.WriteLine("Número de tarea no válido. Debe estar entre 1 y " + tareas.Count + ". Presiona Enter para intentar de nuevo.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Ingresa un número entero. Presiona Enter para intentar de nuevo.");
            }

            Console.ReadLine();
        }


    }
}
