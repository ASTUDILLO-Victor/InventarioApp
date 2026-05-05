namespace InventarioApp.Factories;

using Inventario.Models;

public static class ProductoFactory
{
    private static int _nextId = 1;
    public static Productos Crear(
        string nombre,
        decimal precio,
        int cantidad,
        CategoriaProducto categoria = CategoriaProducto.Otros)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del producto no puede estar vacío.");
        if (precio < 0)
            throw new ArgumentException("El precio del producto no puede ser negativo.");
        if (cantidad < 0)
            throw new ArgumentException("La cantidad del producto no puede ser negativa.");
        

        return new Productos
        {
            Id = _nextId++,
            Nombre = nombre,
            Precio = precio,
            Cantidad = cantidad,
            Categoria = categoria,
            FechaProducto = DateTime.Now,
            
        };
    }

    public static Productos CrearConStock(
        string nombre,
        decimal precio,
        int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad del producto debe ser mayor que cero para crear con stock.");
        return Crear(nombre, precio, cantidad);
    }
}