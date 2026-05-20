namespace Inventario.Infrastructure;

public class Filemanager
{
    public  void Escritur(string ruta, string content)
    {
        File.WriteAllText(ruta, content);
    }

    public  string Leer(string ruta)
    {
        return File.ReadAllText(ruta);
    }

    public void Agregar(string ruta, string content)
    {
        File.AppendAllText(ruta, content);
    }

    public bool Exist(string ruta)
    {
        return File.Exists(ruta);
    }

    public void Delete(string ruta)
    {
        File.Delete(ruta);
    }
    public string[] LeerLineas(string ruta)
    {
        return File.ReadAllLines(ruta);
    }

    public void EscribirLineas(string ruta, IEnumerable<string> lineas)
    {
        File.WriteAllLines(ruta, lineas);
    }

    public void CrearDirectorio(string ruta)
    {
        Directory.CreateDirectory(ruta);
    }

    public string[] ObtenerArchivos(string ruta)
    {
        return Directory.GetFiles(ruta);
    }
}

