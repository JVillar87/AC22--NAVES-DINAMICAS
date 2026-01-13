using System;
using System.Collections.Generic;

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
                case 2: CambiarNombre(""); break;
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

        int tipo;
        while (!int.TryParse(Console.ReadLine(), out tipo) || tipo < 1 || tipo > 5)
        {
            Console.Write("Tipo inválido (1-5): ");
        }


        string nombre = GenerarNombre(tipo);

        switch (tipo)
        {
            case 1: navesSTACK.Push(nombre); break;
            case 3: navesQUEUE.Enqueue(nombre); break;
            case 5: navesLIST.Add(nombre); break;
        }

        Console.WriteLine($"Nave creada: {nombre}");
    }

    static void CambiarNombre(string finalName)
    {
        Console.WriteLine("Has elegido la opción 2");
        Console.WriteLine("=== CAMBIAR NOMBRE DE NAVE ===");
        Console.WriteLine($"¿Estás seguro (s/n)?");
        string respuesta = Console.ReadLine() ?? "";

        if (respuesta == "s" || respuesta == "S")
        {
            Console.Write($"Nave renombrada: {finalName}");
        }
    }

    static void ListarNaves()
    {
        Console.WriteLine("====LISTA NAVES====");
        Console.WriteLine("《Naves en HALCONMILENARIO》:");
        foreach (var nave in navesSTACK)
        {
            Console.WriteLine(nave);
        }

        Console.WriteLine("《Naves en CAZAESTELAR》:");
        foreach (var nave in navesSTACK)
        {
            Console.WriteLine(nave);
        }

        Console.WriteLine("《Naves en SUPERDESTRUCTOR》:");
        foreach (var nave in navesQUEUE)
        {
            Console.WriteLine(nave);
        }

        Console.WriteLine("《Naves en YWING》:");
        foreach (var nave in navesQUEUE)
        {
            Console.WriteLine(nave);
        }
    }

    static void EliminarNave()
    {
        Console.WriteLine("Eliminar nave de:");
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