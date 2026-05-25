using Inventario.Models;

namespace InventarioApp.Repositories;

public class InMemoryProductoRepository : IProductoRepository
{
  private readonly List<Productos> _productos = new ();

  private int _nextId = 1;

  public void Agregar(Productos producto)
  {
    producto.Id = _nextId++;
    _productos.Add(producto);
  }

  public Productos? ObtenerPorId(int id)
  {
    return _productos.FirstOrDefault(p => p.Id == id);
  }

  public IEnumerable<Productos> ObtenerTodos()
  {
    return _productos.AsReadOnly();
  }

  public bool Actualizar(Productos producto)
  {
    var existente = ObtenerPorId(producto.Id);
    if (existente == null) return false;

    existente.Nombre = producto.Nombre;
    existente.Precio = producto.Precio;
    existente.Cantidad = producto.Cantidad;
    existente.Categoria = producto.Categoria;
    existente.Estado = producto.Estado;
    existente.FechaProducto = producto.FechaProducto;
    return true;
  }

  public bool Eliminar(int id)
  {
    var producto = ObtenerPorId(id);
    if (producto == null) return false;

    _productos.Remove(producto);
    return true;
  }

  public int Cantidad => _productos.Count;


//=========== Busqueda con where linq =============
public IEnumerable<Productos> BuscarPorCategoria(CategoriaProducto categoria)
{
    return _productos.Where(p => p.Categoria == categoria);
}

public IEnumerable<Productos> BuscarPorNombre(string nombre)
{
    return _productos.Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
}

public IEnumerable<Productos> BuscarPorRangoPrecio(decimal min, decimal max)
{
    return _productos.Where(p => p.Precio >= min && p.Precio <= max);
}

//== select y any 

public IEnumerable<string> ObtenerNombresProductos()
{
    return _productos.Select(p => p.Nombre);
}

public bool HayStockBajo()
  {
    return _productos.Any(p => p.Cantidad < 5);
  }

public IEnumerable<Productos> obtenerOrdenadoPorPrecio()
{
    return _productos.OrderBy(p => p.Precio);
}

public IEnumerable<Productos> obtenerTopPorPrecio()
{
    return _productos.OrderByDescending(p => p.Precio).Take(5);
}

//== group by y conversion a diccionario

public IEnumerable<IGrouping<CategoriaProducto, Productos>> AgruparPorCategoria()
{
    return _productos.GroupBy(p => p.Categoria);
}

public Dictionary<CategoriaProducto, List<Productos>> ObtenerDiccionarioPorCategoria()
{
    return _productos.GroupBy(p => p.Categoria)
                      .ToDictionary(g => g.Key, g => g.ToList());

}

//== agregacion con sum , average , maxby

public decimal ObtenerValorTotalInventario()
{
    return _productos.Sum(p => p.valorTotal);
}

public decimal ObtenerPrecioPromedio()
{
    return _productos.Average(p => p.Precio);

}

public Productos? ObtenerProductoMasCaro()
{
    return _productos.MaxBy(p => p.Precio);
}

public Dictionary<CategoriaProducto, decimal> ObtenerValorTotalPorCategoria()
{
    return _productos.GroupBy(p => p.Categoria)
                      .ToDictionary(g => g.Key, g => g.Sum(p => p.valorTotal));
}

public IEnumerable<Productos> ObtenerStockBajo(int minimo)
{
    return _productos.Where(p => p.Cantidad < minimo);
}


}