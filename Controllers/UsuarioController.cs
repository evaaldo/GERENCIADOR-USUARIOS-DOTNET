using Microsoft.AspNetCore.Mvc;
using SistemaUsuarios.Context;

namespace SistemaUsuarios.Controller
{
    [Route("Usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Instânciando o UsuarioContext
        private readonly UsuarioContext? _context;

        // Atribuindo o valor da instância à variável _context para que o controlador possa interagir com o banco de dados
        public UsuarioController(UsuarioContext context)
        {
            _context = context;
        }
    }
}