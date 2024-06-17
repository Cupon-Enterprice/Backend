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
        var cuponExistente = _context.Cupones.Find(Id);
        if (cuponExistente != null)
        {
            cuponExistente.CodigoCupon = cupon.CodigoCupon;
            cuponExistente.Nombre = cupon.Nombre;
            cuponExistente.Descripcion = cupon.Descripcion;
            cuponExistente.FechaCreacion = cupon.FechaCreacion;
            cuponExistente.FechaActualizacion = cupon.FechaActualizacion;
            cuponExistente.FechaInicio = cupon.FechaInicio;
            cuponExistente.FechaFinalizacion = cupon.FechaFinalizacion;
            cuponExistente.ValorDescuento = cupon.ValorDescuento;
            cuponExistente.LimiteUsos = cupon.LimiteUsos;
            cuponExistente.Usos = cupon.Usos;
            cuponExistente.Estado = cupon.Estado;
            cuponExistente.TipoCuponId = cupon.TipoCuponId;
            cuponExistente.AdminId = cupon.AdminId;

            _context.SaveChanges();
        }
        else
        {
            throw new Exception("El cupon con el ID especificado no fue encontrado.");
        }
    }

        public void CrearCupon(Cupon cupon)
        {
            _context.Cupones.Add(cupon);
            _context.SaveChanges();
        }

        public Cupon DetallesCupon(int Id)
        {
            return _context.Cupones.Include(u => u.Admin).Include(u => u.TipoCupon).FirstOrDefault(u => u.Id == Id);
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

        public void ActivarCupon(int Id){
            var activar = _context.Cupones.Find(Id);
            activar.Estado = "Activo";
            _context.Cupones.Update(activar);
            _context.SaveChanges();

        }
    }
}