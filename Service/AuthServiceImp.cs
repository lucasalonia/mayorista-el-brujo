using mayorista_el_brujo.Models;
using mayorista_el_brujo.Repositorios;
using mayorista_el_brujo.Services;
using BCrypt.Net;

namespace mayorista_el_brujo.Services
{
    public class AuthServiceImpl : AuthService
    {
        private readonly RepositorioUsuario _repositorioUsuario;

        public AuthServiceImpl(RepositorioUsuario repositorioUsuario)
        {
            this._repositorioUsuario = repositorioUsuario;
        }

        // public async Task<Usuario?> AutenticarUsuarioAsync(string username, string password)
        // {
        //     try
        //     {
        //         // Buscar usuario por username
        //         var usuario = await Task.Run(() => usuarioRepository.ObtenerPorUsername(username));
                
        //         if (usuario == null || usuario.Estado != "ACTIVO")
        //         {
        //             return null;
        //         }

        //         // Verificar contraseña
        //         if (!await VerificarContraseñaAsync(password, usuario.Password))
        //         {
        //             return null;
        //         }

        //         // Cargar rol actual del usuario
        //         var rolActual = usuarioRolService.ObtenerActivoPorUsuarioId(usuario.Id);
        //         if (rolActual != null)
        //         {
        //             usuario.RolActual = rolActual.Rol;
        //         }

        //         return usuario;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error en AuthServiceImpl.AutenticarUsuarioAsync: {ex.Message}");
        //         return null;
        //     }
        // }


        // public async Task<bool> ActualizarUltimoLoginAsync(int userId)
        // {
        //     try
        //     {
        //         var usuario = await Task.Run(() => usuarioRepository.ObtenerPorId(userId));
        //         if (usuario != null)
        //         {
        //             usuario.UltimoLogin = DateTime.Now;
        //             return await Task.Run(() => usuarioRepository.ActualizarUsuario(usuario));
        //         }
        //         return false;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error en AuthServiceImpl.ActualizarUltimoLoginAsync: {ex.Message}");
        //         return false;
        //     }
        // }

        // public async Task<bool> VerificarContraseñaAsync(string password, string hashedPassword)
        // {
        //     try
        //     {
        //         return await Task.Run(() =>
        //         {
        //             // Todas las contraseñas usan BCrypt
        //             return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        //         });
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error en AuthServiceImpl.VerificarContraseñaAsync: {ex.Message}");
        //         return false;
        //     }
        // }

        // public string HashearContraseña(string password)
        // {
        //     return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        // }
    }
}
