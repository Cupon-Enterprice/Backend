using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Backend.Services.Mailsender;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Redenciones
{
    public class CuponesRedencionRepository : ICuponesRedencionRepository
    {
        private readonly IMailSenderServices _mailSenderServices;
        public readonly DataContext _context;
        public CuponesRedencionRepository(DataContext context, IMailSenderServices mailSenderServices)
        {
            _context = context;
            _mailSenderServices = mailSenderServices;
        }

        public async Task<Cupon> GetCuponByCodigo(string codigoCupon)
        {
            return await _context.Cupones.FirstOrDefaultAsync(c => c.CodigoCupon == codigoCupon);
        }

        public IEnumerable<Redencion> ListarRedenciones()
        {
            return _context.Redenciones.Include(e => e.Cupon).Include(u => u.Usuario).ToList();
        }

        public async Task<bool> ValidarCupon(ReedemRequest redencionRequest, Redencion redencion)
        {
            try
            {
                

                var usuario = await _context.Usuarios.FindAsync(redencionRequest.UsuarioId);
                if (usuario == null)
                {
                    Console.WriteLine("Usuario no encontrado");
                    return false;
                }

                var cupon = await GetCuponByCodigo(redencionRequest.CodigoCupon);
                if (cupon == null)
                {
                    Console.WriteLine("Cupón no encontrado");
                    return false;
                }

                if (cupon.Usos < cupon.LimiteUsos && cupon.FechaFinalizacion >= DateTime.Now)
                {
                    _context.Redenciones.Add(redencion);
                    await _context.SaveChangesAsync();
                    cupon.Usos += 1;
                    _context.Cupones.Update(cupon);
                    await _context.SaveChangesAsync();

                    _mailSenderServices.SendMail(usuario.Correo, usuario.Nombre, cupon.Nombre);
                    Console.WriteLine("Cupón validado y redención creada");
                    return true;
                }

                Console.WriteLine("El cupón ha alcanzado su límite de usos o está expirado");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
                return false;
            }
        }

    }
}