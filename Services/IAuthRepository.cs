using Backend.Data;
using Backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public interface IAuthService
    {
        Task<Admin?> Authenticate(string correo, string clave);
    }

    public class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }

        public async Task<Admin?> Authenticate(string correo, string clave)
        {
            return await _context.Admins.SingleOrDefaultAsync(a => a.Correo == correo && a.Clave == clave);
        }
    }
}
