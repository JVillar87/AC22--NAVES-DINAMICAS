using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

class Program
{
    static Stack<string> navesSTACK = new Stack<string>();
    static Queue<string> navesQUEUE = new Queue<string>();
    static List<string> navesLIST = new List<string>();
    static Random generador = new Random();
    static bool salir = false;

    static void Main()
    {
        while (!salir)
        {
            Console.WriteLine("=== SISTEMA DE FABRICACIÓN DE NAVES ===");
            Console.WriteLine("1. Crear nave");
            Console.WriteLine("2. Cambiar nombre de nave");
            Console.WriteLine("3. Eliminar una nave");
            Console.WriteLine("4. Listar naves");
            Console.WriteLine("5. Eliminar todas");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");

            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 6)
            {
                Console.Write("Opción inválida. Por favor, elige una correcta (1-6): ");
            }

            switch (opcion)
            {
                case 1: CrearNave(); break;
                case 2: CambiarNombre(); break;
                case 3: EliminarNave(); break;
                case 4: ListarNaves(); break;
                case 5: EliminarTodas(); break;
                case 6:
                    salir = true;
                    Console.WriteLine("Programa finalizado.");
                    break;
            }
        }
    }

    static void CrearNave()
    {
        Console.WriteLine("Tipo de nave:");
        Console.WriteLine("1. HALCONMILENARIO (Stack)");
        Console.WriteLine("2. CAZAESTELAR (Stack)");
        Console.WriteLine("3. SUPERDESTRUCTOR (Queue)");
        Console.WriteLine("4. YWING (Queue)");
        Console.WriteLine("5. XWING (List)");
        Console.Write("Opción: ");

        int tipo = int.Parse(Console.ReadLine() ?? "0");

        if (tipo < 1 || tipo > 5)
        {
            Console.WriteLine("Tipo inválido. Operación cancelada.");
            return;
        }

        string nombre = GenerarNombre(tipo);

        switch (tipo)
        {
            case 1: // HALCONMILENARIO
            case 2: // CAZAESTELAR
                navesSTACK.Push(nombre);
                break;

            case 3: // SUPERDESTRUCTOR
            case 4: // YWING
                navesQUEUE.Enqueue(nombre);
                break;

            case 5: // XWING
                navesLIST.Add(nombre);
                break;
        }

        Console.WriteLine($"Nave creada: {nombre}");
    }


    static void CambiarNombre()
    {
        Console.WriteLine("Has elegido la opción 2");
        Console.WriteLine("=== CAMBIAR NOMBRE DE NAVE ===");
        Console.WriteLine($"¿Estás seguro (s/n)?");
        string respuesta = Console.ReadLine() ?? "";

        if (respuesta == "s" || respuesta == "S")
        {
            Console.WriteLine("Tipo de nave a renombrar:");
            Console.WriteLine("1. HALCONMILENARIO");
            Console.WriteLine("2. CAZAESTELAR");
            Console.WriteLine("3. SUPERDESTRUCTOR");
            Console.WriteLine("4. YWING");
            Console.WriteLine("5. XWING");
            Console.Write("Opción: ");

            int tipo = int.Parse(Console.ReadLine() ?? "0");
            while (tipo < 1 || tipo > 5)
            {
                Console.Write("Tipo inválido (1-5): ");
                tipo = int.Parse(Console.ReadLine() ?? "0");
            }

            if (tipo >= 1 && tipo <= 2)
            {
                if (navesSTACK.Count > 0)
                {
                    navesSTACK.Pop();
                    Console.Write("Nuevo nombre de la nave: ");
                    string finalName = Console.ReadLine() ?? "NaveRenombrada";
                    navesSTACK.Push(finalName);
                    Console.WriteLine($"Nave renombrada: {finalName}");
                }
                else
                {
                    Console.WriteLine("No hay naves de ese tipo.");
                }
            }
            else if (tipo >= 3 && tipo <= 4)
            {
                if (navesQUEUE.Count > 0)
                {
                    navesQUEUE.Dequeue();
                    Console.Write("Nuevo nombre de la nave: ");
                    string nuevoNombre = Console.ReadLine() ?? "NaveRenombrada";
                    navesQUEUE.Enqueue(nuevoNombre);
                    Console.WriteLine($"Nave renombrada: {nuevoNombre}");
                }
                else
                {
                    Console.WriteLine("No hay naves de ese tipo.");
                }
            }
            else if (tipo == 5)
            {
                if (navesLIST.Count > 0)
                {
                    Console.Write("Nuevo nombre de la nave: ");
                    string nuevoNombre = Console.ReadLine() ?? "NaveRenombrada";
                    navesLIST[0] = nuevoNombre;
                    Console.WriteLine($"Nave renombrada: {nuevoNombre}");
                }
                else
                {
                    Console.WriteLine("No hay naves de ese tipo.");
                }
            }
        }
    }

    static void ListarNaves()
    {
        Console.WriteLine("==== LISTA NAVES ====");

        Console.WriteLine("Naves tipo 《HALCONMILENARIO》:");
        foreach (var nave in navesSTACK)
        {
            if (nave.StartsWith("Halcón"))
                Console.WriteLine(nave);
        }

        Console.WriteLine("Naves tipo 《CAZAESTELAR》:");
        foreach (var nave in navesSTACK)
        {
            if (nave.StartsWith("Cazador"))
                Console.WriteLine(nave);
        }

        Console.WriteLine("Naves tipo 《SUPERDESTRUCTOR》:");
        foreach (var nave in navesQUEUE)
        {
            if (nave.StartsWith("Destructor"))
                Console.WriteLine(nave);
        }

        Console.WriteLine("Naves tipo 《YWING》:");
        foreach (var nave in navesQUEUE)
        {
            if (nave.StartsWith("Y-Wing"))
                Console.WriteLine(nave);
        }

        Console.WriteLine("Naves tipo 《XWING》:");
        foreach (var nave in navesLIST)
        {
            Console.WriteLine(nave);
        }
    }


    static void EliminarNave()
    {
        Console.WriteLine("===ELIMINAR NAVE TIPO:===");
        Console.WriteLine("1. HALCONMILENARIO");
        Console.WriteLine("2. CAZAESTELAR");
        Console.WriteLine("3. SUPERDESTRUCTOR");
        Console.WriteLine("4. YWING");
        Console.WriteLine("5. XWING");

        int tipo;
        while (!int.TryParse(Console.ReadLine(), out tipo) || tipo < 1 || tipo > 5)
        {
            Console.Write(
            "Tipo inválido (1-5): ");
        }

    }

    static void EliminarTodas()
    {
        navesSTACK.Clear();
        navesQUEUE.Clear();
        navesLIST.Clear();
        Console.WriteLine("Todas las naves han sido eliminadas.");
    }


    static string GenerarNombre(int tipo)
    {
        string[] nombres = { "Halcón", "Cazador", "Destructor", "Y-Wing", "X-Wing" };
        return nombres[tipo - 1] + "_" + generador.Next(1000, 9999);
    }

}