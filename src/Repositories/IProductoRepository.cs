namespace InventarioApp.Repositories;
using Inventario.Models;

public interface IProductoRepository
{
  void Agregar(Productos producto);

  Productos? ObtenerPorId(int id);

  IEnumerable<Productos> ObtenerTodos();

  bool Actualizar(Productos producto);

  bool Eliminar(int id);

  int Cantidad{ get; }
}
