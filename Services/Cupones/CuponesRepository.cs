using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Cupones
{
    public class CuponesRepository : ICuponesRepository
    {
        public readonly DataContext _context;
        public CuponesRepository(DataContext context)
        {
            _context = context;
        }

        public void ActualizarCupon(int Id, Cupon cupon)
        {
            
            _context.Cupones.Find(Id);
            _context.Update(cupon);
            _context.SaveChanges();
        }

        public void CrearCupon(Cupon cupon)
        {
            _context.Cupones.Add(cupon);
            _context.SaveChanges();
        }

        public Cupon DetallesCupon(int Id)
        {
            return _context.Cupones.Find(Id);
        }

        public void EliminarCupon(int Id)
        {
            var eliminar = _context.Cupones.Find(Id);
            eliminar.Estado = "Inactivo";
            _context.Cupones.Update(eliminar);
            _context.SaveChanges();
        }

        public IEnumerable<Cupon> ListarCupones()
        {
            return _context.Cupones.Include(u => u.Admin).Include(u => u.TipoCupon).ToList();
        }
    }
}