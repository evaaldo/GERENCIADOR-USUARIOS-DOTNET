using Microsoft.EntityFrameworkCore;
using SistemaUsuarios.Model;

namespace SistemaUsuarios.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public object Usuario { get; internal set; }
    }
}