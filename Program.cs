using InventarioApp.Factories;
using Inventario.Models;
using InventarioApp.Repositories;
using Inventario.Infrastructure;

Console.WriteLine("====================== InventarioApp====================");

var repository = new InMemoryProductoRepository();

Productos laptop = ProductoFactory.Crear(nombre: "Laptop Dell XPS 13", precio: 1200, cantidad: 5, CategoriaProducto.Electronica);
Productos mouse = ProductoFactory.Crear(nombre: "Mouse Logitech MX Master", precio: 99, cantidad: 20, CategoriaProducto.Electronica);
Productos teclado = ProductoFactory.Crear(nombre: "Teclado Mecánico", precio: 150, cantidad: 3, CategoriaProducto.Electronica);
Productos silla = ProductoFactory.Crear(nombre: "Silla Ergonómica Herman Miller", precio: 500, cantidad: 8, CategoriaProducto.Muebles);
Productos escritorio = ProductoFactory.Crear(nombre: "Escritorio Stand-up", precio: 300, cantidad: 2, CategoriaProducto.Muebles);

repository.Agregar(laptop);
repository.Agregar(mouse);
repository.Agregar(teclado);
repository.Agregar(silla);
repository.Agregar(escritorio);

Console.WriteLine($"Productos agregados: {repository.Cantidad}");

IEnumerable<Productos> electronicos = repository.BuscarPorCategoria(CategoriaProducto.Electronica);
Console.WriteLine($"Productos electronicos: {electronicos.Count()}");

foreach (Productos producto in electronicos)
{
    Console.WriteLine($" {producto.Nombre} : {producto.Precio:C2}");
}

IEnumerable<Productos> conMouse = repository.BuscarPorNombre("mouse");
Console.WriteLine($"\nProductos con mouse: {conMouse.Count()}");

foreach (Productos producto in conMouse)
{
    Console.WriteLine($" {producto.Nombre} : {producto.Precio:C2}");
}

IEnumerable<string> nombres = repository.ObtenerNombresProductos();
Console.WriteLine($"\nTodos los nombres de los productos: {string.Join(", ", nombres)}");

bool hayStockBajo = repository.HayStockBajo();
Console.WriteLine($"\nHay stock bajo: {hayStockBajo}");