using Microsoft.AspNetCore.Mvc;
    
namespace ArquitecturaCapas.Controllers
{
    public class ClientesController : ControllerBase
    {
        [ApiController]
        [Route("api/controller")]
        private static readonly List<Clientes> clientes = new()
        { 
            new Clientes {Id= 1, Nombre"Cristian", NIT = "123456", Telefono = "50148850"
        };
    }
}
