// ============================================================
// SISTEMA DE INVENTARIO - Clase 1.1
// Estado: Mensaje de bienvenida
// ============================================================
using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

if (args.Length > 0)
{
    switch (args[0].ToLower())
    {
        case "--help":
            MostrarAyuda();
            Environment.Exit(0);
            break;
        case "-h":
            MostrarAyuda();
            Environment.Exit(0);
            break;
        case "--version":
            Console.WriteLine($"Versión de la aplicación: {version}");
            Environment.Exit(0);
            break;
        case "-v":
            Console.WriteLine($"Versión de la aplicación: {version}");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine($"Comando desconocido: {args[0]}");
            Console.WriteLine("Use --help para ver los comandos disponibles.");
            Environment.Exit(2);
            break;
    }
}
MostarBanner();
//Modo Interactivo si no hay argumentos
Console.Write("Ingrese un comando (o salir para terminar): ");
string? entrada = Console.ReadLine();

if (string.IsNullOrWhiteSpace(entrada) || entrada.ToLower() == "salir")
{
    Console.WriteLine("Saliendo del programa...");
    Environment.Exit(0);
}
/*Console.WriteLine();
Console.WriteLine("Estructura del proyecto:");
Console.WriteLine("    |-- Program.cs (Archivo principal)");
Console.WriteLine("    |-- InventarioApp.csproj (Archivo de configuración)");
Console.WriteLine("    |-- .gitignore (Archivo de configuración de Git)");
Console.WriteLine("    |-- README.md  (Archivo de documentación)");
Console.WriteLine("    |-- src/");
Console.WriteLine("         |-- Models/(Proxima clase)");
Console.WriteLine("Configuración de proyecto: .csproj");
Console.WriteLine("Carpeta src/: Código fuente");
Console.WriteLine("Metadatos Configurados");
Console.WriteLine();
Console.WriteLine("proximo paso:agregar argumentos CLI y configuracion de repositorio en github");
*/


// ===========================FUNCIONES==================================
void MostarBanner()
{
    Console.WriteLine("==========================================");
    Console.WriteLine("    SISTEMA DE GESTIÓN DE INVENTARIO      ");
    Console.WriteLine("==========================================");
    Console.WriteLine();
    Console.WriteLine($"Versión de la aplicación: {version}");
    Console.WriteLine($"Plataforma: {Environment.OSVersion}");
    Console.WriteLine($".NET Version: {Environment.Version}");
    Console.WriteLine();
}

void MostrarAyuda()
{
    Console.WriteLine("USO: InventarioApp [comando] [opciones]");
    Console.WriteLine();
    Console.WriteLine("COMANDOS:");
    Console.WriteLine("  --help, -h      Muestra esta ayuda");
    Console.WriteLine("  --version, -v   Muestra la version del programa");
    Console.WriteLine();
    Console.WriteLine("EJEMPLOS:");
    Console.WriteLine(" dotnet run -- --help");
    Console.WriteLine(" dotnet run -- --version");
}