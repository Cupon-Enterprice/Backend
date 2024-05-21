using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;

namespace Backend.Services
{
    public class CuponesRedencionRepository : ICuponesRedencionRepository
    {
        public readonly DataContext _context;
        public CuponesRedencionRepository(DataContext context)
        {
            _context = context;
        }

        public void CrearRedencion(Redencion x)
        {
            _context.Redenciones.Add(x);
            _context.SaveChanges();
        }
    }

}