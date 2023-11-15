using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaUsuarios.Context;
using SistemaUsuarios.Model;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            if(_context.Usuarios == null)
            {
                return NotFound();
            }

            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]


        [HttpPost]


        [HttpPut("{}")]


        [HttpDelete("{}")]


        private bool UsuarioExists(int id)
        {
            return(_context.Usuarios?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}