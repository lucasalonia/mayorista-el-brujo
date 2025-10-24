using System.Collections.Generic;
using System.Threading.Tasks;
using mayorista_el_brujo.Models;

namespace mayorista_el_brujo.Repositorios
{
    public interface IRepositorioUsuario
    {
        Task<Usuario> ObtenerPorIdAsync(int id);
        Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario);
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();
        Task CrearUsuarioAsync(Usuario usuario);
        Task ActualizarAsync(Usuario usuario);
        Task EliminarAsync(int id);
    }
}
