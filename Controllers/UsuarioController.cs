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
        public async Task<ActionResult<Usuario>> GetUsuarios(int id)
        {
            if(_context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);

            if(usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            if(_context.Usuario == null)
            {
                return Problem("O construtor do usuário é nulo");
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarios", new { id = usuario.ID }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUsuario(int id, Usuario usuario)
        {
            if(id != usuario.ID)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{}")]


        private bool UsuarioExists(int id)
        {
            return(_context.Usuarios?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}