using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class CuponesRedencionRepository : ICuponesRedencionRepository
    {
        public readonly DataContext _context;
        public CuponesRedencionRepository(DataContext context)
        {
            _context = context;
        }

        public void CrearRedencion(Redencion redencion)
        {
            _context.Redenciones.Add(redencion);
            _context.SaveChanges();
        }

        public IEnumerable<Redencion> ListarRedenciones()
        {
            return _context.Redenciones.ToList();
        }

        public async Task<IEnumerable<Redencion>> ValidarCupon(ReedemRequest redencion)
        {
            try
            {
                Console.WriteLine("aaaaaaaaaaaaaaa",redencion);
                var usuario = await _context.Usuarios.FindAsync(redencion.UsuarioId);
                if (usuario == null)
                {
                    Console.WriteLine("Usuario no encontrado");
                    return new List<Redencion>();
                }

                var cupon = await _context.Cupones.FirstOrDefaultAsync(c => c.CodigoCupon == redencion.CodigoCupon);
                if (cupon == null)
                {
                    Console.WriteLine("Cupón no encontrado");
                    return new List<Redencion>();
                }

                if (cupon.Usos < cupon.LimiteUsos && cupon.FechaFinalizacion > DateTime.Now)
                {
                    cupon.Usos += 1;
                    _context.Cupones.Update(cupon);
                    await _context.SaveChangesAsync();
                    return await _context.Redenciones.ToListAsync();
                }

                return new List<Redencion>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BBBBBBBBBBBBBBb {ex.Message}");
                return new List<Redencion>();
            }
        }


    }

}