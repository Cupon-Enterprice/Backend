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
            return _context.Redenciones.Include(e => e.Cupon).ToList();
        }
        public async Task<IEnumerable<Redencion>> ValidarCupon(int UsuariosId, string codigoCupon)
        {
            var usuario = await _context.Usuarios.FindAsync(UsuariosId);
            Console.WriteLine("aaaaasdassa", usuario);
            if (usuario.Id == UsuariosId)
            {
                var cupon = await _context.Cupones.Where(c => c.CodigoCupon == codigoCupon).FirstOrDefaultAsync();
                Console.WriteLine("aaaaaa", cupon);
                if (cupon.Usos < cupon.LimiteUsos)
                {
                    Console.WriteLine("aaaaaa333", cupon);
                    if (cupon.FechaFinalizacion <= DateTime.Now)
                    {
                        Console.WriteLine("aaaaaa44444444444", cupon);
                        cupon.Usos = cupon.Usos + 1;
                        _context.Cupones.Update(cupon);
                        _context.SaveChanges();
                        return _context.Redenciones.ToList();
                    }
                }
            }
            return _context.Redenciones;
        }

    }

}