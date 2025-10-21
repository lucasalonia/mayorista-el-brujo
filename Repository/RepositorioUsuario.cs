using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mayorista_el_brujo.Models;

namespace mayorista_el_brujo.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly DataContext _context;
        //_ es una convención muy común en C# para variables privadas de la clase.
        public RepositorioUsuario(DataContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios
                                 .Include(u => u.Persona)
                                 .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario)
        {
            return await _context.Usuarios
                                 .Include(u => u.Persona)
                                 .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _context.Usuarios
                                 .Include(u => u.Persona)
                                 .ToListAsync();
        }

        public async Task AgregarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
