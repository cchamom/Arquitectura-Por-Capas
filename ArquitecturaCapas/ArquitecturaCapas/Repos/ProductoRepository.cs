using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArquitecturaCapas.Data;
using ArquitecturaCapas.Models;

namespace ArquitecturaCapas.Repos
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly TiendaDbContext _context;

        public ProductoRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task CrearAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync(); 
        }
    }
}