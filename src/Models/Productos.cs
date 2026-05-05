namespace Inventario.Models
{
    public class Productos
    {

        private string _nombre ="";
        private decimal _precio;
        private int _cantidad ;
        public int Id { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del producto no puede estar vacío.");
                _nombre = value;
            }
        }

        public decimal Precio
        {
            get => _precio;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El precio del producto no puede ser negativo.");
                _precio = value;
            }
        }

        public int Cantidad
        {
            get => _cantidad;
            set
            {
                if (value < 0)
                    throw new ArgumentException("La cantidad del producto no puede ser negativa.");
                _cantidad = value;
            }
        }

        public CategoriaProducto Categoria { get; set; }

        public EstadoProducto Estado { get; set; }

        public DateTime FechaProducto { get; set; } = DateTime.Now;

        public decimal valorTotal => _precio * _cantidad;

        public override string ToString()
        {
            return $"Producto: {_nombre}, Precio: {_precio:C}, Cantidad: {_cantidad}, Total: {valorTotal:C}";
        }
    }
}