using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArquitecturaCapas.Models;

namespace ArquitecturaCapas.Repos
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerTodosAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Producto producto);
    }
}