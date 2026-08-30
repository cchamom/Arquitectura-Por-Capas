using ArquitecturaCapas.Models;
using ArquitecturaCapas.Repos;

namespace ArquitecturaCapas.Services
{
    public class ProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductosAsync()
        {
            return await _productoRepository.ObtenerTodosAsync();
        }

        public async Task<Producto?> ObtenerProductoPorIdAsync(int id)
        {
            return await _productoRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Producto> CrearProductoAsync(Producto producto)
        {
            await _productoRepository.CrearAsync(producto);
            
            // Si tu repositorio NO guarda automáticamente los cambios en la BD, 
            // debes llamar al método de guardar:
            // await _productoRepository.GuardarAsync(); 

            return producto;
        }
            }
}